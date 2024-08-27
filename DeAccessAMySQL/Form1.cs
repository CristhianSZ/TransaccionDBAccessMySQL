using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Configuration;
using System.Data.OleDb;


using MySql.Data.MySqlClient;




namespace DeAccessAMySQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarDatosEnDataGridViewOrigen();
        }
        //Cargado de datos en la primer gridview
        private void CargarDatosEnDataGridViewOrigen()
        {
            string cadenaOrigen = ConfigurationManager.ConnectionStrings["Cadena_Access_Origen"].ConnectionString;

            using (OleDbConnection cnnOrigen = new OleDbConnection(cadenaOrigen))
            {
                try
                {
                    // Abrir la conexión
                    cnnOrigen.Open();

                    // Leer los datos de la tabla Productos
                    string leerDatosSQL = "SELECT * FROM Productos";
                    DataTable datosOrigen = new DataTable();

                    using (OleDbDataAdapter dap = new OleDbDataAdapter(leerDatosSQL, cnnOrigen))
                    {
                        dap.Fill(datosOrigen); // Llenar el DataTable con los datos obtenidos
                    }

                    // Asignar los datos al DataGridView para mostrarlos
                    dgvListadoOrigen.DataSource = datosOrigen;
                }
                catch (Exception ex)
                {
                    // Mostrar el error en un MessageBox
                    MessageBox.Show("Error al cargar los datos: " + ex.Message);
                }
                finally
                {
                    //cierro la concexion
                    if (cnnOrigen.State == ConnectionState.Open)
                    {
                        cnnOrigen.Close();
                    }
                }
            }
        }



        // Variable para verificar si los datos ya han sido transaccionados
        private bool datosTransaccionados = false;

        //Modularizacion de btnMoverDatos
        private void btnMoverDatos_Click(object sender, EventArgs e)
        {
            if (datosTransaccionados)
            {
                MessageBox.Show("Los datos ya han sido transaccionados.");
                return;
            }

            btnMoverDatos.Enabled = false;

            string connectionStringMySQL = "Server=localhost;Database=bddestino;Uid=root;Pwd=123456a$;";
            string connectionStringAccess = ConfigurationManager.ConnectionStrings["Cadena_Access_Origen"].ConnectionString;

            using (OleDbConnection cnnOrigen = new OleDbConnection(connectionStringAccess))
            using (MySqlConnection cnnDestino = new MySqlConnection(connectionStringMySQL))
            {
                try
                {
                    cnnOrigen.Open();
                    cnnDestino.Open();

                    // Crear la tabla si no existe
                    CrearTablaProductos(cnnDestino);

                    // Leer datos de Access
                    DataTable datosOrigen = LeerDatosDesdeAccess(cnnOrigen);

                    // Configurar ProgressBar y TextBox
                    ConfigurarInterfazUsuario(datosOrigen.Rows.Count);

                    // Insertar datos en MySQL
                    InsertarDatosEnMySQL(datosOrigen, cnnDestino);

                    MessageBox.Show("Datos transferidos correctamente.");
                    CargarDatosEnDataGridViewDestino();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error durante la transferencia de datos: " + ex.Message);
                }
                finally
                {
                    if (cnnOrigen.State == ConnectionState.Open) cnnOrigen.Close();
                    if (cnnDestino.State == ConnectionState.Open) cnnDestino.Close();
                }
            }
        }

        private void CrearTablaProductos(MySqlConnection cnnDestino)
        {
            string crearTablaSQL = @"
    CREATE TABLE IF NOT EXISTS Productos (
        id INT AUTO_INCREMENT PRIMARY KEY,
        marca VARCHAR(50),
        nombre VARCHAR(100),
        descripcion VARCHAR(255),
        categoria VARCHAR(50),
        stock INT,
        precioCosto DOUBLE,
        precioVenta DOUBLE
    )";

            using (MySqlCommand cmd = new MySqlCommand(crearTablaSQL, cnnDestino))
            {
                cmd.ExecuteNonQuery();
            }
        }

        private DataTable LeerDatosDesdeAccess(OleDbConnection cnnOrigen)
        {
            string leerDatosSQL = "SELECT * FROM Productos";
            DataTable datosOrigen = new DataTable();

            using (OleDbDataAdapter dap = new OleDbDataAdapter(leerDatosSQL, cnnOrigen))
            {
                dap.Fill(datosOrigen);
            }

            return datosOrigen;
        }

        private void ConfigurarInterfazUsuario(int cantidadRegistros)
        {
            pBAvanceProceso.Minimum = 0;
            pBAvanceProceso.Maximum = cantidadRegistros;
            pBAvanceProceso.Value = 0;
            tbCantidadRegistros.Text = "0";
        }

        private void InsertarDatosEnMySQL(DataTable datosOrigen, MySqlConnection cnnDestino)
        {
            string insertarDatosSQL = @"
    INSERT INTO Productos (marca, nombre, descripcion, categoria, stock, precioCosto, precioVenta) 
    VALUES (@marca, @nombre, @descripcion, @categoria, @stock, @precioCosto, @precioVenta)";

            using (MySqlTransaction transaccion = cnnDestino.BeginTransaction())
            {
                try
                {
                    foreach (DataRow fila in datosOrigen.Rows)
                    {
                        using (MySqlCommand cmd = new MySqlCommand(insertarDatosSQL, cnnDestino, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@marca", fila["marca"]);
                            cmd.Parameters.AddWithValue("@nombre", fila["nombre"]);
                            cmd.Parameters.AddWithValue("@descripcion", fila["descripcion"]);
                            cmd.Parameters.AddWithValue("@categoria", fila["categoria"]);
                            cmd.Parameters.AddWithValue("@stock", fila["stock"]);
                            cmd.Parameters.AddWithValue("@precioCosto", fila["precioCosto"]);
                            cmd.Parameters.AddWithValue("@precioVenta", fila["precioVenta"]);
                            cmd.ExecuteNonQuery();
                        }

                        pBAvanceProceso.Value++;
                        tbCantidadRegistros.Text = pBAvanceProceso.Value.ToString();
                        Application.DoEvents();
                    }

                    transaccion.Commit();
                }
                catch
                {
                    transaccion.Rollback();
                    throw;
                }
            }
        }


        //Cargado de datos en el segundo gridview
        private void CargarDatosEnDataGridViewDestino()
        {
            string cadenaDestino = ConfigurationManager.ConnectionStrings["Cadena_MySQL_Destino"].ConnectionString;

            using (MySqlConnection cnnDestino = new MySqlConnection(cadenaDestino))
            {
                try
                {
                    // Abrir la conexión
                    cnnDestino.Open();

                    // Leer los datos de la tabla Productos
                    string leerDatosSQL = "CALL getProductos ()";
                    DataTable datosDestino = new DataTable();

                    using (MySqlDataAdapter dap = new MySqlDataAdapter(leerDatosSQL, cnnDestino))
                    {
                        dap.Fill(datosDestino); // Llenar el DataTable con los datos obtenidos
                    }

                    // Asignar los datos al DataGridView para mostrarlos
                    dgvListadoDestino.DataSource = datosDestino;
                }
                catch (Exception ex)
                {
                    // Mostrar el error en un MessageBox
                    MessageBox.Show("Error al cargar los datos: " + ex.Message);
                }
            }
        }




              
    }
}
