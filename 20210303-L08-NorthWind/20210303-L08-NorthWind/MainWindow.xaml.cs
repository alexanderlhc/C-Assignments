using _20210303_L08_NorthWind.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _20210303_L08_NorthWind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> _countries;
        public MainWindow()
        {
            InitializeComponent();
            Trace.WriteLine(GetAverageFreight());
            _countries = GetCountries();

            initGui();
        }

        private void initGui()
        {
            cbCountries.ItemsSource = _countries;
            cbCountries.SelectedIndex = 1;
            UpdateCostumers((string)cbCountries.SelectedItem);
        }

        private void UpdateCostumers(string country) => lwEmployees.ItemsSource = GetEmployees(country);

        private string GetAverageFreight()
        {
            decimal average1; // from sql

            // Ex12.1
            string query = "SELECT AVG(Freight) AS 'Average Freight' FROM Orders;";
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                IDataRecord record = (IDataRecord)reader;
                average1 = (decimal)record[0];
            }

            // Ex12.2 ??
            query = "SELECT Freight FROM Orders;";
            decimal average2;
            decimal sum = 0;
            DataTable tblOrders = new DataTable();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter da = new SqlDataAdapter(command))
            {
                connection.Open();

                da.Fill(tblOrders);

                foreach (DataRow orderRow in tblOrders.Rows)
                {
                    sum += (decimal)orderRow["Freight"];
                }

                average2 = sum / tblOrders.Rows.Count;
            }


            return $"Query: {average1}\nForeach: {average2}";

        }

        private List<string> GetCountries()
        {
            List<string> countries = new List<string>();
            string query = "SELECT DISTINCT Country FROM Customers;";

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        countries.Add((string)reader["Country"]);
                }
            }

            return countries;
        }

        private List<String> GetEmployees(string Country)
        {
            List<string> employees = new List<string>();
            string query = $"SELECT ContactName, City FROM Customers WHERE Country = '{Country}';";

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        employees.Add(String.Format(
                            "{0, -15} - {1}",
                            (string)reader["ContactName"], (string)reader["City"]));
                }
            }

            
            return employees;
        }

        private void cbCountries_SelectionChanged(object sender, SelectionChangedEventArgs e) => UpdateCostumers((string)cbCountries.SelectedItem);
    }
}
