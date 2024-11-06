using System.Data;
using BlazorAutoRenderingApp.Models;
using Microsoft.Data.SqlClient;

namespace BlazorAutoRenderingApp.DAL
{
	public class Student_DAL
	{
		SqlConnection _connection = null;
		SqlCommand _command = null;
		public static IConfiguration configuration { get; set; }

		private string GetConnectionString()
		{
			var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
			configuration = builder.Build();
			return configuration.GetConnectionString("BlazorAutoRenderingAppContext")!;
		}

		public List<Student> GetStudents()
		{
			List<Student> students = new List<Student>();
			using (_connection = new SqlConnection(GetConnectionString()))
			{
				_command = _connection.CreateCommand();
				_command.CommandType = CommandType.StoredProcedure;
				_command.CommandText = "[DBO].[usp_Get_Students]";
				_connection.Open();
				SqlDataReader reader = _command.ExecuteReader();
				while (reader.Read())
				{
					Student student = new Student();
					student.Id = Convert.ToInt32(reader["Id"]);
					student.Name = reader["Name"].ToString();
					student.Age = Convert.ToInt32(reader["Age"]);
					student.Birthday = Convert.ToDateTime(reader["Birthday"]);
					students.Add(student);
				}
				_connection.Close();
			}
			return students;
		}

		public bool Insert(Student student)
		{
			int id = 0;
			using (_connection = new SqlConnection(GetConnectionString()))
			{
				_command = _connection.CreateCommand();
				_command.CommandType = CommandType.StoredProcedure;
				_command.CommandText = "[DBO].[usp_Insert_Student]";
				_command.Parameters.AddWithValue("@Name", student.Name);
				_command.Parameters.AddWithValue("@Age", student.Age);
				_command.Parameters.AddWithValue("@Birthday", student.Birthday);
				_connection.Open();
				id = _command.ExecuteNonQuery();
				_connection.Close();
			}
			return id > 0 ? true : false;

		}

		public Student GetStudentById(int Id)
		{
			Student student = new Student();
			using (_connection = new SqlConnection(GetConnectionString()))
			{
				_command = _connection.CreateCommand();
				_command.CommandType = CommandType.StoredProcedure;
				_command.CommandText = "[DBO].[usp_Get_StudentById]";
				_command.Parameters.AddWithValue("@Id", Id);
				_connection.Open();
				SqlDataReader reader = _command.ExecuteReader();
				while (reader.Read())
				{
					student.Id = Convert.ToInt32(reader["Id"]);
					student.Name = reader["Name"].ToString();
					student.Age = Convert.ToInt32(reader["Age"]);
					student.Birthday = Convert.ToDateTime(reader["Birthday"]);
				}
				_connection.Close();
			}
			return student;
		}

		public bool Update(Student student)
		{
			int id = 0;
			using (_connection = new SqlConnection(GetConnectionString()))
			{
				_command = _connection.CreateCommand();
				_command.CommandType = CommandType.StoredProcedure;
				_command.CommandText = "[DBO].[usp_Update_Student]";
				_command.Parameters.AddWithValue("@Id", student.Id);
				_command.Parameters.AddWithValue("@Name", student.Name);
				_command.Parameters.AddWithValue("@Age", student.Age);
				_command.Parameters.AddWithValue("@Birthday", student.Birthday);
				_connection.Open();
				id = _command.ExecuteNonQuery();
				_connection.Close();
			}
			return id > 0 ? true : false;

		}

		public bool Delete(int Id)
		{
			int deletedRowCount = 0;
			using (_connection = new SqlConnection(GetConnectionString()))
			{
				_command = _connection.CreateCommand();
				_command.CommandType = CommandType.StoredProcedure;
				_command.CommandText = "[DBO].[usp_Delete_Student]";
				_command.Parameters.AddWithValue("@Id", Id);
				_connection.Open();
				deletedRowCount = _command.ExecuteNonQuery();
				_connection.Close();
			}
			return deletedRowCount > 0 ? true : false;

		}

	}
}
