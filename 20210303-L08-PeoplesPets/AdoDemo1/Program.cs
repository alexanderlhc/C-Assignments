using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDemo1 {


    /*
     * 
     * Using
     * Properties.Settings.Default.connString
     * SqlConnection
     * SqlCommand
     * SqlDataReader
     * IDataRecord
     * 
     */
    public class DBReader1 {
        // The simplest possible way to do ADO
        public DBReader1() {
            ReadData(Properties.Settings.Default.connString);
        }

        private void ReadData(string connectionString) {
            string queryString = "SELECT * FROM Persons";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            IDataRecord record = (IDataRecord)reader;

                            for (int i = 0; i < record.FieldCount; ++i)
                            {
                                Console.WriteLine(String.Format("{0}, {1}, {2}", record.GetDataTypeName(i), record.GetName(i), record[i])); // record[i].GetType()
                            }

                            int id = (int)record[0];
                            string name = (string)record[1];
                            int age = (int)record[2];
                            int weight = (int)record[3];
                            int score = (int)record[4];

                            // Do stuff with data
                        }
                    }
                }
            }
        }
    }

    /*
     * Using
     * DataTable
     * 
     */
    public class DBReader2 {

        public DBReader2() {
            ReadData(Properties.Settings.Default.connString);
        }

        public void ReadData(string connectionString) {
            string query = "SELECT * FROM Persons";

            DataTable dataTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        // this will query your database and return the result to your datatable
                        da.Fill(dataTable);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            int id = (int)row["ID"];
                            string name = (string)row["Name"];
                            int age = (int)row["Age"];
                            int weight = (int)row["Weight"];
                            int score = (int)row["Score"];

                            Console.WriteLine($"ID={id},Name={name},Age={age},Weight={weight},Score={score}");
                        }

                        // Using LINQ
                        var q = from row in dataTable.AsEnumerable()
                                where row.Field<int>("Age") > 40
                                select new
                                {
                                    ID = row.Field<int>("ID"),
                                    Name = row.Field<string>("Name"),
                                };
                        foreach (var obj in q)
                            Console.WriteLine($"ID={obj.ID}, Name={obj.Name}");

                    }
                }
            }
        }
    }

    public class DBReader3 {

        public DBReader3() {
            ReadData(Properties.Settings.Default.connString);
        }

        public void ReadData(string connectionString) {
            string query = "SELECT * FROM Persons";

            //DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataSet dataSet = new DataSet("Persons");
                        da.Fill(dataSet);
                        for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                            Console.WriteLine(dataSet.Tables[0].Rows[i]["Name"].ToString());

                        string tableName = dataSet.Tables[0].TableName;
                        DataTable table = dataSet.Tables["Table"];
                        foreach (DataRow row in table.Rows)
                        {
                            int id = (int)row["ID"];
                            string name = (string)row["Name"];
                            int age = (int)row["Age"];
                            int weight = (int)row["Weight"];
                            int score = (int)row["Score"];

                            // Do lots of funny stuff with dataTable
                        }

                        var q = from row in table.AsEnumerable()
                                where row.Field<int>("Age") > 40
                                select new
                                {
                                    ID = row.Field<int>("ID"),
                                    Name = row.Field<string>("Name"),
                                };
                        foreach (var obj in q)
                            Console.WriteLine($"ID={obj.ID}, Name={obj.Name}");
                    }
                }
            }
        }
    }

    // SELECT Persons.ID, Persons.Name, Pets.Name FROM Persons
    // INNER JOIN Pets ON Persons.ID = Pets.owner_id;
    public class DBReader4 {

        public DBReader4() {
            ReadData(Properties.Settings.Default.connString);
        }

        public void ReadData(string connectionString) {
            string query = "SELECT Persons.Name, Pets.Name FROM Persons INNER JOIN Pets ON Persons.ID = Pets.owner_id";

            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows) {
                var c0 = row.Table.Columns[0].ColumnName;
                var c1 = row.Table.Columns[1].ColumnName;

                var PersonName = (string)row[c0];
                var PetName = (string)row[c1];

                Console.WriteLine($"PersonName={PersonName}, PetName={PetName}");

                // Do lots of funny stuff with dataTable
            }

            //// Using LINQ
            //var q = from row in dataTable.AsEnumerable()
            //        where row.Field<int>("ID") >= 1
            //        select new {
            //            Name = row.Field<string>(1),
            //            Pet = row.Field<string>(2),
            //        };
            //foreach (var obj in q)
            //    Console.WriteLine($"Name={obj.Name}, Pet={obj.Pet}");

            conn.Close();
            da.Dispose();
        }
    }

    public class DBWriter5 {

        public DBWriter5() {
            WriteData1(Properties.Settings.Default.connString);
            WriteData2(Properties.Settings.Default.connString);
            WriteData3(Properties.Settings.Default.connString);
            WriteData4(Properties.Settings.Default.connString);
        }

        public void WriteData1(string connectionString) {

            string query = "INSERT INTO Persons (ID,Name,Age,Weight,Score) VALUES (21,'Anton',34,64,8)";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        }

        public void WriteData2(string connectionString) {

            string query = "INSERT INTO Persons (ID,Name,Age,Weight,Score) VALUES (@ID,@Name,@Age,@Weight,@Score)";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand(query, connection)) {

                    command.Parameters.Add("@ID", SqlDbType.Int).Value = 22;
                    command.Parameters.Add("@Name", SqlDbType.VarChar, 250).Value = "Anton";
                    command.Parameters.Add("@Age", SqlDbType.Int).Value = 34;
                    command.Parameters.Add("@Weight", SqlDbType.Int).Value = 64;
                    command.Parameters.Add("@Score", SqlDbType.Int).Value = 8;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }


            //--DELETE FROM Persons WHERE ID = 21;
            //--UPDATE Pets SET Weight = 24 WHERE Name = 'Garfield';

        }

        public void WriteData3(string connectionString) {

            string query = "DELETE FROM Persons WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.Add("@ID", SqlDbType.Int).Value = 22;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void WriteData4(string connectionString) {

            string query = "UPDATE Persons SET Age = 39 WHERE ID = 21";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }


    public class DbEx3Reader {

        public DbEx3Reader() {
            ReadData(Properties.Settings.Default.connString);
        }

        private void ReadData(string connectionString) {
            string queryString = "SELECT TOP 5 * FROM Persons";
            DataTable tblPeople = new DataTable();


            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(queryString, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                adapter.Fill(tblPeople);
            }


            foreach(DataRow row in tblPeople.Rows)
            {

                string output = String.Format("ID = {0, -10}, Name = {1, -15}, {2, 10} points, {3, 10} years, {4, 5} kg",
                    row[row.Table.Columns[0]],
                    row[row.Table.Columns[1]],
                    row[row.Table.Columns[2]],
                    row[row.Table.Columns[3]],
                    row[row.Table.Columns[4]]
                );
                Console.WriteLine(output);
            }

        }
    }
    public class DbEx4Reader {
        private string _connectionString;

        public DbEx4Reader() {
            _connectionString = Properties.Settings.Default.connString;
            ReadData();
        }

        private void ReadData() {
            string query =
            "SELECT Owner.ID, Owner.Name, Pet.ID AS 'PetId', Pet.Name AS 'PetName'"+
                "FROM Pets AS Pet "+
             "INNER JOIN " +
                "Persons AS Owner ON Pet.owner_id = Owner.ID";
            DataTable tbl = getDataTable(query);

            foreach(var row in tbl.AsEnumerable())
            {
                foreach(var item in row.ItemArray)
                    Console.Write(String.Format("{0,15}", item));

                Console.WriteLine("");
                //Console.WriteLine(te.Field<string>("Name"));
            }

        }

        private DataTable getDataTable(string query)
        {
            DataTable result = new DataTable();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                adapter.Fill(result);
            }

            return result;
        }
    }

    public class DbEx5Reader {
        private string _connectionString;

        public DbEx5Reader() {
            _connectionString = Properties.Settings.Default.connString;
            ReadData();
        }

        private void ReadData() {
            string query =
            "SELECT Persons.ID, Persons.Name, Persons.Score FROM Persons " +
            "INNER JOIN Pets ON Persons.ID = Pets.ID " +
            "ORDER BY Persons.Score DESC; ";
            DataTable tbl = getDataTable(query);

            foreach(var row in tbl.AsEnumerable())
            {
                foreach(var item in row.ItemArray)
                    Console.Write(String.Format("{0,15}", item));

                Console.WriteLine("");
                //Console.WriteLine(te.Field<string>("Name"));
            }

        }

        private DataTable getDataTable(string query)
        {
            DataTable result = new DataTable();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                adapter.Fill(result);
            }

            return result;
        }
    }

    public class DbEx6Reader {
        private string _connectionString;

        public DbEx6Reader() {
            _connectionString = Properties.Settings.Default.connString;
            ReadData();
        }

        private void ReadData() {
            string query = "UPDATE Pets SET Weight=25 WHERE Name='Garfield'";

            using(SqlConnection connection = new SqlConnection(_connectionString))
            using(SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }

        }

    }

    public class Ex7Insert
    {
        private string _connectionString;

        public Ex7Insert() {
            _connectionString = Properties.Settings.Default.connString;
            int edisonId = GetIdByName("Edison");
            InsertPet(7, edisonId, "Alfred", 1, 1, "Cat");
        }

        private int GetIdByName(string name)
        {
            int id = -1;

            string query = String.Format("SELECT ID FROM Persons WHERE Name = '{0}';", name);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))    
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                id = (int)((IDataRecord)reader)[0];
            }

            return id;
        }

        private void InsertPet(int id, int owner_id, string Name, int Age, int Weight, string Species)
        {
            string query = String.Format(
                "INSERT INTO Pets(ID, owner_id, Name, Age, Weight, Species) VALUES({0},{1},'{2}',{3},{4},'{5}');",
                id, owner_id, Name, Age, Weight, Species);

            using(SqlConnection connection = new SqlConnection(_connectionString))
            using(SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

    public class Ex8Delete
    {
        private string _connectionString;

        public Ex8Delete() {
            _connectionString = Properties.Settings.Default.connString;
            int wyattId = GetIdByName("Wyatt");
            DeletePersonById(wyattId);
        }

        private int GetIdByName(string name)
        {
            int id = -1;

            string query = String.Format("SELECT ID FROM Persons WHERE Name = '{0}';", name);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))    
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                id = (int)((IDataRecord)reader)[0];
            }

            return id;
        }

        private void DeletePersonById(int id)
        {
            string query = String.Format(
                "DELETE FROM Persons WHERE ID = {0}",
                id);

            using(SqlConnection connection = new SqlConnection(_connectionString))
            using(SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

    public class Ex9JoinBYLINQ
    {
        private string _connectionString;

        public Ex9JoinBYLINQ() {
            _connectionString = Properties.Settings.Default.connString;
            PrintAllPeopleAndPets(getDataTable("SELECT * FROM Persons;"), getDataTable("SELECT * FROM Pets;"));
        }

        private void PrintAllPeopleAndPets(DataTable people, DataTable pets)
        {
            var peopleWithPets = from person in people.AsEnumerable()
                                 join pet in pets.AsEnumerable()
                                 on person.Field<int>("ID") equals pet.Field<int>("owner_id")
                                 select new
                                 {
                                    id = person.Field<int>("id"),
                                    name = person.Field<string>("name"),
                                    petid = pet.Field<int>("id"),
                                    petname = pet.Field<string>("name")
                                 };

            foreach(var pwp in peopleWithPets)
            {
                Console.WriteLine($"{pwp.id}   {pwp.name}    {pwp.petid}   {pwp.petname}");
            }
        }
        private DataTable getDataTable(string query)
        {
            DataTable result = new DataTable();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                adapter.Fill(result);
            }

            return result;
        }
    }

class Program
{

    static void Main(string[] args)
    {
        Console.WriteLine("connString : " + Properties.Settings.Default.connString);

        //Console.WriteLine("Running DBReader1");
        //var reader1 = new DBReader1();

        //Console.WriteLine("Running DBReader2");
        //var reader2 = new DBReader2();

        //Console.WriteLine("Running DBReader3");
        //var reader3 = new DBReader3();

        //Console.WriteLine("Running DBReader4");
        //var reader4 = new DBReader4();

        //Console.WriteLine("Running DBWriter5");
        //var writer5 = new DBWriter5();

        //Console.WriteLine("Exercise 3: Load People");
        //var ex3Reader = new DbEx3Reader();

        //Console.WriteLine("Exercise 4: Load People");
        //var ex4Reader = new DbEx4Reader();

        //Console.WriteLine("Exercise 5: Load People");
        //var ex5Reader = new DbEx5Reader();

        //Console.WriteLine("Exercise 6: Update Garfields Weight");
        //var ex6Reader = new DbEx6Reader();

        //Console.WriteLine("Exercise 7: Edison find kitten Alfred");
        //var ex7Insert = new Ex7Insert();

        //Console.WriteLine("Exercise 8: Delete Wyatt");
        //var ex8Delete = new Ex8Delete();

        Console.WriteLine("Exercise 9: Join by LINQ");
        var ex9JoinBYLINQ = new Ex9JoinBYLINQ();

        Console.ReadKey();
    }

}
}
