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
            var courseId = GetFirstCourseId();

            if (courseId == 0)
            {
                MessageBox.Show("Не удалось найти курс для создания расписания.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            long teacherId = GetFirstTeacherForCourse(courseId);

            decimal cost = GetCourseCostForTrainingType(courseId, "очный");

            string periodicity = GetCoursePeriodicity(courseId);

            DateTime startDate = DateTime.Now;
            for (int i = 0; i < 6; i++)
            {
                CreateGroupScheduleEntry(courseId, teacherId, startDate, cost, "Очный");
                if (periodicity == "Еженедельно")
                {
                    startDate = startDate.AddDays(7);
                }
            }

            MessageBox.Show("Расписание успешно добавлено.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadScheduleData();
        }

        private long GetFirstCourseId()
        {
            long courseId = 0;

            string query = "SELECT TOP 1 Id FROM Courses WHERE IsActive = 1";
            var connection = _dataBase.getConnection();
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                var result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    courseId = Convert.ToInt64(result);
                }
            }

            return courseId;
        }

        private long GetFirstTeacherForCourse(long courseId)
        {
            long teacherId = 0;

            string query = @"
                SELECT TOP 1 TeacherId
                FROM CourseTeachers
                WHERE CourseId = @CourseId";

            var connection = _dataBase.getConnection();
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CourseId", courseId);
                var result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    teacherId = Convert.ToInt64(result);
                }
            }

            return teacherId;
        }

        private decimal GetCourseCostForTrainingType(long courseId, string trainingType)
        {
            decimal cost = 0;

            string query = @"
                SELECT TOP 1 Cost
                FROM CourseCosts
                WHERE CourseId = @CourseId AND TrainingType = @TrainingType";

            var connection = _dataBase.getConnection();
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CourseId", courseId);
                command.Parameters.AddWithValue("@TrainingType", trainingType);
                var result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    cost = Convert.ToDecimal(result);
                }
            }

            return cost;
        }

        private string GetCoursePeriodicity(long courseId)
        {
            string periodicity = string.Empty;

            string query = @"
                SELECT TOP 1 Periodicity
                FROM Courses
                WHERE Id = @CourseId";

            var connection = _dataBase.getConnection();
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CourseId", courseId);
                var result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    periodicity = result.ToString();
                }
            }

            return periodicity;
        }

        private void CreateGroupScheduleEntry(long courseId, long teacherId, DateTime startDate, decimal cost, string trainingType)
        {
            string query = @"
                INSERT INTO GroupSchedules (CourseId, CourseCostId, StartDate, TeacherId, SeatsAvailable)
                VALUES (@CourseId, (SELECT Id FROM CourseCosts WHERE CourseId = @CourseId AND TrainingType = @TrainingType), @StartDate, @TeacherId, 15)";

            var connection = _dataBase.getConnection();
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CourseId", courseId);
                command.Parameters.AddWithValue("@TeacherId", teacherId);
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@TrainingType", trainingType);
                command.ExecuteNonQuery();
            }
        }
    }
}