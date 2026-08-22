using System;
using System.Data;
using System.Data.SqlClient;

namespace Gr8Food
{
    public class WalletManager
    {
        DBConnection db = new DBConnection();

        public decimal GetWalletBalance(int customerId)
        {
            db.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT WalletBalance FROM Users WHERE UserID = @CustomerID", db.conn);
                cmd.Parameters.AddWithValue("@CustomerID", customerId);
                object result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value) return 0;
                return Convert.ToDecimal(result);
            }
            finally { db.conn.Close(); }
        }

        public void AddToBalance(int customerId, decimal amount)
        {
            db.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Users SET WalletBalance = ISNULL(WalletBalance, 0) + @Amount WHERE UserID = @CustomerID",
                    db.conn);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@CustomerID", customerId);
                cmd.ExecuteNonQuery();
            }
            finally { db.conn.Close(); }
        }

        public void DeductBalance(int customerId, decimal amount)
        {
            db.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Users SET WalletBalance = WalletBalance - @Amount WHERE UserID = @CustomerID",
                    db.conn);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@CustomerID", customerId);
                cmd.ExecuteNonQuery();
            }
            finally { db.conn.Close(); }
        }

        public void AddTransaction(int customerId, decimal amount, string type)
        {
            db.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO WalletTransactions (CustomerID, Amount, Type, Date) " +
                    "VALUES (@CustomerID, @Amount, @Type, @Date)", db.conn);
                cmd.Parameters.AddWithValue("@CustomerID", customerId);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@Type", type);
                cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
            finally { db.conn.Close(); }
        }

        public string GetTotalTopups(DateTime date)
        {
            db.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT SUM(Amount) FROM WalletTransactions " +
                    "WHERE Type = 'TopUp' AND CAST(Date AS DATE) = @Date", db.conn);
                cmd.Parameters.AddWithValue("@Date", date.Date);
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                    return Convert.ToDecimal(result).ToString("F2");
                return "0.00";
            }
            finally { db.conn.Close(); }
        }

        public string GetTotalUsage(DateTime date)
        {
            db.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT SUM(Amount) FROM WalletTransactions " +
                    "WHERE Type = 'Payment' AND CAST(Date AS DATE) = @Date", db.conn);
                cmd.Parameters.AddWithValue("@Date", date.Date);
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                    return Math.Abs(Convert.ToDecimal(result)).ToString("F2");
                return "0.00";
            }
            finally { db.conn.Close(); }
        }

        public DataTable LoadWalletReports()
        {
            db.conn.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT u.Name AS CustomerName,
                      CASE WHEN w.Type = 'TopUp' THEN w.Amount ELSE 0 END AS TopUpAmount,
                      CASE WHEN w.Type = 'Payment' THEN w.Amount ELSE 0 END AS UsageAmount,
                      u.WalletBalance AS RemainingBalance,
                      w.Date
                      FROM WalletTransactions w
                      INNER JOIN Users u ON w.CustomerID = u.UserID",
                    db.conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            finally { db.conn.Close(); }
        }

        public DataTable LoadCustomers()
        {
            db.conn.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT UserID, Name FROM Users ORDER BY Name", db.conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            finally { db.conn.Close(); }
        }

        public DataTable FilterWalletReports(int customerID, string date)
        {
            db.conn.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT u.Name AS CustomerName,
                      CASE WHEN w.Type = 'TopUp' THEN w.Amount ELSE 0 END AS TopUpAmount,
                      CASE WHEN w.Type = 'Payment' THEN w.Amount ELSE 0 END AS UsageAmount,
                      u.WalletBalance AS RemainingBalance,
                      w.Date
                      FROM WalletTransactions w
                      INNER JOIN Users u ON w.CustomerID = u.UserID
                      WHERE w.CustomerID = @CustomerID
                      AND CAST(w.Date AS DATE) = CAST(@Date AS DATE)",
                    db.conn);
                da.SelectCommand.Parameters.AddWithValue("@CustomerID", customerID);
                da.SelectCommand.Parameters.AddWithValue("@Date", date);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            finally { db.conn.Close(); }
        }
    }
}
