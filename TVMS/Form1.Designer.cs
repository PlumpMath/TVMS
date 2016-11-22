namespace TVMS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.input_name = new System.Windows.Forms.TextBox();
            this.input_teacher = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.input_group = new System.Windows.Forms.TextBox();
            this.input_X = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Action = new System.Windows.Forms.Button();
            this.input_alpha = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.input_Y = new System.Windows.Forms.RichTextBox();
            this.input_n = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ваше имя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Имя преподавателя";
            // 
            // input_name
            // 
            this.input_name.Location = new System.Drawing.Point(132, 18);
            this.input_name.Name = "input_name";
            this.input_name.Size = new System.Drawing.Size(215, 20);
            this.input_name.TabIndex = 0;
            this.input_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.input_name_KeyPress);
            // 
            // input_teacher
            // 
            this.input_teacher.Location = new System.Drawing.Point(132, 43);
            this.input_teacher.Name = "input_teacher";
            this.input_teacher.Size = new System.Drawing.Size(215, 20);
            this.input_teacher.TabIndex = 1;
            this.input_teacher.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.input_name_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Номер группы";
            // 
            // input_group
            // 
            this.input_group.Location = new System.Drawing.Point(132, 69);
            this.input_group.Name = "input_group";
            this.input_group.Size = new System.Drawing.Size(215, 20);
            this.input_group.TabIndex = 2;
            // 
            // input_X
            // 
            this.input_X.Location = new System.Drawing.Point(14, 89);
            this.input_X.Name = "input_X";
            this.input_X.Size = new System.Drawing.Size(332, 55);
            this.input_X.TabIndex = 5;
            this.input_X.Text = "";
            this.input_X.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Заполните выборку X";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Заполните выборку Y";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.input_group);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.input_teacher);
            this.groupBox1.Controls.Add(this.input_name);
            this.groupBox1.Location = new System.Drawing.Point(9, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 98);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Оформление";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Action);
            this.groupBox2.Controls.Add(this.input_alpha);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.input_Y);
            this.groupBox2.Controls.Add(this.input_n);
            this.groupBox2.Controls.Add(this.input_X);
            this.groupBox2.Location = new System.Drawing.Point(10, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(352, 253);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Работа с данными";
            // 
            // Action
            // 
            this.Action.Location = new System.Drawing.Point(14, 224);
            this.Action.Name = "Action";
            this.Action.Size = new System.Drawing.Size(332, 23);
            this.Action.TabIndex = 7;
            this.Action.Text = "Потеть над курсовой";
            this.Action.UseVisualStyleBackColor = true;
            this.Action.Click += new System.EventHandler(this.Action_Click);
            // 
            // input_alpha
            // 
            this.input_alpha.FormattingEnabled = true;
            this.input_alpha.Location = new System.Drawing.Point(131, 44);
            this.input_alpha.Name = "input_alpha";
            this.input_alpha.Size = new System.Drawing.Size(215, 21);
            this.input_alpha.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Уровень значимости";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Размер выборки";
            // 
            // input_Y
            // 
            this.input_Y.Location = new System.Drawing.Point(14, 163);
            this.input_Y.Name = "input_Y";
            this.input_Y.Size = new System.Drawing.Size(332, 55);
            this.input_Y.TabIndex = 6;
            this.input_Y.Text = "";
            this.input_Y.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress);
            // 
            // input_n
            // 
            this.input_n.Location = new System.Drawing.Point(131, 19);
            this.input_n.Name = "input_n";
            this.input_n.Size = new System.Drawing.Size(215, 20);
            this.input_n.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 405);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(352, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(374, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(97, 22);
            this.toolStripButton1.Text = "Прочитай меня";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(374, 393);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Курсач по ТВМС";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox input_name;
        private System.Windows.Forms.TextBox input_teacher;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox input_group;
        private System.Windows.Forms.RichTextBox input_X;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox input_alpha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox input_Y;
        private System.Windows.Forms.TextBox input_n;
        private System.Windows.Forms.Button Action;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

