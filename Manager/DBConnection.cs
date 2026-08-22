using System.Data.SqlClient;

namespace Manager
{
    internal class DBConnection
    {
        public SqlConnection conn = new SqlConnection
        (
            "Data Source=(localdb)\\MSSQLLocalDB;" +
            "Initial Catalog=GR8Foodsdb;" +
            "Integrated Security=True"
        );
    }
}