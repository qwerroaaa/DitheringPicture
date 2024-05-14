namespace DitheringPicture
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.LoadPictureBut = new System.Windows.Forms.Button();
            this.ExportPictureBut = new System.Windows.Forms.Button();
            this.DitheringBut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.packName = new System.Windows.Forms.TextBox();
            this.LevelDitheringBar = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.deleteBut = new System.Windows.Forms.Button();
            this.PreviousBut = new System.Windows.Forms.Button();
            this.NextBut = new System.Windows.Forms.Button();
            this.ExportPictureBox = new System.Windows.Forms.PictureBox();
            this.InputPictureBox = new System.Windows.Forms.PictureBox();
            this.exitBut = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.ColorComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.LevelDitheringBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExportPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadPictureBut
            // 
            this.LoadPictureBut.Location = new System.Drawing.Point(63, 432);
            this.LoadPictureBut.Name = "LoadPictureBut";
            this.LoadPictureBut.Size = new System.Drawing.Size(75, 23);
            this.LoadPictureBut.TabIndex = 2;
            this.LoadPictureBut.Text = "Загрузить";
            this.LoadPictureBut.UseVisualStyleBackColor = true;
            this.LoadPictureBut.Click += new System.EventHandler(this.LoadPictureBut_Click);
            // 
            // ExportPictureBut
            // 
            this.ExportPictureBut.Location = new System.Drawing.Point(144, 432);
            this.ExportPictureBut.Name = "ExportPictureBut";
            this.ExportPictureBut.Size = new System.Drawing.Size(75, 23);
            this.ExportPictureBut.TabIndex = 3;
            this.ExportPictureBut.Text = "Сохранить";
            this.ExportPictureBut.UseVisualStyleBackColor = true;
            this.ExportPictureBut.Click += new System.EventHandler(this.ExportPictureBut_Click);
            // 
            // DitheringBut
            // 
            this.DitheringBut.Location = new System.Drawing.Point(449, 432);
            this.DitheringBut.Name = "DitheringBut";
            this.DitheringBut.Size = new System.Drawing.Size(75, 23);
            this.DitheringBut.TabIndex = 4;
            this.DitheringBut.Text = "Задизерить";
            this.DitheringBut.UseVisualStyleBackColor = true;
            this.DitheringBut.Click += new System.EventHandler(this.DitheringBut_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 416);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Взаимодействие с картинками:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Выбор пакета картинок:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(63, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Выбрать пакет";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ваш пакет:";
            // 
            // packName
            // 
            this.packName.Location = new System.Drawing.Point(63, 83);
            this.packName.Name = "packName";
            this.packName.ReadOnly = true;
            this.packName.Size = new System.Drawing.Size(128, 20);
            this.packName.TabIndex = 9;
            this.packName.Text = "Не выбрано";
            // 
            // LevelDitheringBar
            // 
            this.LevelDitheringBar.Location = new System.Drawing.Point(241, 432);
            this.LevelDitheringBar.Maximum = 400;
            this.LevelDitheringBar.Minimum = 1;
            this.LevelDitheringBar.Name = "LevelDitheringBar";
            this.LevelDitheringBar.Size = new System.Drawing.Size(202, 45);
            this.LevelDitheringBar.TabIndex = 10;
            this.LevelDitheringBar.Value = 200;
            this.LevelDitheringBar.Scroll += new System.EventHandler(this.LevelDitheringBar_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(247, 416);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Сила дизеринга:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.label5.Location = new System.Drawing.Point(159, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 26);
            this.label5.TabIndex = 14;
            this.label5.Text = "Origin";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.label6.Location = new System.Drawing.Point(627, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 26);
            this.label6.TabIndex = 15;
            this.label6.Text = "Dither";
            // 
            // deleteBut
            // 
            this.deleteBut.Location = new System.Drawing.Point(530, 432);
            this.deleteBut.Name = "deleteBut";
            this.deleteBut.Size = new System.Drawing.Size(75, 23);
            this.deleteBut.TabIndex = 16;
            this.deleteBut.Text = "Удалить";
            this.deleteBut.UseVisualStyleBackColor = true;
            this.deleteBut.Click += new System.EventHandler(this.deleteBut_Click);
            // 
            // PreviousBut
            // 
            this.PreviousBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.PreviousBut.ForeColor = System.Drawing.SystemColors.Control;
            this.PreviousBut.Image = global::DitheringPicture.Properties.Resources.левая_стрелка;
            this.PreviousBut.Location = new System.Drawing.Point(12, 238);
            this.PreviousBut.Name = "PreviousBut";
            this.PreviousBut.Size = new System.Drawing.Size(41, 51);
            this.PreviousBut.TabIndex = 13;
            this.PreviousBut.UseVisualStyleBackColor = true;
            this.PreviousBut.Click += new System.EventHandler(this.PreviousBut_Click);
            // 
            // NextBut
            // 
            this.NextBut.BackColor = System.Drawing.SystemColors.Control;
            this.NextBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.NextBut.ForeColor = System.Drawing.SystemColors.ControlText;
            this.NextBut.Image = ((System.Drawing.Image)(resources.GetObject("NextBut.Image")));
            this.NextBut.Location = new System.Drawing.Point(325, 238);
            this.NextBut.Name = "NextBut";
            this.NextBut.Size = new System.Drawing.Size(41, 51);
            this.NextBut.TabIndex = 12;
            this.NextBut.UseVisualStyleBackColor = true;
            this.NextBut.Click += new System.EventHandler(this.NextBut_Click);
            // 
            // ExportPictureBox
            // 
            this.ExportPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ExportPictureBox.Location = new System.Drawing.Point(530, 149);
            this.ExportPictureBox.Name = "ExportPictureBox";
            this.ExportPictureBox.Size = new System.Drawing.Size(256, 256);
            this.ExportPictureBox.TabIndex = 1;
            this.ExportPictureBox.TabStop = false;
            // 
            // InputPictureBox
            // 
            this.InputPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InputPictureBox.Location = new System.Drawing.Point(63, 149);
            this.InputPictureBox.Name = "InputPictureBox";
            this.InputPictureBox.Size = new System.Drawing.Size(256, 256);
            this.InputPictureBox.TabIndex = 0;
            this.InputPictureBox.TabStop = false;
            // 
            // exitBut
            // 
            this.exitBut.Location = new System.Drawing.Point(711, 25);
            this.exitBut.Name = "exitBut";
            this.exitBut.Size = new System.Drawing.Size(75, 23);
            this.exitBut.TabIndex = 17;
            this.exitBut.Text = "Выйти";
            this.exitBut.UseVisualStyleBackColor = true;
            this.exitBut.Click += new System.EventHandler(this.exitBut_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(612, 416);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Выберите палитру:";
            // 
            // ColorComboBox
            // 
            this.ColorComboBox.FormattingEnabled = true;
            this.ColorComboBox.Location = new System.Drawing.Point(615, 432);
            this.ColorComboBox.Name = "ColorComboBox";
            this.ColorComboBox.Size = new System.Drawing.Size(171, 21);
            this.ColorComboBox.TabIndex = 19;
            this.ColorComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ColorComboBox_DrawItem);
            this.ColorComboBox.SelectedIndexChanged += new System.EventHandler(this.ColorComboBox_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 494);
            this.Controls.Add(this.ColorComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.exitBut);
            this.Controls.Add(this.deleteBut);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PreviousBut);
            this.Controls.Add(this.NextBut);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LevelDitheringBar);
            this.Controls.Add(this.packName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DitheringBut);
            this.Controls.Add(this.ExportPictureBut);
            this.Controls.Add(this.LoadPictureBut);
            this.Controls.Add(this.ExportPictureBox);
            this.Controls.Add(this.InputPictureBox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DitheringApp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.LevelDitheringBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExportPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox InputPictureBox;
        private System.Windows.Forms.PictureBox ExportPictureBox;
        private System.Windows.Forms.Button LoadPictureBut;
        private System.Windows.Forms.Button ExportPictureBut;
        private System.Windows.Forms.Button DitheringBut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox packName;
        private System.Windows.Forms.TrackBar LevelDitheringBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button NextBut;
        private System.Windows.Forms.Button PreviousBut;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button deleteBut;
        private System.Windows.Forms.Button exitBut;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox ColorComboBox;
    }
}

