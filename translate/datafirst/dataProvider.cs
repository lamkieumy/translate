using System.Data;
using System.Data.SqlClient;
using System;

namespace translate.datafirst
{
    public class dataProvider{
        private static dataProvider instance;
        public static dataProvider Instance{
            get{if (instance==null) instance= new dataProvider();return dataProvider.Instance;}
            private set {dataProvider.instance= value;}
        }
        private dataProvider(){}
        private string connect="data source=DESKTOP-PIDG8BM\\SQLEXPRESS;initial catalog=translate;integrated security=True;MultipleActiveResultSets=True";
        public DataTable ExcuteQuery(string query, object[] parameter=null){
            DataTable data= new DataTable();
            using (SqlConnection connection= new SqlConnection(connect))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query,connection);
                if(parameter!=null){
                    string[] lisPara = query.Split(' ');
                    int i=0;
                    foreach(var item in lisPara)
                    {
                        if(item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item,parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adater= new SqlDataAdapter(command);
                adater.Fill(data);
                connection.Close();
            }
            return data;
        }
         public int ExcuteNonQuery(string query, object[] parameter=null){
            int data=0;
            using (SqlConnection connection= new SqlConnection(connect))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query,connection);
                if(parameter!=null){
                    string[] lisPara = query.Split(' ');
                    int i=0;
                    foreach(var item in lisPara)
                    {
                        if(item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item,parameter[i]);
                            i++;
                        }
                    }
                }
                data= command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }
         public object ExcuteScalar(string query, object[] parameter=null){
            object data=0;
            using (SqlConnection connection= new SqlConnection(connect))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query,connection);
                if(parameter!=null){
                    string[] lisPara = query.Split(' ');
                    int i=0;
                    foreach(var item in lisPara)
                    {
                        if(item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item,parameter[i]);
                            i++;
                        }
                    }
                }
                data= command.ExecuteScalar();
                connection.Close();
            }
            return data;
        }

    }
}