using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainingCenter
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_openCourse_Click(object sender, EventArgs e)
        {
            CoursesWindow1 coursesWindow1 = new CoursesWindow1();
            coursesWindow1.Show();
        }

        private void btn_openTeacher_Click(object sender, EventArgs e)
        {

        }

        private void btn_openSchedule_Click(object sender, EventArgs e)
        {
            CourseSchedule courseSchedule = new CourseSchedule();
            courseSchedule.Show();
        }

        private void btn_openSetting_Click(object sender, EventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();   
            settingsWindow.Show();
        }
    }
}
