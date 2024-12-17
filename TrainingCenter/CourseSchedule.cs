using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TrainingCenter
{
    public partial class CourseSchedule : Form
    {
        public CourseSchedule()
        {
            DataBase dataBase = new DataBase();

            var dataTable = new DataTable();
            string query = "SELECT \r\n    " +
                "FORMAT(StartDate, 'dd.MM.yyyy') AS 'Дата начала',\r\n    " +
                "T.FullName AS 'Преподаватель',\r\n    " +
                "G.SeatsAvailable AS 'Количество мест',\r\n    " +
                "CC.Cost AS 'Стоимость',\r\n    " +
                "CC.TrainingType AS 'Тип обучения'\r\n" +
                "FROM \r\n    " +
                "GroupSchedules G\r\n" +
                "JOIN \r\n    " +
                "Teachers T ON G.TeacherId = T.Id\r\n" +
                "JOIN \r\n    CourseCosts CC ON G.CourseCostId = CC.Id;\r\n";

            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter.SelectCommand = new SqlCommand(query, dataBase.getConnection());
            adapter.Fill(dataTable);

            InitializeComponent();

            dataGridView1.DataSource = dataTable;
        }
    }
}