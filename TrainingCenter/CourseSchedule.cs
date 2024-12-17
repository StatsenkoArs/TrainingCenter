using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TrainingCenter
{
    public partial class CourseSchedule : Form
    {
        private readonly DataBase _dataBase;

        public CourseSchedule()
        {
            InitializeComponent();

            _dataBase = new DataBase();
            LoadScheduleData();
        }

        /// <summary>
        /// Загружает данные расписания и привязывает их к DataGridView.
        /// </summary>
        private void LoadScheduleData()
        {
            try
            {
                dataGridView1.DataSource = GetScheduleData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Выполняет SQL-запрос и возвращает данные расписания.
        /// </summary>
        /// <returns>Таблица с данными расписания.</returns>
        private DataTable GetScheduleData()
        {
            var query = @"
                SELECT
                    FORMAT(StartDate, 'dd.MM.yyyy') AS 'Дата начала',
                    T.FullName AS 'Преподаватель',
                    G.SeatsAvailable AS 'Количество мест',
                    CC.Cost AS 'Стоимость',
                    CC.TrainingType AS 'Тип обучения'
                FROM
                    GroupSchedules G
                JOIN
                    Teachers T ON G.TeacherId = T.Id
                JOIN
                    CourseCosts CC ON G.CourseCostId = CC.Id;
            ";

            var connection = _dataBase.getConnection();
            var command = new SqlCommand(query, connection);
            var adapter = new SqlDataAdapter(command);

            var dataTable = new DataTable();
            adapter.Fill(dataTable);

            return dataTable;
        }

        /// <summary>
        /// Обработчик кнопки обновления данных.
        /// </summary>
        private void btn_create_Click(object sender, EventArgs e)
        {
            LoadScheduleData();
        }
    }
}