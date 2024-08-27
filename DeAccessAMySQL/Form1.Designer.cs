namespace DeAccessAMySQL
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnMoverDatos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pBAvanceProceso = new System.Windows.Forms.ProgressBar();
            this.tbCantidadRegistros = new System.Windows.Forms.TextBox();
            this.dgvListadoOrigen = new System.Windows.Forms.DataGridView();
            this.dgvListadoDestino = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoOrigen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoDestino)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMoverDatos
            // 
            this.btnMoverDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoverDatos.Image = ((System.Drawing.Image)(resources.GetObject("btnMoverDatos.Image")));
            this.btnMoverDatos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMoverDatos.Location = new System.Drawing.Point(78, 212);
            this.btnMoverDatos.Name = "btnMoverDatos";
            this.btnMoverDatos.Size = new System.Drawing.Size(236, 61);
            this.btnMoverDatos.TabIndex = 0;
            this.btnMoverDatos.Text = "Mover Datos";
            this.btnMoverDatos.UseVisualStyleBackColor = true;
            this.btnMoverDatos.Click += new System.EventHandler(this.btnMoverDatos_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Blue;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(92, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(701, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "TRANSFERENCIA DE DATOS ENTRE MOTORES DE BASE DE DATOS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "ORIGEN (ACCESS)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(403, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Avance del proceso";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(654, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Cantidad de Registros";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 288);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "DESTINO (MYSQL)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pBAvanceProceso
            // 
            this.pBAvanceProceso.Location = new System.Drawing.Point(382, 232);
            this.pBAvanceProceso.Name = "pBAvanceProceso";
            this.pBAvanceProceso.Size = new System.Drawing.Size(170, 32);
            this.pBAvanceProceso.TabIndex = 6;
            // 
            // tbCantidadRegistros
            // 
            this.tbCantidadRegistros.Location = new System.Drawing.Point(695, 235);
            this.tbCantidadRegistros.Name = "tbCantidadRegistros";
            this.tbCantidadRegistros.Size = new System.Drawing.Size(50, 20);
            this.tbCantidadRegistros.TabIndex = 7;
            // 
            // dgvListadoOrigen
            // 
            this.dgvListadoOrigen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoOrigen.Location = new System.Drawing.Point(37, 56);
            this.dgvListadoOrigen.Name = "dgvListadoOrigen";
            this.dgvListadoOrigen.Size = new System.Drawing.Size(805, 150);
            this.dgvListadoOrigen.TabIndex = 8;
            // 
            // dgvListadoDestino
            // 
            this.dgvListadoDestino.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoDestino.Location = new System.Drawing.Point(37, 304);
            this.dgvListadoDestino.Name = "dgvListadoDestino";
            this.dgvListadoDestino.Size = new System.Drawing.Size(805, 150);
            this.dgvListadoDestino.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 466);
            this.Controls.Add(this.dgvListadoDestino);
            this.Controls.Add(this.dgvListadoOrigen);
            this.Controls.Add(this.tbCantidadRegistros);
            this.Controls.Add(this.pBAvanceProceso);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMoverDatos);
            this.Name = "Form1";
            this.Text = "Transferencias de datos ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoOrigen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoDestino)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMoverDatos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar pBAvanceProceso;
        private System.Windows.Forms.TextBox tbCantidadRegistros;
        private System.Windows.Forms.DataGridView dgvListadoOrigen;
        private System.Windows.Forms.DataGridView dgvListadoDestino;
    }
}

