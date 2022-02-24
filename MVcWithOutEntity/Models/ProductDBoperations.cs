using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVcWithOutEntity.Models
{
    public class ProductDBoperations
    {
        string connectionString = @"Data Source = ICS-12; Initial Catalog = MVCwithoutEntity; Integrated Security=True;";


        public List<ProductModel> ListAll()
        {
            List<ProductModel> lst = new List<ProductModel>();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCom = new SqlCommand("SELECT * FROM Product", sqlCon);
                //sqlCom.CommandType = CommandType.StoredProcedure;
                //sqlCom.ExecuteNonQuery()
                SqlDataReader rdr = sqlCom.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new ProductModel
                    {
                        ProductID = Convert.ToInt32(rdr["ProductID"]),
                        ProductName = rdr["ProductName"].ToString(),
                        Price = Convert.ToDecimal(rdr["Price"]),
                        Count = Convert.ToInt32(rdr["Count"]),
                        Description = rdr["Description"].ToString(),
                    });
                }
                return lst;
            }
        }


        //Method for Adding an Product 
        public int AddProduct(ProductModel product)
        {
            int i;
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlCommand com = new SqlCommand("INSERT INTO Product (ProductName, Price, Count, Description) VALUES(@ProductName, @Price, @Count, @Description)", sqlCon);
                com.Parameters.AddWithValue("@ProductID", product.ProductID);
                com.Parameters.AddWithValue("@ProductName", product.ProductName);
                com.Parameters.AddWithValue("@Price", product.Price );
                com.Parameters.AddWithValue("@Count", product.Count);
                com.Parameters.AddWithValue("@Description", product.Description);
                i = com.ExecuteNonQuery();
            }
            return i;
        }



        //Method for Updating Product record  
        public int Update(ProductModel product)
        {
            int i;
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlCommand com = new SqlCommand("UPDATE Product SET ProductName = @ProductName, Price= @Price, Count = @Count, Description = @Description WHERE ProductID =@ProductID", sqlCon); 
                com.Parameters.AddWithValue("@ProductID", product.ProductID);
                com.Parameters.AddWithValue("@ProductName", product.ProductName);
                com.Parameters.AddWithValue("@Price", product.Price);
                com.Parameters.AddWithValue("@Count", product.Count);
                com.Parameters.AddWithValue("@Description", product.Description);
                i = com.ExecuteNonQuery();
            }
            return i;
        }


        //Method for Deleting Product
        public int Delete(int ID)
        {
            int i;
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCom = new SqlCommand("DELETE FROM Product WHERE ProductID= @ProductID", sqlCon); 
                sqlCom.Parameters.AddWithValue("@ProductId", ID);
                i = sqlCom.ExecuteNonQuery();
            }
            return i;
        }
    }
}