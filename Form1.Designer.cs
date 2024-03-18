namespace WinFormsApp1 {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            panel1 = new Panel();
            buildBtn = new Button();
            radiusBox = new TextBox();
            y1Box = new TextBox();
            y2Box = new TextBox();
            stepBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            resultsTable = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            loadBtn = new Button();
            saveBtn = new Button();
            infoBtn = new Button();
            checkBox1 = new CheckBox();
            button1 = new Button();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)resultsTable).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(39, 48, 67);
            panel1.BackgroundImageLayout = ImageLayout.Center;
            panel1.Location = new Point(232, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(679, 543);
            panel1.TabIndex = 0;
            // 
            // buildBtn
            // 
            buildBtn.BackColor = Color.White;
            buildBtn.Enabled = false;
            buildBtn.FlatStyle = FlatStyle.System;
            buildBtn.ForeColor = Color.FromArgb(39, 48, 67);
            buildBtn.Location = new Point(40, 180);
            buildBtn.Name = "buildBtn";
            buildBtn.Size = new Size(150, 29);
            buildBtn.TabIndex = 1;
            buildBtn.Text = "Построить график";
            buildBtn.UseVisualStyleBackColor = false;
            buildBtn.Click += BuildBtn_Click;
            // 
            // radiusBox
            // 
            radiusBox.BackColor = Color.FromArgb(239, 246, 238);
            radiusBox.Location = new Point(157, 33);
            radiusBox.Name = "radiusBox";
            radiusBox.PlaceholderText = "R";
            radiusBox.Size = new Size(45, 27);
            radiusBox.TabIndex = 2;
            radiusBox.TextChanged += TextBox_TextChanged;
            radiusBox.KeyPress += TextBoxPos_KeyPress;
            // 
            // y1Box
            // 
            y1Box.BackColor = Color.FromArgb(239, 246, 238);
            y1Box.Location = new Point(157, 99);
            y1Box.Name = "y1Box";
            y1Box.PlaceholderText = "y1";
            y1Box.Size = new Size(45, 27);
            y1Box.TabIndex = 4;
            y1Box.TextChanged += TextBox_TextChanged;
            y1Box.KeyPress += TextBoxGeneral_KeyPress;
            // 
            // y2Box
            // 
            y2Box.BackColor = Color.FromArgb(239, 246, 238);
            y2Box.Location = new Point(157, 132);
            y2Box.Name = "y2Box";
            y2Box.PlaceholderText = "y2";
            y2Box.Size = new Size(45, 27);
            y2Box.TabIndex = 5;
            y2Box.TextChanged += TextBox_TextChanged;
            y2Box.KeyPress += TextBoxGeneral_KeyPress;
            // 
            // stepBox
            // 
            stepBox.BackColor = Color.FromArgb(239, 246, 238);
            stepBox.Location = new Point(157, 67);
            stepBox.Name = "stepBox";
            stepBox.PlaceholderText = "Шаг";
            stepBox.Size = new Size(46, 27);
            stepBox.TabIndex = 3;
            stepBox.TextChanged += TextBox_TextChanged;
            stepBox.KeyPress += TextBoxPos_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(239, 246, 238);
            label1.Location = new Point(91, 36);
            label1.Name = "label1";
            label1.Size = new Size(59, 20);
            label1.TabIndex = 8;
            label1.Text = "Радиус:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(239, 246, 238);
            label2.Location = new Point(111, 69);
            label2.Name = "label2";
            label2.Size = new Size(40, 20);
            label2.TabIndex = 9;
            label2.Text = "Шаг:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.FromArgb(239, 246, 238);
            label3.Location = new Point(6, 101);
            label3.Name = "label3";
            label3.Size = new Size(145, 20);
            label3.TabIndex = 10;
            label3.Text = " Нижняя граница y:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.FromArgb(239, 246, 238);
            label4.Location = new Point(8, 135);
            label4.Name = "label4";
            label4.Size = new Size(143, 20);
            label4.TabIndex = 11;
            label4.Text = "Верхняя граница y:";
            // 
            // resultsTable
            // 
            resultsTable.AllowUserToAddRows = false;
            resultsTable.AllowUserToDeleteRows = false;
            resultsTable.BackgroundColor = SystemColors.ActiveBorder;
            resultsTable.ColumnHeadersHeight = 29;
            resultsTable.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2 });
            resultsTable.GridColor = SystemColors.ActiveBorder;
            resultsTable.Location = new Point(917, 36);
            resultsTable.Name = "resultsTable";
            resultsTable.ReadOnly = true;
            resultsTable.RowHeadersVisible = false;
            resultsTable.RowHeadersWidth = 51;
            resultsTable.RowTemplate.Height = 29;
            resultsTable.ScrollBars = ScrollBars.Vertical;
            resultsTable.Size = new Size(250, 469);
            resultsTable.TabIndex = 12;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column1.HeaderText = "X";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 125;
            // 
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column2.HeaderText = "Y";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 125;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // loadBtn
            // 
            loadBtn.FlatStyle = FlatStyle.System;
            loadBtn.ForeColor = Color.FromArgb(39, 48, 67);
            loadBtn.Location = new Point(114, 216);
            loadBtn.Margin = new Padding(3, 4, 3, 4);
            loadBtn.Name = "loadBtn";
            loadBtn.Size = new Size(101, 31);
            loadBtn.TabIndex = 13;
            loadBtn.Text = "Загрузить";
            loadBtn.UseVisualStyleBackColor = true;
            loadBtn.Click += LoadBtn_Click;
            // 
            // saveBtn
            // 
            saveBtn.BackColor = Color.White;
            saveBtn.Enabled = false;
            saveBtn.FlatStyle = FlatStyle.System;
            saveBtn.ForeColor = Color.FromArgb(39, 48, 67);
            saveBtn.Location = new Point(8, 216);
            saveBtn.Margin = new Padding(3, 4, 3, 4);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(101, 31);
            saveBtn.TabIndex = 14;
            saveBtn.Text = "Сохранить";
            saveBtn.UseVisualStyleBackColor = false;
            saveBtn.Click += SaveBtn_Click;
            // 
            // infoBtn
            // 
            infoBtn.FlatStyle = FlatStyle.System;
            infoBtn.ForeColor = Color.FromArgb(39, 48, 67);
            infoBtn.Location = new Point(40, 253);
            infoBtn.Name = "infoBtn";
            infoBtn.Size = new Size(150, 29);
            infoBtn.TabIndex = 15;
            infoBtn.Text = "Информация";
            infoBtn.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.ForeColor = Color.FromArgb(239, 246, 238);
            checkBox1.Location = new Point(6, 300);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(196, 57);
            checkBox1.TabIndex = 16;
            checkBox1.Text = "Показать информацию при запуске";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // button1
            // 
            button1.Location = new Point(56, 363);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 17;
            button1.Text = "Тест";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.FromArgb(239, 246, 238);
            label5.Location = new Point(56, 395);
            label5.Name = "label5";
            label5.Size = new Size(0, 20);
            label5.TabIndex = 18;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(39, 48, 67);
            ClientSize = new Size(1205, 549);
            Controls.Add(label5);
            Controls.Add(button1);
            Controls.Add(checkBox1);
            Controls.Add(infoBtn);
            Controls.Add(saveBtn);
            Controls.Add(loadBtn);
            Controls.Add(resultsTable);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(stepBox);
            Controls.Add(y2Box);
            Controls.Add(y1Box);
            Controls.Add(radiusBox);
            Controls.Add(buildBtn);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)resultsTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button buildBtn;
        private TextBox radiusBox;
        private TextBox y1Box;
        private TextBox y2Box;
        private TextBox stepBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private DataGridView resultsTable;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private Button loadBtn;
        private Button saveBtn;
        private Button infoBtn;
        private CheckBox checkBox1;
        private Button button1;
        private Label label5;
    }
}
