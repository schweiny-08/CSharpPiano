namespace PianoApp
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.StopButton = new System.Windows.Forms.Button();
            this.TempoMenu = new System.Windows.Forms.ComboBox();
            this.Play = new System.Windows.Forms.Button();
            this.load = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.notificationMessage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clear = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.delete = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(263, 397);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(410, 150);
            this.panel1.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.StopButton);
            this.panel2.Controls.Add(this.TempoMenu);
            this.panel2.Controls.Add(this.Play);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(836, 241);
            this.panel2.TabIndex = 1;
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(108, 215);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 2;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // TempoMenu
            // 
            this.TempoMenu.FormattingEnabled = true;
            this.TempoMenu.Items.AddRange(new object[] {
            "Grave",
            "Largo",
            "Lento",
            "Adagio",
            "Andante",
            "Moderato",
            "Allegro",
            "Presto"});
            this.TempoMenu.Location = new System.Drawing.Point(229, 216);
            this.TempoMenu.Name = "TempoMenu";
            this.TempoMenu.Size = new System.Drawing.Size(121, 21);
            this.TempoMenu.TabIndex = 1;
            // 
            // Play
            // 
            this.Play.Location = new System.Drawing.Point(27, 214);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(75, 23);
            this.Play.TabIndex = 0;
            this.Play.Text = "Play";
            this.Play.UseVisualStyleBackColor = true;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // load
            // 
            this.load.Location = new System.Drawing.Point(312, 311);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(75, 40);
            this.load.TabIndex = 0;
            this.load.Text = "Load";
            this.load.UseVisualStyleBackColor = true;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(393, 311);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 40);
            this.save.TabIndex = 2;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // notificationMessage
            // 
            this.notificationMessage.Location = new System.Drawing.Point(755, 341);
            this.notificationMessage.Name = "notificationMessage";
            this.notificationMessage.Size = new System.Drawing.Size(311, 67);
            this.notificationMessage.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(872, 306);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Notifications";
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(555, 311);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(75, 40);
            this.clear.TabIndex = 5;
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(482, 366);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(164, 21);
            this.comboBox1.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(312, 366);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(164, 20);
            this.textBox1.TabIndex = 7;
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(474, 311);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(75, 40);
            this.delete.TabIndex = 8;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 593);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.load);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.save);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.notificationMessage);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button load;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Label notificationMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button Play;
        private System.Windows.Forms.ComboBox TempoMenu;
        private System.Windows.Forms.Button StopButton;

    }
}

