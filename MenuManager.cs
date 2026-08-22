using System.Data;
using System.Data.SqlClient;

namespace Gr8Food
{
    public class MenuManager
    {
        DBConnection db = new DBConnection();

        public DataTable LoadMenu()
        {
            db.conn.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT * FROM Menu WHERE IsAvailable = 1", db.conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            finally { db.conn.Close(); }
        }

        public DataTable LoadCategory(string category)
        {
            db.conn.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT * FROM Menu WHERE Category=@Category AND IsAvailable = 1",
                    db.conn);
                da.SelectCommand.Parameters.AddWithValue("@Category", category);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            finally { db.conn.Close(); }
        }

        public DataTable SearchFood(string food)
        {
            db.conn.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT * FROM Menu WHERE Name LIKE @Food AND IsAvailable = 1",
                    db.conn);
                da.SelectCommand.Parameters.AddWithValue("@Food", "%" + food + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            finally { db.conn.Close(); }
        }

        public DataTable LoadAllMenu()
        {
            db.conn.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT MenuID AS FoodID,
                      Name      AS FoodName,
                      Category,
                      Price,
                      CASE WHEN IsAvailable = 1 THEN 'Available' ELSE 'Not Available' END AS Availability
                      FROM Menu ORDER BY Name",
                    db.conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            finally { db.conn.Close(); }
        }

        public void AddMenuItem(string name, string category, decimal price, bool isAvailable)
        {
            db.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Menu (Name, Category, Price, IsAvailable) " +
                    "VALUES (@Name, @Category, @Price, @IsAvailable)", db.conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@IsAvailable", isAvailable ? 1 : 0);
                cmd.ExecuteNonQuery();
            }
            finally { db.conn.Close(); }
        }

        public void UpdateMenuItem(int menuId, string name, string category, decimal price, bool isAvailable)
        {
            db.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Menu SET Name=@Name, Category=@Category, Price=@Price, IsAvailable=@IsAvailable " +
                    "WHERE MenuID=@MenuID", db.conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@IsAvailable", isAvailable ? 1 : 0);
                cmd.Parameters.AddWithValue("@MenuID", menuId);
                cmd.ExecuteNonQuery();
            }
            finally { db.conn.Close(); }
        }

        public bool IsMenuItemReferenced(int menuId)
        {
            db.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM OrderDetails WHERE MenuID=@MenuID", db.conn);
                cmd.Parameters.AddWithValue("@MenuID", menuId);
                return (int)cmd.ExecuteScalar() > 0;
            }
            finally { db.conn.Close(); }
        }

        public void DeleteMenuItem(int menuId)
        {
            db.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Menu WHERE MenuID=@MenuID", db.conn);
                cmd.Parameters.AddWithValue("@MenuID", menuId);
                cmd.ExecuteNonQuery();
            }
            finally { db.conn.Close(); }
        }
    }
}
