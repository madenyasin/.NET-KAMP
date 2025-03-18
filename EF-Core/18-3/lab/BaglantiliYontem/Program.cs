using BaglantiliYontem.Models;
using Microsoft.Data.SqlClient;

string connStr = "Data source=.;initial catalog=Northwind;integrated security=true;trust server certificate=true";

SqlConnection conn = new SqlConnection(connStr);

KategoriEkle(new Category() { CategoryName = "Yeni Kategori" });

conn.Open();

SqlCommand cmd = new SqlCommand("select * from categories", conn);

SqlDataReader dr = cmd.ExecuteReader();

List<Category> categories = new();
while (dr.Read())
{
    Category category = new Category()
    {
        Id = dr.GetInt32(0),
        CategoryName = dr.GetString(1)
    };
    categories.Add(category);
}

conn.Close();

void KategoriEkle(Category category)
{
    SqlConnection sqlConnection = new(connStr);
    sqlConnection.Open();
    SqlCommand cmd = new("insert into categories(CategoryName) values(@ad)", sqlConnection);

    cmd.Parameters.Clear();
    cmd.Parameters.AddWithValue("@ad", category.CategoryName);

    cmd.ExecuteNonQuery();
    sqlConnection.Close();
}