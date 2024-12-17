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
    public partial class CoursesWindow1 : Form
    {
        private readonly DataBase _dataBase;

        public CoursesWindow1()
        {
            InitializeComponent();

            _dataBase = new DataBase();
            LoadCourseData();
        }

        private void LoadCourseData()
        {
            try
            {
                dataGridView1.DataSource = GetCourseData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable GetCourseData()
        {
            var query = @"
            SELECT
                Id AS 'Код',
                TrainingCenter AS 'Учебный центр',
                Curator AS 'Куратор',
                Name AS 'Название',
                Description AS 'Описание',
                RequiredPreparation AS 'Требуемая подготовка',
                DurationHours AS 'Продолжительность (часы)',
                Periodicity AS 'Периодичность',
                CASE
                    WHEN IsActive = 1 THEN 'Активен'
                    ELSE 'Неактивен'
                END AS 'Активен'
            FROM
                Courses;
";

            var connection = _dataBase.getConnection();
            var command = new SqlCommand(query, connection);
            var adapter = new SqlDataAdapter(command);

            var dataTable = new DataTable();
            adapter.Fill(dataTable);

            return dataTable;
        }

        private void btn_addCourse_Click(object sender, EventArgs e)
        {
            AddingCourse addingCourse = new AddingCourse();
            addingCourse.ShowDialog();

            LoadCourseData();
        }
    }
}