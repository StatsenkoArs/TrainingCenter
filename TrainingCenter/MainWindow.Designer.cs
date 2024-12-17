namespace TrainingCenter
{
    partial class MainWindow
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
            this.btn_openCourse = new System.Windows.Forms.Button();
            this.btn_openTeacher = new System.Windows.Forms.Button();
            this.btn_openSchedule = new System.Windows.Forms.Button();
            this.btn_openSetting = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_openCourse
            // 
            this.btn_openCourse.Location = new System.Drawing.Point(196, 43);
            this.btn_openCourse.Name = "btn_openCourse";
            this.btn_openCourse.Size = new System.Drawing.Size(132, 68);
            this.btn_openCourse.TabIndex = 0;
            this.btn_openCourse.Text = "Курсы";
            this.btn_openCourse.UseVisualStyleBackColor = true;
            this.btn_openCourse.Click += new System.EventHandler(this.btn_openCourse_Click);
            // 
            // btn_openTeacher
            // 
            this.btn_openTeacher.Location = new System.Drawing.Point(175, 148);
            this.btn_openTeacher.Name = "btn_openTeacher";
            this.btn_openTeacher.Size = new System.Drawing.Size(153, 35);
            this.btn_openTeacher.TabIndex = 1;
            this.btn_openTeacher.Text = "Преподаватели";
            this.btn_openTeacher.UseVisualStyleBackColor = true;
            this.btn_openTeacher.Click += new System.EventHandler(this.btn_openTeacher_Click);
            // 
            // btn_openSchedule
            // 
            this.btn_openSchedule.Location = new System.Drawing.Point(191, 217);
            this.btn_openSchedule.Name = "btn_openSchedule";
            this.btn_openSchedule.Size = new System.Drawing.Size(137, 48);
            this.btn_openSchedule.TabIndex = 2;
            this.btn_openSchedule.Text = "Расписание";
            this.btn_openSchedule.UseVisualStyleBackColor = true;
            this.btn_openSchedule.Click += new System.EventHandler(this.btn_openSchedule_Click);
            // 
            // btn_openSetting
            // 
            this.btn_openSetting.Location = new System.Drawing.Point(196, 297);
            this.btn_openSetting.Name = "btn_openSetting";
            this.btn_openSetting.Size = new System.Drawing.Size(101, 40);
            this.btn_openSetting.TabIndex = 3;
            this.btn_openSetting.Text = "Настройки";
            this.btn_openSetting.UseVisualStyleBackColor = true;
            this.btn_openSetting.Click += new System.EventHandler(this.btn_openSetting_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 499);
            this.Controls.Add(this.btn_openSetting);
            this.Controls.Add(this.btn_openSchedule);
            this.Controls.Add(this.btn_openTeacher);
            this.Controls.Add(this.btn_openCourse);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_openCourse;
        private System.Windows.Forms.Button btn_openTeacher;
        private System.Windows.Forms.Button btn_openSchedule;
        private System.Windows.Forms.Button btn_openSetting;
    }
}

