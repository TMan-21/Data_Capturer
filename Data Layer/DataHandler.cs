using PRG_Project_Final.Logic_Layer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG_Project_Final.Data_Layer
{
    internal class DataHandler
    {
        string connect = @"Server = .; Initial Catalog = BC_StudentCapture ; Integrated Security = SSPI";
        SqlDataAdapter adapter;
        DataTable dt;

        public DataTable GetStudents()
        {
            string query = @"SELECT * FROM tblStudents";

            adapter = new SqlDataAdapter(query, connect);

            dt = new DataTable();

            adapter.Fill(dt);
            return dt;
        }

        public DataTable GetModules()
        {
            string query = @"SELECT * FROM tblModules";

            adapter = new SqlDataAdapter(query, connect);

            dt = new DataTable();

            adapter.Fill(dt);
            return dt;

        }

        public void Capture(Students student)
        {
            string query = $"INSERT INTO tblStudents VALUES " +
                $"('{student.StuNo}', '{student.Name}','{student.DOB}', '{student.Gender}', '{student.Phone}', '{student.Address}', '{student.Codes}')";

            try
            {
                using (SqlConnection con = new SqlConnection(connect))
                {
                    using (SqlCommand com = new SqlCommand(query, con))
                    {
                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show($"{student.Name} has been Captured");
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void Delete(string stdId)
        {
            string query = $"DELETE FROM tblStudents WHERE StudentNumber = '{stdId}'";
            try
            {
                using (SqlConnection con = new SqlConnection(connect))
                {
                    using (SqlCommand com = new SqlCommand(query, con))
                    {
                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show($"Student: {stdId} has been deleted");
                    }
                }
            }
            catch
            {
                throw;
            }

        }

        public void Update(Students student)
        {
            string query = $"UPDATE tblStudents" +
                $"SET StudentNumber = '{student.StuNo}', StudentName = '{student.Name}', DOB = '{student.DOB}'," +
                $"Gender = '{student.Gender}', Phone = '{student.Phone}', Address_ = '{student.Address}', ModuleCode = '{student.Codes}'" +
                $"WHERE StudentNumber = '{student.StuNo}' ";
            try
            {
                using (SqlConnection con = new SqlConnection(connect))
                {
                    using (SqlCommand com = new SqlCommand(query, con))
                    {
                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show($"Student: {student.StuNo} has been updated");
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public DataTable searchValue(string studentID)
        {
            string query = "SELECT StudentNumber AS [Student Number], StudentName AS [Name and Surname], " +
               "" + "DOB AS [Date of Birth], Gender AS [Gender], Phone AS [Phone], Address_ AS [Address], ModuleCode AS [Code] " +
            $"FROM tblStudents WHERE StudentNumber = '{studentID}'";

            adapter = new SqlDataAdapter(query, connect);
            dt = new DataTable();

            adapter.Fill(dt);

            return dt;
        }
    }
}
