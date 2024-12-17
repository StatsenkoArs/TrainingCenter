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
    public partial class CoursesWindow1 : Form
    {
        public CoursesWindow1()
        {
            InitializeComponent();
        }

        private void btn_addCourse_Click(object sender, EventArgs e)
        {
            AddingCourse addingCourse = new AddingCourse();
            addingCourse.ShowDialog();
        }
    }
}
