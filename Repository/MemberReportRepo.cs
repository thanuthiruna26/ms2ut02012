using Microsoft.Data.Sqlite;
using WebApplication1.Database;

namespace WebApplication1.Repository
{
    public class MemberReportRepo: IMemberReportRepo
    {
        private readonly string _connectionString;

        public MemberReportRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<MemberReport> GetAll()
        {
            var membersReport = new List<MemberReport>();

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT MemberId,Name,NICNumber,RegistrationDate FROM MemberReport";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        membersReport.Add(new MemberReport
                        {
                            MemberId = reader.GetInt32(1),
                            Name = reader.GetString(2),
                            NICNumber = reader.GetDataTypeName(3),
                            RegistrationDate = reader.GetDateTime(4)
                        });
                    }
                }
            }
            return membersReport;
        }
        public MemberReport GetById(int MemberId)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT MemberId, Name , NICNumber,RegistrationDate FROM MemberReport WHERE MemberId = @MemberId";
                command.Parameters.AddWithValue("@MemberId", MemberId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new MemberReport
                        {
                            MemberId = reader.GetInt32(1),
                            Name = reader.GetString(2),
                            NICNumber = reader.GetDataTypeName(3),
                            RegistrationDate = reader.GetDateTime(4)
                       

                    };
                    }
                }
            }
            return null;
        }

        public void Add(MemberReport memberReport)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO MemberReport (Name,NICNumber,RegistrationDate) VALUES (@Name,@NICNumber,@RegistrationDate)";
                command.Parameters.AddWithValue("@Name", memberReport.Name);
                command.Parameters.AddWithValue("@NICNumber", memberReport.NICNumber);
                command.Parameters.AddWithValue("@PhoneNumber", memberReport.RegistrationDate);


                command.ExecuteNonQuery();
            }
        }


        public void Update(MemberReport memberReport)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE MemberReport SET Name = @Name,NICNumber = @NICNumber , RegistrationDate = @RegistrationDate  WHERE MemberId = @Memberd";
                command.Parameters.AddWithValue("@MemberId", memberReport.MemberId);
                command.Parameters.AddWithValue("@Name", memberReport.Name);
                command.Parameters.AddWithValue("@NICNumber", memberReport.NICNumber);
                command.Parameters.AddWithValue("@RegistrationDate", memberReport.RegistrationDate);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int MemberId)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM MemberReport WHERE MemberId = @MemberId";
                command.Parameters.AddWithValue("@MemberId", MemberId);
                command.ExecuteNonQuery();
            }
        }
    }
}
