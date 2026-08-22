using System;
using System.Data;
using System.Data.SqlClient;

namespace Gr8Food
{
    public class OrderManager
    {
        DBConnection db = new DBConnection();

        public DataTable LoadCart()
        {
            db.conn.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Cart", db.conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            finally { db.conn.Close(); }
        }

        public DataTable LoadOrders(int customerId)
        {
            db.conn.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT OrderID, TotalAmount, Status, OrderDate " +
                    "FROM Orders WHERE CustomerID = @CustomerID " +
                    "ORDER BY OrderDate DESC",
                    db.conn);
                da.SelectCommand.Parameters.AddWithValue("@CustomerID", customerId);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            finally { db.conn.Close(); }
        }

        public void AddToCart(string foodName, decimal price, int quantity, decimal total)
        {
            db.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Cart (FoodName, Price, Quantity, Total) " +
                    "VALUES (@FoodName, @Price, @Quantity, @Total)",
                    db.conn);
                cmd.Parameters.AddWithValue("@FoodName", foodName);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@Total", total);
                cmd.ExecuteNonQuery();
            }
            finally { db.conn.Close(); }
        }

        public void RemoveItem(int cartId)
        {
            db.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Cart WHERE CartID = @ID", db.conn);
                cmd.Parameters.AddWithValue("@ID", cartId);
                cmd.ExecuteNonQuery();
            }
            finally { db.conn.Close(); }
        }

        public decimal GetTotal()
        {
            db.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT SUM(Total) FROM Cart", db.conn);
                object result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value) return 0;
                return Convert.ToDecimal(result);
            }
            finally { db.conn.Close(); }
        }

        public int PlaceOrder(int customerId, decimal totalAmount)
        {
            db.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Orders (CustomerID, TotalAmount, Status, OrderDate) " +
                    "VALUES (@CustomerID, @TotalAmount, 'Pending', @OrderDate); " +
                    "SELECT SCOPE_IDENTITY();",
                    db.conn);
                cmd.Parameters.AddWithValue("@CustomerID", customerId);
                cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            finally { db.conn.Close(); }
        }

        public void AddOrderDetail(int orderId, int menuId, int quantity, decimal subtotal)
        {
            db.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO OrderDetails (OrderID, MenuID, Quantity, Subtotal) " +
                    "VALUES (@OrderID, @MenuID, @Quantity, @Subtotal)",
                    db.conn);
                cmd.Parameters.AddWithValue("@OrderID", orderId);
                cmd.Parameters.AddWithValue("@MenuID", menuId);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@Subtotal", subtotal);
                cmd.ExecuteNonQuery();
            }
            finally { db.conn.Close(); }
        }

        public void ClearCart()
        {
            db.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Cart", db.conn);
                cmd.ExecuteNonQuery();
            }
            finally { db.conn.Close(); }
        }

        public decimal GetOrderAmount(int orderId)
        {
            db.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT TotalAmount FROM Orders WHERE OrderID = @OrderID", db.conn);
                cmd.Parameters.AddWithValue("@OrderID", orderId);
                object result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value) return 0;
                return Convert.ToDecimal(result);
            }
            finally { db.conn.Close(); }
        }

        public void CancelOrder(int orderId)
        {
            db.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Orders SET Status = 'Cancelled' WHERE OrderID = @OrderID",
                    db.conn);
                cmd.Parameters.AddWithValue("@OrderID", orderId);
                cmd.ExecuteNonQuery();
            }
            finally { db.conn.Close(); }
        }

        public int GetMenuID(string foodName)
        {
            db.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT MenuID FROM Menu WHERE Name = @Name", db.conn);
                cmd.Parameters.AddWithValue("@Name", foodName);
                object result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value) return 0;
                return Convert.ToInt32(result);
            }
            finally { db.conn.Close(); }
        }

        public int GetLatestOrderID(int customerId)
        {
            db.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT TOP 1 OrderID FROM Orders " +
                    "WHERE CustomerID = @CustomerID ORDER BY OrderDate DESC",
                    db.conn);
                cmd.Parameters.AddWithValue("@CustomerID", customerId);
                object result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value) return 0;
                return Convert.ToInt32(result);
            }
            finally { db.conn.Close(); }
        }

        public DataTable LoadChefOrders()
        {
            db.conn.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT o.OrderID,
                      u.Name         AS CustomerName,
                      ISNULL(m.Name, '—') AS FoodName,
                      ISNULL(od.Quantity, 0) AS Quantity,
                      o.TotalAmount  AS Total,
                      o.Status
                      FROM Orders o
                      INNER JOIN Users u ON o.CustomerID = u.UserID
                      LEFT  JOIN OrderDetails od ON o.OrderID = od.OrderID
                      LEFT  JOIN Menu m ON od.MenuID = m.MenuID
                      ORDER BY o.OrderDate DESC",
                    db.conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            finally { db.conn.Close(); }
        }

        public void UpdateOrderStatus(int orderId, string status)
        {
            db.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Orders SET Status = @Status WHERE OrderID = @OrderID", db.conn);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@OrderID", orderId);
                cmd.ExecuteNonQuery();
            }
            finally { db.conn.Close(); }
        }

        public DataTable LoadSalesReport()
        {
            db.conn.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT o.OrderID,
                      MONTH(o.OrderDate)    AS Month,
                      YEAR(o.OrderDate)     AS Year,
                      ISNULL(m.Category, 'N/A') AS Category,
                      ISNULL(SUM(od.Subtotal), o.TotalAmount) AS TotalSales
                      FROM Orders o
                      LEFT JOIN OrderDetails od ON o.OrderID = od.OrderID
                      LEFT JOIN Menu m ON od.MenuID = m.MenuID
                      GROUP BY o.OrderID, o.OrderDate, o.TotalAmount, m.Category
                      ORDER BY o.OrderDate DESC",
                    db.conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            finally { db.conn.Close(); }
        }

        public DataTable FilterSalesReport(string month, string year, string category)
        {
            string whereMonth    = month    == "All" ? "" : "AND MONTH(o.OrderDate) = @Month ";
            string whereYear     = year     == "All" ? "" : "AND YEAR(o.OrderDate)  = @Year ";
            string whereCategory = category == "All" ? "" : "AND m.Category = @Category ";

            string query =
                @"SELECT o.OrderID,
                  MONTH(o.OrderDate)    AS Month,
                  YEAR(o.OrderDate)     AS Year,
                  ISNULL(m.Category, 'N/A') AS Category,
                  ISNULL(SUM(od.Subtotal), o.TotalAmount) AS TotalSales
                  FROM Orders o
                  LEFT JOIN OrderDetails od ON o.OrderID = od.OrderID
                  LEFT JOIN Menu m ON od.MenuID = m.MenuID
                  WHERE 1=1 " + whereMonth + whereYear + whereCategory +
                @"GROUP BY o.OrderID, o.OrderDate, o.TotalAmount, m.Category
                  ORDER BY o.OrderDate DESC";

            db.conn.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query, db.conn);
                if (month    != "All") da.SelectCommand.Parameters.AddWithValue("@Month",    int.Parse(month));
                if (year     != "All") da.SelectCommand.Parameters.AddWithValue("@Year",     int.Parse(year));
                if (category != "All") da.SelectCommand.Parameters.AddWithValue("@Category", category);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            finally { db.conn.Close(); }
        }
    }
}
