

using Manager;
using System;
using System.Data.SqlClient;


class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Data Source=DESKTOP-QKU0HL3;Initial Catalog=ManageShop;Integrated Security=True;Encrypt=False";
        DataAccess da = new DataAccess();
        da.CreateCategory(connectionString);
        da.GetCategories(connectionString);
        da.CreateProduct(connectionString);
        da.GetProducts(connectionString);

    }
}