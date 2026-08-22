using System;
using System.Data;
using System.Data.SqlClient;

namespace Manager
{
    internal class WalletManager
    {
        DBConnection db = new DBConnection();

        ////////////////// Manager Dashboard TopUp Summary ///////////////////

        public string GetTotalTopups()
        {
            string total = "0";

            db.conn.Open();

            SqlCommand cmd = new SqlCommand
            (
                @"SELECT SUM(Amount)
                FROM WalletTransactions
                WHERE Type='TopUp'
                AND CONVERT(date, Date) = CONVERT(date, GETDATE())",

                db.conn
            );

            object result = cmd.ExecuteScalar();

            if (result != DBNull.Value)
            {
                total = result.ToString();
            }

            db.conn.Close();

            return total;
        }

        /////////////// Manager Dashboard Usage Sommary ////////////////
        public string GetTotalUsage()
        {
            string total = "0";

            db.conn.Open();

            SqlCommand cmd = new SqlCommand
            (
                @"SELECT SUM(Amount)
                FROM WalletTransactions
                WHERE Type='Payment'
                AND CONVERT(date, Date) = CONVERT(date, GETDATE())",

                db.conn
            );

            object result = cmd.ExecuteScalar();

            if (result != DBNull.Value)
            {
                total = Math.Abs(Convert.ToDecimal(result)).ToString();
            }

            db.conn.Close();

            return total;
        }

       ////////////// Manager Dashboard Recent Feedbakcs ////////////////

        public DataTable LoadWalletReports()
        {
            db.conn.Open();

            SqlDataAdapter da = new SqlDataAdapter
        (
              @"SELECT 
              u.Name AS CustomerName,

         CASE 
              WHEN w.Type = 'TopUp' THEN w.Amount
              ELSE 0
              END AS TopUpAmount,

         CASE 
              WHEN w.Type = 'Payment' THEN w.Amount
              ELSE 0
              END AS UsageAmount,

              u.WalletBalance AS RemainingBalance,

              w.Date

         FROM WalletTransactions w

         INNER JOIN Users u
         ON w.CustomerID = u.UserID",

         db.conn
        );

            DataTable dt = new DataTable();

            da.Fill(dt);

            db.conn.Close();

            return dt;
        }

        //////////////// 

        public DataTable LoadCustomers()
        {
            db.conn.Open();

            SqlDataAdapter da = new SqlDataAdapter
            (
                "SELECT UserID, Name FROM Users Order by Name",
                db.conn
            );

            DataTable dt = new DataTable();

            da.Fill(dt);

            db.conn.Close();

            return dt;
        }

        public DataTable FilterWalletReports(int customerID, string date)
        {
            db.conn.Open();

            SqlDataAdapter da = new SqlDataAdapter
            (
                @"SELECT 
            u.Name AS CustomerName,

            CASE 
                WHEN w.Type = 'TopUp' THEN w.Amount
                ELSE 0
            END AS TopUpAmount,

            CASE 
                WHEN w.Type = 'Payment' THEN w.Amount
                ELSE 0
            END AS UsageAmount,

            u.WalletBalance AS RemainingBalance,

            w.Date

          FROM WalletTransactions w

          INNER JOIN Users u
          ON w.CustomerID = u.UserID

          WHERE w.CustomerID = @CustomerID
          AND CAST(w.Date AS DATE) = CAST(@Date AS DATE)",

                db.conn
            );

            da.SelectCommand.Parameters.AddWithValue
            (
                "@CustomerID",
                customerID
            );

            da.SelectCommand.Parameters.AddWithValue
            (
                "@Date",
                date
            );

            DataTable dt = new DataTable();

            da.Fill(dt);

            db.conn.Close();

            return dt;
        }
    }
}