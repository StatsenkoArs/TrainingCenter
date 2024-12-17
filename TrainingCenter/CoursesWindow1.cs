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
        private const int MAX_WEEKLY_COURSES = 5;

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
            connection.Close();
            return dataTable;
        }

        private void btn_addCourse_Click(object sender, EventArgs e)
        {
            AddingCourse addingCourse = new AddingCourse();
            addingCourse.ShowDialog();

            LoadCourseData();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Получаем изменённое значение
                var updatedValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                // Получаем заголовок столбца и ID записи
                var columnName = dataGridView1.Columns[e.ColumnIndex].HeaderText;
                var recordId = dataGridView1.Rows[e.RowIndex].Cells["Код"].Value?.ToString();

                if (string.IsNullOrEmpty(recordId))
                {
                    MessageBox.Show("Не удалось сохранить изменения. Отсутствует идентификатор записи.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Определяем таблицу, поле и тип данных для проверки
                string tableName, fieldName;
                string expectedDataType = "string";
                bool isValid = true;

                switch (columnName)
                {
                    case "Учебный центр":
                        tableName = "Courses";
                        fieldName = "TrainingCenter";
                        expectedDataType = "string";
                        break;

                    case "Куратор":
                        tableName = "Courses";
                        fieldName = "Curator";
                        expectedDataType = "string";
                        break;

                    case "Название":
                        tableName = "Courses";
                        fieldName = "Name";
                        expectedDataType = "string";
                        break;

                    case "Описание":
                        tableName = "Courses";
                        fieldName = "Description";
                        expectedDataType = "string";
                        break;

                    case "Требуемая подготовка":
                        tableName = "Courses";
                        fieldName = "RequiredPreparation";
                        expectedDataType = "string";
                        break;

                    case "Продолжительность (часы)":
                        tableName = "Courses";
                        fieldName = "DurationHours";
                        expectedDataType = "int";
                        isValid = int.TryParse(updatedValue, out _);
                        break;

                    case "Периодичность":
                        tableName = "Courses";
                        fieldName = "Periodicity";
                        expectedDataType = "string";
                        break;

                    case "Активен":
                        tableName = "Courses";
                        fieldName = "IsActive";
                        updatedValue = updatedValue == "Активен" ? "1" : "0";
                        expectedDataType = "bit";
                        isValid = updatedValue == "1" || updatedValue == "0";
                        break;

                    default:
                        MessageBox.Show("Редактирование этого столбца не поддерживается.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                }

                // Проверка на корректность введённых данных
                if (!isValid)
                {
                    MessageBox.Show($"Неверный формат данных. Ожидается тип: {expectedDataType}.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Проверка на количество еженедельных курсов
                if (!ValidateWeeklyCourseLimit())
                {
                    dataGridView1.CancelEdit();
                    return;
                }

                string query = $@"
                    UPDATE {tableName}
                    SET {fieldName} = @UpdatedValue
                    WHERE Id = @RecordId;";

                var connection = _dataBase.getConnection();
                connection.Open();
                var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@UpdatedValue", updatedValue);
                command.Parameters.AddWithValue("@RecordId", recordId);

                var rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show($"Данные успешно обновлены.");
                }
                else
                {
                    MessageBox.Show("Не удалось обновить данные.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LoadCourseData();
            }
        }

        private bool ValidateWeeklyCourseLimit()
        {
            string coursePeriodicity = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Периодичность"].Value.ToString();

            if (coursePeriodicity == "Еженедельно")
            {
                int activeWeeklyCoursesCount = GetActiveWeeklyCoursesCount();

                if (activeWeeklyCoursesCount >= MAX_WEEKLY_COURSES)
                {
                    MessageBox.Show($"Доступно не более {MAX_WEEKLY_COURSES} активных еженедельных курсов. Сохранение невозможно.",
                                    "Ошибка",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return false; // Не разрешаем сохранить
                }
            }

            return true;
        }

        private int GetActiveWeeklyCoursesCount()
        {
            int count = 0;

            string query = @"
                SELECT COUNT(*)
                FROM Courses
                WHERE Periodicity = 'Еженедельно' AND IsActive = 1;";

            var connection = _dataBase.getConnection();
            {
                SqlCommand command = new SqlCommand(query, connection);
                count = (int)command.ExecuteScalar();
                connection.Close();
            }

            return count;
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                // Перехватываем ошибку
                if (e.Exception != null)
                {
                    string errorMessage = "Ошибка при вводе данных. ";

                    // Определяем тип ошибки и выводим сообщение
                    if (e.Exception is FormatException)
                    {
                        errorMessage += "Неверный формат данных.";
                    }
                    else
                    {
                        errorMessage += e.Exception.Message;
                    }

                    MessageBox.Show(errorMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при обработке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LoadCourseData();
            }
        }

        private void btn_deleteCourse_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите строку для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите удалить эту запись? Это может повлиять на связанные данные в других таблицах.",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                // Получаем ID записи, которую нужно удалить
                long selectedRowId = Convert.ToInt64(dataGridView1.SelectedRows[0].Cells["Код"].Value);

                // Удаляем из базы данных
                DeleteRecordAndRelatedData(selectedRowId);
                LoadCourseData();

                MessageBox.Show("Запись успешно удалена.", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteRecordAndRelatedData(long recordId)
        {
            var connection = _dataBase.getConnection();
            {
                var transaction = connection.BeginTransaction();
                {
                    try
                    {
                        string deleteFromRelatedTable = @"
                            DELETE FROM CourseTeachers WHERE CourseId = @CourseId;
                            DELETE FROM GroupSchedules WHERE CourseId = @CourseId;
                            DELETE FROM CourseCosts WHERE CourseId = @CourseId;
                ";

                        SqlCommand deleteCommand = new SqlCommand(deleteFromRelatedTable, connection, transaction);
                        deleteCommand.Parameters.AddWithValue("@CourseId", recordId);
                        deleteCommand.ExecuteNonQuery();

                        string deleteCourseQuery = "DELETE FROM Courses WHERE Id = @CourseId";
                        SqlCommand deleteCourseCommand = new SqlCommand(deleteCourseQuery, connection, transaction);
                        deleteCourseCommand.Parameters.AddWithValue("@CourseId", recordId);
                        deleteCourseCommand.ExecuteNonQuery();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Ошибка при удалении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            connection.Close();
        }

        private void btn_refreshCourses_Click(object sender, EventArgs e)
        {
            LoadCourseData();
        }
    }
}