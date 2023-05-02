using DBLayer; //za repozitorije
using Evaluation_Manager.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation_Manager.Repositories {
    public class StudentRepository {

        public static Student GetStudent(int id) { //static da se more i bez objekta valjda

            Student student = null;
            string sql = $"SELECT * FROM Students WHERE Id = {id}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);

            if (reader.HasRows) {

                reader.Read();
                student = CreateObject(reader);
                reader.Close();
            }
            DB.CloseConnection();
            return student;
        }

        public static List<Student> GetStudents() {

            List<Student> students = new List<Student>();
            string sql = "SELECT * FROM students"; //ne treba $ kad ne prosljeđujemo varijablu

            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);

            while (reader.Read()) {

                Student student = CreateObject(reader);
                students.Add(student);
            }
            reader.Close();
            DB.CloseConnection();

            return students;
        }

    }
}
