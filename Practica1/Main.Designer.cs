namespace Practica1
{
    partial class Main
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cBResolution = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cBCamera = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tBMaxBlue = new System.Windows.Forms.TrackBar();
            this.tBMaxGreen = new System.Windows.Forms.TrackBar();
            this.tBMaxRed = new System.Windows.Forms.TrackBar();
            this.tBMinBlue = new System.Windows.Forms.TrackBar();
            this.tBMinGreen = new System.Windows.Forms.TrackBar();
            this.tBMinRed = new System.Windows.Forms.TrackBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cBMask = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBMaxBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBMaxGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBMaxRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBMinBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBMinGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBMinRed)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.cBResolution);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cBCamera);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 171);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Step 1 Cameras";
            // 
            // btnConnect
            // 
            this.btnConnect.BackgroundImage = global::Practica1.Properties.Resources.Mazenl77_I_Like_Buttons_3a_Cute_Ball_Go_512;
            this.btnConnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnConnect.Location = new System.Drawing.Point(285, 31);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(106, 93);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cBResolution
            // 
            this.cBResolution.FormattingEnabled = true;
            this.cBResolution.Location = new System.Drawing.Point(77, 68);
            this.cBResolution.Name = "cBResolution";
            this.cBResolution.Size = new System.Drawing.Size(147, 21);
            this.cBResolution.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Resolution";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Camera:";
            // 
            // cBCamera
            // 
            this.cBCamera.FormattingEnabled = true;
            this.cBCamera.Location = new System.Drawing.Point(77, 19);
            this.cBCamera.Name = "cBCamera";
            this.cBCamera.Size = new System.Drawing.Size(147, 21);
            this.cBCamera.TabIndex = 0;
            this.cBCamera.SelectedIndexChanged += new System.EventHandler(this.cBCamera_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cBMask);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnLoad);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tBMaxBlue);
            this.groupBox2.Controls.Add(this.tBMaxGreen);
            this.groupBox2.Controls.Add(this.tBMaxRed);
            this.groupBox2.Controls.Add(this.tBMinBlue);
            this.groupBox2.Controls.Add(this.tBMinGreen);
            this.groupBox2.Controls.Add(this.tBMinRed);
            this.groupBox2.Location = new System.Drawing.Point(12, 189);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(414, 319);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Step 2 Filtros";
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = global::Practica1.Properties.Resources.guardar_icon;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.Location = new System.Drawing.Point(340, 182);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(51, 52);
            this.btnSave.TabIndex = 13;
            this.toolTip1.SetToolTip(this.btnSave, "Guardar Datos");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.BackgroundImage = global::Practica1.Properties.Resources.cargar_icon;
            this.btnLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLoad.Location = new System.Drawing.Point(273, 182);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(51, 52);
            this.btnLoad.TabIndex = 12;
            this.toolTip1.SetToolTip(this.btnLoad, "Cargar Datos");
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Practica1.Properties.Settings.Default, "Bmax", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label8.Location = new System.Drawing.Point(359, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = global::Practica1.Properties.Settings.Default.Bmax;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Practica1.Properties.Settings.Default, "Gmax", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label7.Location = new System.Drawing.Point(359, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = global::Practica1.Properties.Settings.Default.Gmax;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Practica1.Properties.Settings.Default, "Rmax", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label6.Location = new System.Drawing.Point(359, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = global::Practica1.Properties.Settings.Default.Rmax;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Practica1.Properties.Settings.Default, "Bmin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label5.Location = new System.Drawing.Point(145, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = global::Practica1.Properties.Settings.Default.Bmin;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Practica1.Properties.Settings.Default, "Gmin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label4.Location = new System.Drawing.Point(145, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = global::Practica1.Properties.Settings.Default.Gmin;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Practica1.Properties.Settings.Default, "Rmin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label3.Location = new System.Drawing.Point(145, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = global::Practica1.Properties.Settings.Default.Rmin;
            // 
            // tBMaxBlue
            // 
            this.tBMaxBlue.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Practica1.Properties.Settings.Default, "VBmax", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tBMaxBlue.Location = new System.Drawing.Point(215, 134);
            this.tBMaxBlue.Maximum = 255;
            this.tBMaxBlue.Name = "tBMaxBlue";
            this.tBMaxBlue.Size = new System.Drawing.Size(120, 45);
            this.tBMaxBlue.TabIndex = 5;
            this.tBMaxBlue.Value = global::Practica1.Properties.Settings.Default.VBmax;
            this.tBMaxBlue.ValueChanged += new System.EventHandler(this.tBMinRed_ValueChanged);
            // 
            // tBMaxGreen
            // 
            this.tBMaxGreen.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Practica1.Properties.Settings.Default, "VGmax", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tBMaxGreen.Location = new System.Drawing.Point(215, 83);
            this.tBMaxGreen.Maximum = 255;
            this.tBMaxGreen.Name = "tBMaxGreen";
            this.tBMaxGreen.Size = new System.Drawing.Size(120, 45);
            this.tBMaxGreen.TabIndex = 4;
            this.tBMaxGreen.Value = global::Practica1.Properties.Settings.Default.VGmax;
            this.tBMaxGreen.ValueChanged += new System.EventHandler(this.tBMinRed_ValueChanged);
            // 
            // tBMaxRed
            // 
            this.tBMaxRed.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Practica1.Properties.Settings.Default, "VRmax", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tBMaxRed.Location = new System.Drawing.Point(215, 19);
            this.tBMaxRed.Maximum = 255;
            this.tBMaxRed.Name = "tBMaxRed";
            this.tBMaxRed.Size = new System.Drawing.Size(120, 45);
            this.tBMaxRed.TabIndex = 3;
            this.tBMaxRed.Value = global::Practica1.Properties.Settings.Default.VRmax;
            this.tBMaxRed.ValueChanged += new System.EventHandler(this.tBMinRed_ValueChanged);
            // 
            // tBMinBlue
            // 
            this.tBMinBlue.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Practica1.Properties.Settings.Default, "VBmin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tBMinBlue.Location = new System.Drawing.Point(6, 134);
            this.tBMinBlue.Maximum = 255;
            this.tBMinBlue.Name = "tBMinBlue";
            this.tBMinBlue.Size = new System.Drawing.Size(120, 45);
            this.tBMinBlue.TabIndex = 2;
            this.tBMinBlue.Value = global::Practica1.Properties.Settings.Default.VBmin;
            this.tBMinBlue.ValueChanged += new System.EventHandler(this.tBMinRed_ValueChanged);
            // 
            // tBMinGreen
            // 
            this.tBMinGreen.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Practica1.Properties.Settings.Default, "VGmin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tBMinGreen.Location = new System.Drawing.Point(6, 70);
            this.tBMinGreen.Maximum = 255;
            this.tBMinGreen.Name = "tBMinGreen";
            this.tBMinGreen.Size = new System.Drawing.Size(120, 45);
            this.tBMinGreen.TabIndex = 1;
            this.tBMinGreen.Value = global::Practica1.Properties.Settings.Default.VGmin;
            this.tBMinGreen.ValueChanged += new System.EventHandler(this.tBMinRed_ValueChanged);
            // 
            // tBMinRed
            // 
            this.tBMinRed.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Practica1.Properties.Settings.Default, "VRmin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tBMinRed.Location = new System.Drawing.Point(6, 19);
            this.tBMinRed.Maximum = 255;
            this.tBMinRed.Name = "tBMinRed";
            this.tBMinRed.Size = new System.Drawing.Size(120, 45);
            this.tBMinRed.TabIndex = 0;
            this.tBMinRed.Value = global::Practica1.Properties.Settings.Default.VRmin;
            this.tBMinRed.ValueChanged += new System.EventHandler(this.tBMinRed_ValueChanged);
            // 
            // cBMask
            // 
            this.cBMask.AutoSize = true;
            this.cBMask.Location = new System.Drawing.Point(25, 216);
            this.cBMask.Name = "cBMask";
            this.cBMask.Size = new System.Drawing.Size(48, 17);
            this.cBMask.TabIndex = 14;
            this.cBMask.Text = "Filtro";
            this.cBMask.UseVisualStyleBackColor = true;
            this.cBMask.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 586);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBMaxBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBMaxGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBMaxRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBMinBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBMinGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBMinRed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cBResolution;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cBCamera;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar tBMaxBlue;
        private System.Windows.Forms.TrackBar tBMaxGreen;
        private System.Windows.Forms.TrackBar tBMaxRed;
        private System.Windows.Forms.TrackBar tBMinBlue;
        private System.Windows.Forms.TrackBar tBMinGreen;
        private System.Windows.Forms.TrackBar tBMinRed;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox cBMask;
    }
}

