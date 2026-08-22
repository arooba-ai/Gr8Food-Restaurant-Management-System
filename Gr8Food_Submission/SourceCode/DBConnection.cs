using System.Data.SqlClient;

namespace Gr8Food
{
    public class DBConnection
    {
        public SqlConnection conn = new SqlConnection
        (
            "Data Source=(localdb)\\MSSQLLocalDB;" +
            "Initial Catalog=GR8Foodsdb;" +
            "Integrated Security=True"
        );
    }
}