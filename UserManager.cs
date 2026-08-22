using System.Data;
using System.Data.SqlClient;

namespace Gr8Food
{
    public class UserManager
    {
        DBConnection db = new DBConnection();

        public string Login(string email, string password)
        {
            db.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT Role FROM Users WHERE Email=@email AND Password=@password", db.conn);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                object result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : "";
            }
            finally { db.conn.Close(); }
        }

        public DataTable GetUserByCredentials(string email, string password)
        {
            db.conn.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT UserID, Name, Email, Role, WalletBalance FROM Users " +
                    "WHERE Email=@Email AND Password=@Password", db.conn);
                da.SelectCommand.Parameters.AddWithValue("@Email", email);
                da.SelectCommand.Parameters.AddWithValue("@Password", password);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            finally { db.conn.Close(); }
        }

        public DataTable GetProfile(string email)
        {
            db.conn.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT * FROM Users WHERE Email=@Email", db.conn);
                da.SelectCommand.Parameters.AddWithValue("@Email", email);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            finally { db.conn.Close(); }
        }

        public void UpdateProfile(string name, string phone, string email, string password)
        {
            db.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Users SET Name=@Name, Phone=@Phone, Password=@Password WHERE Email=@Email",
                    db.conn);
                cmd.Parameters.AddWithValue("@Name",     name);
                cmd.Parameters.AddWithValue("@Phone",    phone ?? "");
                cmd.Parameters.AddWithValue("@Email",    email);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.ExecuteNonQuery();
            }
            finally { db.conn.Close(); }
        }

        public void TopUpWallet(string email, decimal amount)
        {
            db.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Users SET WalletBalance = WalletBalance + @Amount WHERE Email=@Email",
                    db.conn);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.ExecuteNonQuery();
            }
            finally { db.conn.Close(); }
        }

        public DataTable LoadAllUsers()
        {
            db.conn.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT UserID, Name AS FullName, Phone, Role, Email AS Username " +
                    "FROM Users ORDER BY Name", db.conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            finally { db.conn.Close(); }
        }

        public bool EmailExists(string email, int excludeUserId = 0)
        {
            db.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Users WHERE Email=@Email AND UserID != @ExcludeID", db.conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@ExcludeID", excludeUserId);
                return (int)cmd.ExecuteScalar() > 0;
            }
            finally { db.conn.Close(); }
        }

        public bool PhoneExists(string phone, int excludeUserId = 0)
        {
            db.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Users WHERE Phone=@Phone AND UserID != @ExcludeID", db.conn);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@ExcludeID", excludeUserId);
                return (int)cmd.ExecuteScalar() > 0;
            }
            finally { db.conn.Close(); }
        }

        public void AddUser(string name, string phone, string role, string email, string password)
        {
            db.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Users (Name, Phone, Role, Email, Password, WalletBalance) " +
                    "VALUES (@Name, @Phone, @Role, @Email, @Password, 0)", db.conn);
                cmd.Parameters.AddWithValue("@Name",     name);
                cmd.Parameters.AddWithValue("@Phone",    phone);
                cmd.Parameters.AddWithValue("@Role",     role);
                cmd.Parameters.AddWithValue("@Email",    email);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.ExecuteNonQuery();
            }
            finally { db.conn.Close(); }
        }

        public void UpdateUser(int userId, string name, string phone, string role,
                               string email, string password)
        {
            db.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Users SET Name=@Name, Phone=@Phone, Role=@Role, " +
                    "Email=@Email, Password=@Password WHERE UserID=@UserID", db.conn);
                cmd.Parameters.AddWithValue("@Name",     name);
                cmd.Parameters.AddWithValue("@Phone",    phone);
                cmd.Parameters.AddWithValue("@Role",     role);
                cmd.Parameters.AddWithValue("@Email",    email);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@UserID",   userId);
                cmd.ExecuteNonQuery();
            }
            finally { db.conn.Close(); }
        }

        public bool HasRelatedRecords(int userId)
        {
            db.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT (SELECT COUNT(*) FROM Orders WHERE CustomerID=@UserID) + " +
                    "(SELECT COUNT(*) FROM Feedback WHERE CustomerID=@UserID) + " +
                    "(SELECT COUNT(*) FROM WalletTransactions WHERE CustomerID=@UserID)", db.conn);
                cmd.Parameters.AddWithValue("@UserID", userId);
                return (int)cmd.ExecuteScalar() > 0;
            }
            finally { db.conn.Close(); }
        }

        public void DeleteUser(int userId)
        {
            db.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Users WHERE UserID=@UserID", db.conn);
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.ExecuteNonQuery();
            }
            finally { db.conn.Close(); }
        }

        public string GetPasswordById(int userId)
        {
            db.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT Password FROM Users WHERE UserID=@UserID", db.conn);
                cmd.Parameters.AddWithValue("@UserID", userId);
                object result = cmd.ExecuteScalar();
                return result?.ToString() ?? "";
            }
            finally { db.conn.Close(); }
        }
    }
}
