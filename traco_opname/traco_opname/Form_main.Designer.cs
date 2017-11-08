namespace traco_opname
{
    partial class Form_main
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
            this.btn_serialize = new System.Windows.Forms.Button();
            this.pg_bewerkingen = new System.Windows.Forms.PropertyGrid();
            this.pg_grippervarianten = new System.Windows.Forms.PropertyGrid();
            this.num_grippervariant = new System.Windows.Forms.NumericUpDown();
            this.num_bewerking = new System.Windows.Forms.NumericUpDown();
            this.btn_xml = new System.Windows.Forms.Button();
            this.pb_opname = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_totaal = new System.Windows.Forms.ListBox();
            this.lb_zijde1 = new System.Windows.Forms.ListBox();
            this.lb_zijde2 = new System.Windows.Forms.ListBox();
            this.lb_zijde3 = new System.Windows.Forms.ListBox();
            this.lb_zijde4 = new System.Windows.Forms.ListBox();
            this.lb_134 = new System.Windows.Forms.ListBox();
            this.lb_123 = new System.Windows.Forms.ListBox();
            this.lb_234 = new System.Windows.Forms.ListBox();
            this.lb_124 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cb_grijper = new System.Windows.Forms.CheckBox();
            this.lb_12 = new System.Windows.Forms.ListBox();
            this.lb_34 = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num_grippervariant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_bewerking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_opname)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_serialize
            // 
            this.btn_serialize.Enabled = false;
            this.btn_serialize.Location = new System.Drawing.Point(515, 18);
            this.btn_serialize.Name = "btn_serialize";
            this.btn_serialize.Size = new System.Drawing.Size(260, 40);
            this.btn_serialize.TabIndex = 0;
            this.btn_serialize.Text = "Serialize test";
            this.btn_serialize.UseVisualStyleBackColor = true;
            this.btn_serialize.Click += new System.EventHandler(this.btn_serialize_Click);
            // 
            // pg_bewerkingen
            // 
            this.pg_bewerkingen.LineColor = System.Drawing.SystemColors.ControlDark;
            this.pg_bewerkingen.Location = new System.Drawing.Point(12, 66);
            this.pg_bewerkingen.Name = "pg_bewerkingen";
            this.pg_bewerkingen.Size = new System.Drawing.Size(231, 221);
            this.pg_bewerkingen.TabIndex = 1;
            this.pg_bewerkingen.ToolbarVisible = false;
            // 
            // pg_grippervarianten
            // 
            this.pg_grippervarianten.LineColor = System.Drawing.SystemColors.ControlDark;
            this.pg_grippervarianten.Location = new System.Drawing.Point(12, 394);
            this.pg_grippervarianten.Name = "pg_grippervarianten";
            this.pg_grippervarianten.Size = new System.Drawing.Size(231, 324);
            this.pg_grippervarianten.TabIndex = 2;
            this.pg_grippervarianten.ToolbarVisible = false;
            // 
            // num_grippervariant
            // 
            this.num_grippervariant.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_grippervariant.Location = new System.Drawing.Point(181, 293);
            this.num_grippervariant.Name = "num_grippervariant";
            this.num_grippervariant.Size = new System.Drawing.Size(62, 44);
            this.num_grippervariant.TabIndex = 3;
            this.num_grippervariant.ValueChanged += new System.EventHandler(this.num_grippervariant_ValueChanged);
            // 
            // num_bewerking
            // 
            this.num_bewerking.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_bewerking.Location = new System.Drawing.Point(181, 16);
            this.num_bewerking.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_bewerking.Name = "num_bewerking";
            this.num_bewerking.Size = new System.Drawing.Size(62, 44);
            this.num_bewerking.TabIndex = 4;
            this.num_bewerking.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_bewerking.ValueChanged += new System.EventHandler(this.num_bewerking_ValueChanged);
            // 
            // btn_xml
            // 
            this.btn_xml.Location = new System.Drawing.Point(249, 16);
            this.btn_xml.Name = "btn_xml";
            this.btn_xml.Size = new System.Drawing.Size(260, 44);
            this.btn_xml.TabIndex = 5;
            this.btn_xml.Text = "Kies TRACO XML";
            this.btn_xml.UseVisualStyleBackColor = true;
            this.btn_xml.Click += new System.EventHandler(this.btn_xml_Click);
            // 
            // pb_opname
            // 
            this.pb_opname.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pb_opname.Location = new System.Drawing.Point(249, 66);
            this.pb_opname.Name = "pb_opname";
            this.pb_opname.Size = new System.Drawing.Size(747, 526);
            this.pb_opname.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb_opname.TabIndex = 7;
            this.pb_opname.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Alle zijdes",
            "Zijde1",
            "Zijde2",
            "Zijde3",
            "Zijde4",
            "Combo12",
            "Combo34",
            "Combo124",
            "Combo134",
            "Combo123",
            "Combo234"});
            this.comboBox1.Location = new System.Drawing.Point(12, 343);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(231, 45);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 37);
            this.label1.TabIndex = 9;
            this.label1.Text = "Bewerking";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 37);
            this.label2.TabIndex = 10;
            this.label2.Text = "Variant";
            // 
            // lb_totaal
            // 
            this.lb_totaal.FormattingEnabled = true;
            this.lb_totaal.Location = new System.Drawing.Point(249, 623);
            this.lb_totaal.Name = "lb_totaal";
            this.lb_totaal.Size = new System.Drawing.Size(65, 95);
            this.lb_totaal.TabIndex = 11;
            // 
            // lb_zijde1
            // 
            this.lb_zijde1.FormattingEnabled = true;
            this.lb_zijde1.Location = new System.Drawing.Point(320, 623);
            this.lb_zijde1.Name = "lb_zijde1";
            this.lb_zijde1.Size = new System.Drawing.Size(65, 95);
            this.lb_zijde1.TabIndex = 12;
            // 
            // lb_zijde2
            // 
            this.lb_zijde2.FormattingEnabled = true;
            this.lb_zijde2.Location = new System.Drawing.Point(391, 623);
            this.lb_zijde2.Name = "lb_zijde2";
            this.lb_zijde2.Size = new System.Drawing.Size(65, 95);
            this.lb_zijde2.TabIndex = 13;
            // 
            // lb_zijde3
            // 
            this.lb_zijde3.FormattingEnabled = true;
            this.lb_zijde3.Location = new System.Drawing.Point(462, 623);
            this.lb_zijde3.Name = "lb_zijde3";
            this.lb_zijde3.Size = new System.Drawing.Size(65, 95);
            this.lb_zijde3.TabIndex = 14;
            // 
            // lb_zijde4
            // 
            this.lb_zijde4.FormattingEnabled = true;
            this.lb_zijde4.Location = new System.Drawing.Point(533, 623);
            this.lb_zijde4.Name = "lb_zijde4";
            this.lb_zijde4.Size = new System.Drawing.Size(65, 95);
            this.lb_zijde4.TabIndex = 15;
            // 
            // lb_134
            // 
            this.lb_134.FormattingEnabled = true;
            this.lb_134.Location = new System.Drawing.Point(931, 623);
            this.lb_134.Name = "lb_134";
            this.lb_134.Size = new System.Drawing.Size(65, 95);
            this.lb_134.TabIndex = 19;
            // 
            // lb_123
            // 
            this.lb_123.FormattingEnabled = true;
            this.lb_123.Location = new System.Drawing.Point(860, 623);
            this.lb_123.Name = "lb_123";
            this.lb_123.Size = new System.Drawing.Size(65, 95);
            this.lb_123.TabIndex = 18;
            // 
            // lb_234
            // 
            this.lb_234.FormattingEnabled = true;
            this.lb_234.Location = new System.Drawing.Point(789, 623);
            this.lb_234.Name = "lb_234";
            this.lb_234.Size = new System.Drawing.Size(65, 95);
            this.lb_234.TabIndex = 17;
            // 
            // lb_124
            // 
            this.lb_124.FormattingEnabled = true;
            this.lb_124.Location = new System.Drawing.Point(718, 623);
            this.lb_124.Name = "lb_124";
            this.lb_124.Size = new System.Drawing.Size(65, 95);
            this.lb_124.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(260, 607);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Alles";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(331, 607);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Zijde1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(400, 607);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Zijde2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(473, 607);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Zijde3";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(541, 607);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Zijde4";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(728, 607);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "124";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(800, 607);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "234";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(871, 607);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "123";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(940, 607);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "134";
            // 
            // cb_grijper
            // 
            this.cb_grijper.AutoSize = true;
            this.cb_grijper.Location = new System.Drawing.Point(789, 29);
            this.cb_grijper.Name = "cb_grijper";
            this.cb_grijper.Size = new System.Drawing.Size(88, 17);
            this.cb_grijper.TabIndex = 29;
            this.cb_grijper.Text = "Teken grijper";
            this.cb_grijper.UseVisualStyleBackColor = true;
            this.cb_grijper.CheckedChanged += new System.EventHandler(this.cb_grijper_CheckedChanged);
            // 
            // lb_12
            // 
            this.lb_12.FormattingEnabled = true;
            this.lb_12.Location = new System.Drawing.Point(657, 623);
            this.lb_12.Name = "lb_12";
            this.lb_12.Size = new System.Drawing.Size(55, 95);
            this.lb_12.TabIndex = 31;
            // 
            // lb_34
            // 
            this.lb_34.FormattingEnabled = true;
            this.lb_34.Location = new System.Drawing.Point(604, 623);
            this.lb_34.Name = "lb_34";
            this.lb_34.Size = new System.Drawing.Size(47, 95);
            this.lb_34.TabIndex = 30;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(612, 607);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(19, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "34";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(670, 607);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(19, 13);
            this.label13.TabIndex = 33;
            this.label13.Text = "12";
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lb_12);
            this.Controls.Add(this.lb_34);
            this.Controls.Add(this.cb_grijper);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_134);
            this.Controls.Add(this.lb_123);
            this.Controls.Add(this.lb_234);
            this.Controls.Add(this.lb_124);
            this.Controls.Add(this.lb_zijde4);
            this.Controls.Add(this.lb_zijde3);
            this.Controls.Add(this.lb_zijde2);
            this.Controls.Add(this.lb_zijde1);
            this.Controls.Add(this.lb_totaal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.pb_opname);
            this.Controls.Add(this.btn_xml);
            this.Controls.Add(this.num_bewerking);
            this.Controls.Add(this.num_grippervariant);
            this.Controls.Add(this.pg_grippervarianten);
            this.Controls.Add(this.pg_bewerkingen);
            this.Controls.Add(this.btn_serialize);
            this.Name = "Form_main";
            this.Text = "Traco opname";
            this.Load += new System.EventHandler(this.Form_main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_grippervariant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_bewerking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_opname)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_serialize;
        private System.Windows.Forms.PropertyGrid pg_bewerkingen;
        private System.Windows.Forms.PropertyGrid pg_grippervarianten;
        private System.Windows.Forms.NumericUpDown num_grippervariant;
        private System.Windows.Forms.NumericUpDown num_bewerking;
        private System.Windows.Forms.Button btn_xml;
        private System.Windows.Forms.PictureBox pb_opname;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lb_totaal;
        private System.Windows.Forms.ListBox lb_zijde1;
        private System.Windows.Forms.ListBox lb_zijde2;
        private System.Windows.Forms.ListBox lb_zijde3;
        private System.Windows.Forms.ListBox lb_zijde4;
        private System.Windows.Forms.ListBox lb_134;
        private System.Windows.Forms.ListBox lb_123;
        private System.Windows.Forms.ListBox lb_234;
        private System.Windows.Forms.ListBox lb_124;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox cb_grijper;
        private System.Windows.Forms.ListBox lb_12;
        private System.Windows.Forms.ListBox lb_34;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}

