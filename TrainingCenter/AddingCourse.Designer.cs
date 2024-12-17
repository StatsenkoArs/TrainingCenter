namespace TrainingCenter
{
    partial class AddingCourse
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
            this.btn_saveCourse = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPreparation = new System.Windows.Forms.TextBox();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.cmbPeriodicity = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_saveCourse
            // 
            this.btn_saveCourse.Location = new System.Drawing.Point(388, 451);
            this.btn_saveCourse.Name = "btn_saveCourse";
            this.btn_saveCourse.Size = new System.Drawing.Size(127, 43);
            this.btn_saveCourse.TabIndex = 0;
            this.btn_saveCourse.Text = "Добавить";
            this.btn_saveCourse.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(219, 38);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(114, 22);
            this.txtName.TabIndex = 1;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(181, 108);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(216, 62);
            this.txtDescription.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Название курса";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Описание курса";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Требуемая подготовка";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Продолжительность (мин)";
            // 
            // txtPreparation
            // 
            this.txtPreparation.Location = new System.Drawing.Point(219, 214);
            this.txtPreparation.Multiline = true;
            this.txtPreparation.Name = "txtPreparation";
            this.txtPreparation.Size = new System.Drawing.Size(156, 28);
            this.txtPreparation.TabIndex = 7;
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(254, 264);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(100, 22);
            this.txtDuration.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 323);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Тип обучения";
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(181, 324);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(121, 24);
            this.cmbType.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 392);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Стоимость (руб)";
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(202, 386);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(100, 22);
            this.txtCost.TabIndex = 12;
            // 
            // cmbPeriodicity
            // 
            this.cmbPeriodicity.FormattingEnabled = true;
            this.cmbPeriodicity.Location = new System.Drawing.Point(190, 461);
            this.cmbPeriodicity.Name = "cmbPeriodicity";
            this.cmbPeriodicity.Size = new System.Drawing.Size(121, 24);
            this.cmbPeriodicity.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 465);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Периодичность";
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Location = new System.Drawing.Point(420, 40);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(84, 20);
            this.chkIsActive.TabIndex = 16;
            this.chkIsActive.Text = "Активен";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(396, 520);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(119, 37);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // AddingCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 532);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbPeriodicity);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.txtPreparation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btn_saveCourse);
            this.Name = "AddingCourse";
            this.Text = "Создание нового курса";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_saveCourse;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPreparation;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.ComboBox cmbPeriodicity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Button btnCancel;
    }
}