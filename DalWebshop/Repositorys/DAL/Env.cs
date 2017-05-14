using System.Data.SqlClient;

namespace DalWebshop.Repositorys.DAL
{
   public static class Env
    {
       static public SqlConnection Con = new SqlConnection("Data Source=;Initial Catalog=;User ID=;Password=;Encrypt=False;TrustServerCertificate=True");

       static public string ConString = "Data Source=;Initial Catalog=;User ID=;Password=;Encrypt=False;TrustServerCertificate=True";
    }
}
