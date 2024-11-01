using Microsoft.Data.Sqlite;
using WebApplication1.Database;

namespace WebApplication1.Repository
{
    public class MembersRepo:IMembersRepo
    {
        private readonly string _connectionString;

        public MembersRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Members> GetAll()
        {
            var members = new List<Members>();

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT MemberId,NICNumber,Name,Email,PhoneNumber FROM Members";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        members.Add(new Members
                        {
                            MemberId = reader.GetInt32(0),
                            NICNumber = reader.GetDataTypeName(0),
                            Name = reader.GetString(1),
                            Email = reader.GetString(2),
                            PhoneNumber = reader.GetString(3),
                        });
                    }
                }
            }
            return members;
        }
        public Members GetById(int MemberId)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT MemberId, Name FROM Members WHERE MemberId = @MemberId";
                command.Parameters.AddWithValue("@MemberId", MemberId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Members
                        {
                            MemberId = reader.GetInt32(0),
                            NICNumber = reader.GetDataTypeName(0),
                            Name = reader.GetString(1),
                            Email = reader.GetString(2),
                            PhoneNumber = reader.GetString(3)

                        };
                    }
                }
            }
            return null;
        }

        public void Add(Members members)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Members (NICNumber,Name,Email,PhoneNumber) VALUES (@NICNumber,@Name,@Email,@PhoneNumber)";
                command.Parameters.AddWithValue("@NICNumber", members.NICNumber);
                command.Parameters.AddWithValue("@Name", members.Name);
                command.Parameters.AddWithValue("@Email", members.Email);
                command.Parameters.AddWithValue("@PhoneNumber", members.PhoneNumber);
              

                command.ExecuteNonQuery();
            }
        }
        

        public void Update(Members members)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE Members SET NICNumber = @NICNumber, Name = @CategoryName,Email = @Email,PhoneNumber = @PhoneNumber  WHERE MemberId = @Memberd";
                command.Parameters.AddWithValue("@MemberId", members.MemberId);
                command.Parameters.AddWithValue("@NICNumber", members.NICNumber);
                command.Parameters.AddWithValue("@Name", members.Name);
                command.Parameters.AddWithValue("@Email", members.Email);
                command.Parameters.AddWithValue("@PhoneNumber", members.PhoneNumber);


                command.ExecuteNonQuery();
            }
        }

        public void Delete(int MemberId)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Members WHERE MemberId = @MemberId";
                command.Parameters.AddWithValue("@MemberId", MemberId);
                command.ExecuteNonQuery();
            }
        }
        }
}
