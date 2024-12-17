namespace TrainingCenter
{
    partial class CoursesWindow1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_deleteCourse = new System.Windows.Forms.Button();
            this.btn_refreshCourses = new System.Windows.Forms.Button();
            this.btn_addCourse = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(781, 816);
            this.dataGridView1.TabIndex = 0;
            // 
            // btn_deleteCourse
            // 
            this.btn_deleteCourse.Location = new System.Drawing.Point(827, 22);
            this.btn_deleteCourse.Name = "btn_deleteCourse";
            this.btn_deleteCourse.Size = new System.Drawing.Size(159, 56);
            this.btn_deleteCourse.TabIndex = 1;
            this.btn_deleteCourse.Text = "Удалить";
            this.btn_deleteCourse.UseVisualStyleBackColor = true;
            // 
            // btn_refreshCourses
            // 
            this.btn_refreshCourses.Location = new System.Drawing.Point(827, 100);
            this.btn_refreshCourses.Name = "btn_refreshCourses";
            this.btn_refreshCourses.Size = new System.Drawing.Size(159, 45);
            this.btn_refreshCourses.TabIndex = 2;
            this.btn_refreshCourses.Text = "Обновить данные";
            this.btn_refreshCourses.UseVisualStyleBackColor = true;
            // 
            // btn_addCourse
            // 
            this.btn_addCourse.Location = new System.Drawing.Point(832, 175);
            this.btn_addCourse.Name = "btn_addCourse";
            this.btn_addCourse.Size = new System.Drawing.Size(154, 50);
            this.btn_addCourse.TabIndex = 3;
            this.btn_addCourse.Text = "Добавить курс";
            this.btn_addCourse.UseVisualStyleBackColor = true;
            this.btn_addCourse.Click += new System.EventHandler(this.btn_addCourse_Click);
            // 
            // CoursesWindow1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 726);
            this.Controls.Add(this.btn_addCourse);
            this.Controls.Add(this.btn_refreshCourses);
            this.Controls.Add(this.btn_deleteCourse);
            this.Controls.Add(this.dataGridView1);
            this.Name = "CoursesWindow1";
            this.Text = "Курсы";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_deleteCourse;
        private System.Windows.Forms.Button btn_refreshCourses;
        private System.Windows.Forms.Button btn_addCourse;
    }
}