using System;
using System.Data;
using System.Data.SqlClient;

namespace Gr8Food
{
    public class FeedbackManager
    {
        DBConnection db = new DBConnection();

        public DataTable LoadRecentFeedbacks(DateTime date)
        {
            db.conn.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT TOP 5 u.Name AS Customer, f.Message, CONVERT(varchar,f.Date,103) AS Date
                      FROM Feedback f
                      INNER JOIN Users u ON f.CustomerID = u.UserID
                      WHERE CAST(f.Date AS DATE) = @Date
                      ORDER BY f.FeedbackID DESC",
                    db.conn);
                da.SelectCommand.Parameters.AddWithValue("@Date", date.Date);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            finally { db.conn.Close(); }
        }

        public void AddFeedback(int customerId, int orderId, string message)
        {
            db.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Feedback (CustomerID, OrderID, Message, Date) " +
                    "VALUES (@customerId, @orderId, @message, @date)", db.conn);
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.Parameters.AddWithValue("@orderId", orderId);
                cmd.Parameters.AddWithValue("@message", message);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
            finally { db.conn.Close(); }
        }

        public DataTable LoadFeedbacks()
        {
            db.conn.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT f.FeedbackID,
                      u.Name AS CustomerName,
                      f.Message AS Feedback,
                      f.Date,
                      CASE WHEN f.Reply IS NULL THEN 'Pending' ELSE 'Replied' END AS Status
                      FROM Feedback f
                      INNER JOIN Users u ON f.CustomerID = u.UserID",
                    db.conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            finally { db.conn.Close(); }
        }

        public DataTable FilterFeedbacks(string date, string status)
        {
            string query;
            if (status == "Pending")
            {
                query = @"SELECT f.FeedbackID, u.Name AS CustomerName, f.Message AS Feedback,
                          f.Date, 'Pending' AS Status
                          FROM Feedback f INNER JOIN Users u ON f.CustomerID = u.UserID
                          WHERE CONVERT(date, f.Date) = CONVERT(date, @Date) AND f.Reply IS NULL";
            }
            else
            {
                query = @"SELECT f.FeedbackID, u.Name AS CustomerName, f.Message AS Feedback,
                          f.Date, 'Replied' AS Status
                          FROM Feedback f INNER JOIN Users u ON f.CustomerID = u.UserID
                          WHERE CONVERT(date, f.Date) = CONVERT(date, @Date) AND f.Reply IS NOT NULL";
            }

            db.conn.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query, db.conn);
                da.SelectCommand.Parameters.AddWithValue("@Date", date);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            finally { db.conn.Close(); }
        }

        public void ReplyFeedback(int feedbackID, string reply)
        {
            db.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Feedback SET Reply = @Reply WHERE FeedbackID = @FeedbackID", db.conn);
                cmd.Parameters.AddWithValue("@Reply", reply);
                cmd.Parameters.AddWithValue("@FeedbackID", feedbackID);
                cmd.ExecuteNonQuery();
            }
            finally { db.conn.Close(); }
        }
    }
}
