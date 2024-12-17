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
            LoadScheduleData();
        }

        private void LoadScheduleData()
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
            var query = "SELECT \r\n    Id AS 'Код',\r\n    TrainingCenter AS 'Учебный центр',\r\n    Curator AS 'Куратор',\r\n    " +
                "Name AS 'Название',\r\n    Description AS 'Описание',\r\n    RequiredPreparation AS 'Требуемая подготовка',\r\n    " +
                "DurationHours AS 'Продолжительность (часы)',\r\n    Periodicity AS 'Периодичность',\r\n    CASE \r\n        " +
                "WHEN IsActive = 1 THEN 'Активен' \r\n        ELSE 'Неактивен' \r\n    END AS 'Активен'\r\nFROM \r\n    Courses;";

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

            LoadScheduleData();
        }
    }
}