using AZWebApplication.Models;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;

namespace AZWebApplication.Services
{
    public class ProductServices
    {
        private static string db_server = "azuresqldbservertrain.database.windows.net";
        private static string db_db = "azdb";
        private static string db_user = "azuretrainharsh";
        private static string db_pwd = "asd321A$";


        private SqlConnection GetConnection()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_server;
            _builder.InitialCatalog = db_db;
            _builder.UserID = db_user;
            _builder.Password = db_pwd;
            return new SqlConnection(_builder.ConnectionString);

        }

        public List<Product> GetProductDetails()
        {
            SqlConnection conn = GetConnection();
            List<Product> product_list = new List<Product>();
            string _statement = "Select * from Products";

            conn.Open();
            SqlCommand cmd = new SqlCommand(_statement, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        ProductId = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };

                    product_list.Add(product);
                }
            }
            conn.Close();
            return product_list;
        }

    }
}
