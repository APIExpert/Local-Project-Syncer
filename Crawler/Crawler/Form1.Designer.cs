namespace Crawler
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tclogin = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tcupload = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnnext = new System.Windows.Forms.Button();
            this.btnupload = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.browsercontrol = new System.Windows.Forms.Button();
            this.fileuploadtxt = new System.Windows.Forms.TextBox();
            this.tcprocess = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblwait = new System.Windows.Forms.Label();
            this.lblprocessed = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.lblrecords = new System.Windows.Forms.Label();
            this.btnexporttocsv = new System.Windows.Forms.Button();
            this.btnpause = new System.Windows.Forms.Button();
            this.btngo = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tclogin.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tcupload.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tcprocess.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tclogin);
            this.tabControl1.Controls.Add(this.tcupload);
            this.tabControl1.Controls.Add(this.tcprocess);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(890, 503);
            this.tabControl1.TabIndex = 0;
            // 
            // tclogin
            // 
            this.tclogin.BackColor = System.Drawing.Color.Cyan;
            this.tclogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tclogin.BackgroundImage")));
            this.tclogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tclogin.Controls.Add(this.panel1);
            this.tclogin.Location = new System.Drawing.Point(4, 25);
            this.tclogin.Name = "tclogin";
            this.tclogin.Padding = new System.Windows.Forms.Padding(3);
            this.tclogin.Size = new System.Drawing.Size(882, 474);
            this.tclogin.TabIndex = 0;
            this.tclogin.Text = "Login";
            this.tclogin.Click += new System.EventHandler(this.tclogin_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FloralWhite;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtusername);
            this.panel1.Controls.Add(this.txtpassword);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(262, 146);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(348, 174);
            this.panel1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(75, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "SignIn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "UserName:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PowderBlue;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(80, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(138, 58);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(171, 23);
            this.txtusername.TabIndex = 0;
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(138, 87);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '*';
            this.txtpassword.Size = new System.Drawing.Size(171, 23);
            this.txtpassword.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            // 
            // tcupload
            // 
            this.tcupload.BackColor = System.Drawing.Color.Cyan;
            this.tcupload.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tcupload.BackgroundImage")));
            this.tcupload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tcupload.Controls.Add(this.panel2);
            this.tcupload.Location = new System.Drawing.Point(4, 25);
            this.tcupload.Name = "tcupload";
            this.tcupload.Padding = new System.Windows.Forms.Padding(3);
            this.tcupload.Size = new System.Drawing.Size(882, 474);
            this.tcupload.TabIndex = 1;
            this.tcupload.Text = "Upload File";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FloralWhite;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnnext);
            this.panel2.Controls.Add(this.btnupload);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.browsercontrol);
            this.panel2.Controls.Add(this.fileuploadtxt);
            this.panel2.Location = new System.Drawing.Point(207, 91);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(487, 199);
            this.panel2.TabIndex = 7;
            // 
            // btnnext
            // 
            this.btnnext.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnnext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnnext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnext.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnnext.Location = new System.Drawing.Point(176, 156);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(75, 36);
            this.btnnext.TabIndex = 7;
            this.btnnext.Text = "Next";
            this.btnnext.UseVisualStyleBackColor = false;
            this.btnnext.Click += new System.EventHandler(this.btnnext_Click);
            // 
            // btnupload
            // 
            this.btnupload.BackColor = System.Drawing.Color.PowderBlue;
            this.btnupload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnupload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupload.Location = new System.Drawing.Point(128, 114);
            this.btnupload.Name = "btnupload";
            this.btnupload.Size = new System.Drawing.Size(176, 23);
            this.btnupload.TabIndex = 6;
            this.btnupload.Text = "Upload Selected File";
            this.btnupload.UseVisualStyleBackColor = false;
            this.btnupload.Click += new System.EventHandler(this.btnupload_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(454, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Upload File Only (Format comma split csv file)";
            // 
            // browsercontrol
            // 
            this.browsercontrol.BackColor = System.Drawing.Color.PowderBlue;
            this.browsercontrol.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.browsercontrol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browsercontrol.Location = new System.Drawing.Point(366, 66);
            this.browsercontrol.Name = "browsercontrol";
            this.browsercontrol.Size = new System.Drawing.Size(75, 23);
            this.browsercontrol.TabIndex = 4;
            this.browsercontrol.Text = "Browse";
            this.browsercontrol.UseVisualStyleBackColor = false;
            this.browsercontrol.Click += new System.EventHandler(this.browsercontrol_Click);
            // 
            // fileuploadtxt
            // 
            this.fileuploadtxt.Location = new System.Drawing.Point(29, 66);
            this.fileuploadtxt.Name = "fileuploadtxt";
            this.fileuploadtxt.Size = new System.Drawing.Size(322, 23);
            this.fileuploadtxt.TabIndex = 0;
            // 
            // tcprocess
            // 
            this.tcprocess.BackColor = System.Drawing.Color.Cyan;
            this.tcprocess.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tcprocess.BackgroundImage")));
            this.tcprocess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tcprocess.Controls.Add(this.panel3);
            this.tcprocess.Location = new System.Drawing.Point(4, 25);
            this.tcprocess.Name = "tcprocess";
            this.tcprocess.Size = new System.Drawing.Size(882, 474);
            this.tcprocess.TabIndex = 2;
            this.tcprocess.Text = "Process";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FloralWhite;
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(67, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(736, 431);
            this.panel3.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.dataGridView1);
            this.panel5.Location = new System.Drawing.Point(3, 123);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(724, 297);
            this.panel5.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, -2);
            this.dataGridView1.MinimumSize = new System.Drawing.Size(700, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 80;
            this.dataGridView1.Size = new System.Drawing.Size(713, 293);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.lblwait);
            this.panel4.Controls.Add(this.lblprocessed);
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.lblrecords);
            this.panel4.Controls.Add(this.btnexporttocsv);
            this.panel4.Controls.Add(this.btnpause);
            this.panel4.Controls.Add(this.btngo);
            this.panel4.Location = new System.Drawing.Point(8, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(719, 114);
            this.panel4.TabIndex = 0;
            // 
            // lblwait
            // 
            this.lblwait.AutoSize = true;
            this.lblwait.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblwait.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblwait.Location = new System.Drawing.Point(558, 21);
            this.lblwait.Name = "lblwait";
            this.lblwait.Size = new System.Drawing.Size(41, 13);
            this.lblwait.TabIndex = 11;
            this.lblwait.Text = "label5";
            // 
            // lblprocessed
            // 
            this.lblprocessed.AutoSize = true;
            this.lblprocessed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblprocessed.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblprocessed.Location = new System.Drawing.Point(38, 77);
            this.lblprocessed.Name = "lblprocessed";
            this.lblprocessed.Size = new System.Drawing.Size(86, 20);
            this.lblprocessed.TabIndex = 10;
            this.lblprocessed.Text = "#Records";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DodgerBlue;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(432, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 34);
            this.button2.TabIndex = 9;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // lblrecords
            // 
            this.lblrecords.AutoSize = true;
            this.lblrecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrecords.ForeColor = System.Drawing.Color.DarkRed;
            this.lblrecords.Location = new System.Drawing.Point(38, 57);
            this.lblrecords.Name = "lblrecords";
            this.lblrecords.Size = new System.Drawing.Size(86, 20);
            this.lblrecords.TabIndex = 3;
            this.lblrecords.Text = "#Records";
            // 
            // btnexporttocsv
            // 
            this.btnexporttocsv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexporttocsv.Location = new System.Drawing.Point(264, 12);
            this.btnexporttocsv.Name = "btnexporttocsv";
            this.btnexporttocsv.Size = new System.Drawing.Size(149, 33);
            this.btnexporttocsv.TabIndex = 2;
            this.btnexporttocsv.Text = "Export To CSV";
            this.btnexporttocsv.UseVisualStyleBackColor = true;
            this.btnexporttocsv.Click += new System.EventHandler(this.btnexporttocsv_Click);
            // 
            // btnpause
            // 
            this.btnpause.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnpause.Location = new System.Drawing.Point(137, 12);
            this.btnpause.Name = "btnpause";
            this.btnpause.Size = new System.Drawing.Size(105, 33);
            this.btnpause.TabIndex = 1;
            this.btnpause.Text = "Pause";
            this.btnpause.UseVisualStyleBackColor = true;
            this.btnpause.Click += new System.EventHandler(this.btnpause_Click);
            // 
            // btngo
            // 
            this.btngo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngo.Location = new System.Drawing.Point(42, 12);
            this.btngo.Name = "btngo";
            this.btngo.Size = new System.Drawing.Size(75, 33);
            this.btngo.TabIndex = 0;
            this.btngo.Text = "Go";
            this.btngo.UseVisualStyleBackColor = true;
            this.btngo.Click += new System.EventHandler(this.btngo_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage1.BackgroundImage")));
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.Controls.Add(this.dataGridView2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(882, 474);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Error";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(145, 77);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(579, 330);
            this.dataGridView2.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "\"csv files (*.csv)|*.csv|All files (*.*)|*.*\";";
            this.openFileDialog1.Title = "Browse Csv Files.";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.ClientSize = new System.Drawing.Size(914, 527);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Web Crawler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tclogin.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tcupload.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tcprocess.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tclogin;
        private System.Windows.Forms.TabPage tcupload;
        private System.Windows.Forms.TabPage tcprocess;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnnext;
        private System.Windows.Forms.Button btnupload;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button browsercontrol;
        private System.Windows.Forms.TextBox fileuploadtxt;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblrecords;
        private System.Windows.Forms.Button btnexporttocsv;
        private System.Windows.Forms.Button btnpause;
        private System.Windows.Forms.Button btngo;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblprocessed;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label lblwait;
    }
}