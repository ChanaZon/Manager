using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;

namespace Manager
{
    internal class DataAccess
    {
        public void CreateCategory(string connectionString)
        {
            string categoryName;
            string response="y";
            while (response != "n")
            {
                Console.WriteLine("enter category name");
                categoryName = Console.ReadLine();

                string query = "INSERT INTO Categories(CategoryName)" + " VALUES(@categoryName)";
                using (SqlConnection cn = new(connectionString))
                using (SqlCommand cmd = new(query, cn))
                {
                    cmd.Parameters.Add("@CategoryName", SqlDbType.VarChar, 50).Value = categoryName;
                    cn.Open();
                    int rowAffacted = cmd.ExecuteNonQuery();
                    cn.Close();

                   // return rowAffacted;
                }
                Console.WriteLine("whold you like to continue y/n");
                    response=Console.ReadLine();
            }
        }
        public void GetCategories(string connectionString)
        {
            string query = "SELECT * FROM Categories";
            using (SqlConnection cn = new(connectionString))
            {
                SqlCommand cmd = new(query, cn);
                try
                {
                    cn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("Category id = " + reader[0]+" , category name: " + reader[1]);
                    }
                    cn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
               Console.ReadLine();
            }
        }
        public void CreateProduct(string connectionString)
        {
            string category_Id, name, description, price, imageURL;
            string response = "y";
            while (response != "n")
            {

                Console.WriteLine("Enter category Id");
                category_Id = Console.ReadLine();
                Console.WriteLine("Enter name");
                name = Console.ReadLine();
                Console.WriteLine("Enter description");
                description = Console.ReadLine();
                Console.WriteLine("Enter price");
                price = Console.ReadLine();
                Console.WriteLine("Enter image url");
                imageURL = Console.ReadLine();



                string query = "INSERT INTO Products(category_Id,name,description,price,imageURL)"
                    + " VALUES(@Category_Id,@Name,@Description,@Price,@ImageURL)";
                using (SqlConnection cn = new(connectionString))
                using (SqlCommand cmd = new(query, cn))
                {
                    cmd.Parameters.Add("@Category_Id", SqlDbType.Int).Value = category_Id;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = name;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = description;
                    cmd.Parameters.Add("@ImageURL", SqlDbType.NVarChar, 50).Value = imageURL;
                    cmd.Parameters.Add("@Price", SqlDbType.Int).Value = price;

                    cn.Open();
                    int rowAffacted = cmd.ExecuteNonQuery();
                    cn.Close();
                    //return rowAffacted;
                }
                Console.WriteLine("whold you like to continue y/n");
                response = Console.ReadLine();
            }
        }
        public void GetProducts(string connectionString)
        {
            string query = "SELECT * FROM Products";
            using (SqlConnection cn = new(connectionString))
            {
                SqlCommand cmd = new(query, cn);
                try
                {
                    cn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("Product id = " + reader[0] + " , category id: " + reader[1]
                            + " ,  name: " + reader[2] + " ,  description: " + reader[3]);
                    }
                    cn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
        }
    }
}
