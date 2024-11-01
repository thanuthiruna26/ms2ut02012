using Microsoft.Data.Sqlite;

namespace WebApplication1.Data
{
    public class Databaseinitializer
    {
        private readonly string _connectionstring;

        public Databaseinitializer(string connectionstring)
        {
            _connectionstring = connectionstring;
        }

        public void Initialize()
        {
            Console.WriteLine("Running DatabaseInitializer Initialize Fuction...");
            using (var connection = new SqliteConnection(_connectionstring))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS BookCategories (
                        CategoryId INTEGER PRIMARY KEY,
                        CategoryName TEXT NOT NULL
                       
                    );

           

                    CREATE TABLE IF NOT EXISTS Members (
                                   MemberId INTEGER PRIMARY KEY,
                    NICNumber INT NOT NULL,
                    Name TEXT NOT NULL,
                    Email TEXT NOT NULL,
                    PhoneNumber INT NOT NULL
            );



                   

                    -- Insert sample data if tables are empty
                    INSERT OR IGNORE INTO BookCategories (CategoryId, CategoryName) VALUES
                    (1, 'Story'),
                    (2, 'Novel'),
                    (3, 'Story');

                    --Insert sample data if tables are empty
                    INSERT OR IGNORE INTO Members (MemberId, NICNumber, Name, Email, PhoneNumber) VALUES
                    (1, 200248578444,'Helana','helana@gmail.com',0764488379),
                    (2, 200248574444, 'Regon', 'regon@gmail.com', 0764488374),
                    (3, 200248545444, 'Melaty', 'melaty@gmail.com', 0764438374);

 
                   



                

                ";
                command.ExecuteNonQuery();
            }
        }
    }
}
