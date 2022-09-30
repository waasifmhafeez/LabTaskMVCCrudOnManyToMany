using LabTaskMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace LabTaskMVC.DataLayer
{
    public class DataLayerStudent
    {

        private static SqlConnection SqlConnection;
        private static SqlCommand SqlCommand;
        private SqlDataAdapter SqlDataAdapter;
        private DataTable DataTable = new DataTable();

        public DataLayerStudent()
        {
            string Connection = "Data Source=DESKTOP-5ERLRKC;Initial Catalog=LabTaskMvc;Integrated Security=True";//"User ID=sa;Password=Alaska@123;";
            SqlConnection = new SqlConnection(Connection);
            SqlConnection.Open();
        }
        public List<Student> GetAll()
        {
            List<Student> list = new List<Student>();
            SqlCommand = new SqlCommand("Select * from Student", SqlConnection);
            SqlDataAdapter = new SqlDataAdapter(SqlCommand);
            SqlDataAdapter.Fill(DataTable);
            SqlCommand.Dispose();
            SqlConnection.Close();
            foreach (DataRow dr in DataTable.Rows)
            {
                list.Add(new Student
                {
                    StdId = Convert.ToInt32(dr["StdId"]),
                    StdName = Convert.ToString(dr["StdName"]),
                    StdAge = Convert.ToInt32(dr["StdAge"]),
                   // ClassId = Convert.ToInt32(dr["ClassId"])
                });
            }
            return list;
        }
        public Student GetById(int Id)
        {
            var Student1 = new Student();
            SqlCommand = new SqlCommand("Select * from Student where StdId = " + Id, SqlConnection);
            SqlDataAdapter = new SqlDataAdapter(SqlCommand);
            SqlDataAdapter.Fill(DataTable);
            SqlCommand.Dispose();
            SqlConnection.Close();

            var dtRow = DataTable.Rows[0];

            Student1.StdId = Convert.ToInt32(dtRow[0]);
            Student1.StdName = Convert.ToString(dtRow[1]);
            Student1.StdAge = Convert.ToInt32(dtRow[2]);
            // Student1.ClassId = Convert.ToInt32(dtRow[3]);

            return Student1;
        }
        public void Create(Student StdModel)
        {
            var std = new Student();

            StdModel.StdName = Convert.ToString(StdModel.StdName);
            StdModel.StdAge = Convert.ToInt32(StdModel.StdAge);
            // StdModel.ClassId = Convert.ToInt32(StdModel.ClassId);


            SqlCommand = new SqlCommand("Insert into Student (StdName,StdAge) values('" + StdModel.StdName + "','" + StdModel.StdAge + "')", SqlConnection);
            SqlCommand.ExecuteNonQuery();

            SqlCommand.Dispose();
            SqlConnection.Close();
        }
        public void Update1(int id, Student StdModel)
        {
            StdModel.StdName = Convert.ToString(StdModel.StdName);
            StdModel.StdAge = Convert.ToInt32(StdModel.StdAge);
            //  StdModel.ClassId = Convert.ToInt32(StdModel.ClassId);

            SqlCommand = new SqlCommand("Update Student set StdName ='" + StdModel.StdName + "' ,StdAge = '" + StdModel.StdAge + "' where StdId =" + id, SqlConnection);

            SqlCommand.ExecuteNonQuery();
            SqlCommand.Dispose();
            SqlConnection.Close();
        }
        public void Delete(int Id)
        {
            SqlCommand = new SqlCommand("Delete from Student where StdId = " + Id, SqlConnection);
            SqlCommand.ExecuteNonQuery();
            SqlCommand.Dispose();
            SqlConnection.Close();
        }
    }

}
