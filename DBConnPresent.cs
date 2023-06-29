using crud.Models;
using Microsoft.AspNetCore.Components.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1.Models
{
    public class DBConnPresent
    {

        string con = @"Data Source= DESKTOP-HA2IOGN\SQLEXPRESS01;Initial Catalog=Crud;Integrated Security=True";
        #region "Employee All Record Show"
        //GET Method Method
        public List<employee> GetAllStudents()
        {
            SqlConnection sqlConnection = new SqlConnection(con);
            SqlCommand cm = new SqlCommand("select * from Employee", sqlConnection);

            DataSet dt = new DataSet();
            List<employee> emp = new List<employee>();
            SqlDataAdapter adapter = new SqlDataAdapter(cm);
            //adapter.SelectCommand.Parameters.AddWithValue("@id", id);

            adapter.Fill(dt);


            foreach (DataRow pRow in dt.Tables[0].Rows)
            {
                employee obj = new employee();
                obj.ID= pRow.Field<Int32>("ID");
                obj.Name= pRow.Field<string>("Name");
                obj.Email= pRow.Field<string>("Email");
                obj.Mobile= pRow.Field<string>("Mobile");
                
                emp.Add(obj);
            }
            return emp;

        }
        #endregion
        #region "Studant Data Insert"
        //Insert Method
        public bool InsertVAlue(employee Emp)
        {

            int retValue = 0;
            using (SqlConnection sqlConnection = new SqlConnection(con))
            {
                string Query = "insert into employee (Name,Email,Mobile) values('"+Emp.Name+"','"+Emp.Email+"','"+Emp.Mobile+"')";

                SqlCommand cm = new SqlCommand(Query, sqlConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cm);
                 retValue = cm.ExecuteNonQuery();
                ////adapter.SelectCommand.Parameters.AddWithValue("@Name", emp.Name);
                //DataSet dataSet = new DataSet();
                //// SqlDataReader sdr = cm.ExecuteReader();
                //adapter.Fill(dataSet);
                sqlConnection.Close();
            }
            if (retValue==1)
            {
            return true;
            }
            else
            {
            return false;
            }
        }
        #endregion
        #region "Employee Data Update"

        public bool UpdateEmployeeRecord(employee Emp)
        {
            int retValue = 0;
            using (SqlConnection sqlConnection = new SqlConnection(con))
            {
                sqlConnection.Open();
                string Query = "update Employee set Name='"+Emp.Name+"',Email='"+Emp.Email+"',Mobile='"+Emp.Mobile+"' where ID="+Emp.ID+"";
                SqlCommand cm = new SqlCommand(Query, sqlConnection);

                SqlDataAdapter adapter = new SqlDataAdapter(cm);
              retValue = cm.ExecuteNonQuery();
                //adapter.SelectCommand.Parameters.AddWithValue("@Present_st", Emp.Present_st);
                //adapter.SelectCommand.Parameters.AddWithValue("@Id", Emp.Id);
                sqlConnection.Close();
            }
            //DataSet dataSet = new DataSet();
            //// SqlDataReader sdr = cm.ExecuteReader();
            //adapter.Fill(dataSet);
            ////Employee obj = new Employee();

            if (retValue==1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        #endregion  
        #region "Employee Data Delete"

        public bool Delete(int id)
        {
            int retValue = 0;
            using (SqlConnection sqlConnection = new SqlConnection(con))
            {
                string Query = "delete from  Employee  where ID="+id+"";
                SqlCommand cm = new SqlCommand(Query, sqlConnection);

                SqlDataAdapter adapter = new SqlDataAdapter(cm);
                retValue = cm.ExecuteNonQuery();
                //adapter.InsertCommand = cm;
                //adapter.SelectCommand.Parameters.AddWithValue("@Present_st", Emp.Present_st);
                //adapter.SelectCommand.Parameters.AddWithValue("@Id", Emp.Id);

                //DataSet dataSet = new DataSet();
                //// SqlDataReader sdr = cm.ExecuteReader();
                //adapter.Fill(dataSet);
                ////Employee obj = new Employee();
                ///     
                sqlConnection.Close();
            }
            if (retValue==1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion
    }
}