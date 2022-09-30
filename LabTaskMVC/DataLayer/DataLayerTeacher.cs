using LabTaskMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace LabTaskMVC.DataLayer
{
    public class DataLayerTeacher
    {
        private static SqlConnection SqlConnection;
        private static SqlCommand SqlCommand;
        private SqlDataAdapter SqlDataAdapter;
        private DataTable DataTable = new DataTable();

        public DataLayerTeacher()
        {
            string Connection = "Data Source=DESKTOP-5ERLRKC;Initial Catalog=LabTaskMvc;Integrated Security=True";//"User ID=sa;Password=Alaska@123;";
            SqlConnection = new SqlConnection(Connection);
            SqlConnection.Open();
        }
        public List<Teacher> GetAll()
        {
            List<Teacher> list = new List<Teacher>();
            SqlCommand = new SqlCommand("Select * from Teacher", SqlConnection);
            SqlDataAdapter = new SqlDataAdapter(SqlCommand);
            SqlDataAdapter.Fill(DataTable);
            SqlCommand.Dispose();
            SqlConnection.Close();
            foreach (DataRow dr in DataTable.Rows)
            {
                list.Add(new Teacher
                {
                    TId = Convert.ToInt32(dr["TId"]),
                    TName = Convert.ToString(dr["TName"]),
                    TAge = Convert.ToInt32(dr["TAge"]),
                   // ClassId = Convert.ToInt32(dr["ClassId"])
                });
            }
            return list;
        }
        public Teacher GetById(int Id)
        {
            var Teacher1 = new Teacher();
            SqlCommand = new SqlCommand("Select * from Teacher where TId = " + Id, SqlConnection);
            SqlDataAdapter = new SqlDataAdapter(SqlCommand);
            SqlDataAdapter.Fill(DataTable);
            SqlCommand.Dispose();
            SqlConnection.Close();

            var dtRow = DataTable.Rows[0];

            Teacher1.TId = Convert.ToInt32(dtRow[0]);
            Teacher1.TName = Convert.ToString(dtRow[1]);
            Teacher1.TAge = Convert.ToInt32(dtRow[2]);
            //Teacher1.ClassId = Convert.ToInt32(dtRow[3]);

            return Teacher1;
        }
        public void Create(Teacher TModel)
        {
            var std = new Teacher();

            TModel.TName = Convert.ToString(TModel.TName);
            TModel.TAge = Convert.ToInt32(TModel.TAge);
           // TModel.ClassId = Convert.ToInt32(TModel.ClassId);


            SqlCommand = new SqlCommand("Insert into Teacher (TName,TAge) values('" + TModel.TName + "','" + TModel.TAge + "')", SqlConnection);
            SqlCommand.ExecuteNonQuery();

            SqlCommand.Dispose();
            SqlConnection.Close();
        }
        public void Update1(int id, Teacher TModel)
        {
            TModel.TName = Convert.ToString(TModel.TName);
            TModel.TAge = Convert.ToInt32(TModel.TAge);
            //TModel.ClassId = Convert.ToInt32(TModel.ClassId);

            SqlCommand = new SqlCommand("Update Teacher set TName ='" + TModel.TName + "' ,TAge = '" + TModel.TAge + "' where TId =" + id, SqlConnection);

            SqlCommand.ExecuteNonQuery();
            SqlCommand.Dispose();
            SqlConnection.Close();
        }
        public void Delete(int Id)
        {
            SqlCommand = new SqlCommand("Delete from Teacher where TId = " + Id, SqlConnection);
            SqlCommand.ExecuteNonQuery();
            SqlCommand.Dispose();
            SqlConnection.Close();
        }


    }
}