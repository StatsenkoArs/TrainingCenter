using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainingCenter
{
    public partial class TeacherWindow : Form
    {
        private readonly DataBase _dataBase;

        public TeacherWindow()
        {
            InitializeComponent();
            _dataBase = new DataBase();

            LoadTeacherData();
        }

        private void LoadTeacherData()
        {
            try
            {
                dataGridView1.DataSource = GetTeacherData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable GetTeacherData()
        {
            var query = @"
                SELECT
                    T.FullName AS 'Преподаватель',
                    STRING_AGG(C.Name, ', ') AS 'Курсы'
                FROM
                    Teachers T
                JOIN
                    CourseTeachers CT ON T.Id = CT.TeacherId
                JOIN
                    Courses C ON CT.CourseId = C.Id
                GROUP BY
                    T.FullName;
";

            var connection = _dataBase.getConnection();
            var command = new SqlCommand(query, connection);
            var adapter = new SqlDataAdapter(command);

            var dataTable = new DataTable();
            adapter.Fill(dataTable);

            return dataTable;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
        }
    }
}