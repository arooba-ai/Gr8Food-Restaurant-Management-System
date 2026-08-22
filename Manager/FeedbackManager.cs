using System.Data;
using System.Data.SqlClient;

namespace Manager
{
    internal class FeedbackManager
    {
        DBConnection db = new DBConnection();

        public DataTable LoadRecentFeedbacks()
        {
            db.conn.Open();

            SqlDataAdapter da = new SqlDataAdapter
            (
                "SELECT TOP 5 Message FROM Feedback ORDER BY FeedbackID DESC",
                db.conn
            );

            DataTable dt = new DataTable();

            da.Fill(dt);

            db.conn.Close();

            return dt;
        }

        public DataTable LoadFeedbacks()
        {
            db.conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(
            @"SELECT
f.FeedbackID,
u.Name AS CustomerName,
f.Message AS Feedback,
f.Date,
ISNULL(f.Reply, 'No Reply Yet') AS Reply,

CASE
    WHEN f.Reply IS NULL THEN 'Pending'
    ELSE 'Replied'
END AS Status

FROM Feedback f
INNER JOIN Users u
ON f.CustomerID = u.UserID",

              db.conn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            db.conn.Close();

            return dt;
        }



        public DataTable FilterFeedbacks(string date, string status)
        {
            db.conn.Open();

            string query = "";

            if (status == "Pending")
            {
                // FeedbackID must be included so the Reply button can identify the row
                query = @"SELECT
                    f.FeedbackID,
                    u.Name AS CustomerName,
                    f.Message AS Feedback,
                    f.Date,
                    'No Reply Yet' AS Reply,
                    'Pending' AS Status

                  FROM Feedback f
                  INNER JOIN Users u
                  ON f.CustomerID = u.UserID

                  WHERE CONVERT(date, f.Date) = CONVERT(date, @Date)

                  AND f.Reply IS NULL";
            }
            else
            {
                query = @"SELECT
                        f.FeedbackID,
                        u.Name AS CustomerName,
                        f.Message AS Feedback,
                        f.Date,
                        ISNULL(f.Reply, 'No Reply Yet') AS Reply,
                        'Replied' AS Status

                  FROM Feedback f
                  INNER JOIN Users u
                  ON f.CustomerID = u.UserID

                  WHERE CONVERT(date, f.Date) = CONVERT(date, @Date)

                  AND f.Reply IS NOT NULL";
            }

            SqlDataAdapter da = new SqlDataAdapter(query, db.conn);

            da.SelectCommand.Parameters.AddWithValue("@Date", date);

            DataTable dt = new DataTable();

            da.Fill(dt);

            db.conn.Close();

            return dt;
        }

            public void ReplyFeedback( int feedbackID,string reply)
        {
            
            db.conn.Open();

            SqlCommand cmd = new SqlCommand(
                @"UPDATE Feedback
          SET Reply = @Reply
          WHERE FeedbackID = @FeedbackID",
                db.conn);

            cmd.Parameters.AddWithValue("@Reply", reply);
            cmd.Parameters.AddWithValue("@FeedbackID", feedbackID);

            cmd.ExecuteNonQuery();

            db.conn.Close();
      
        
    }
    }
}