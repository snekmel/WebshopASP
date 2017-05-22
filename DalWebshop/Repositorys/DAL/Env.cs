using System.Data.SqlClient;

namespace DalWebshop.Repositorys.DAL
{
    public static class Env
    {
        static public SqlConnection Con = new SqlConnection("Data Source=WINSrv-01.fhict.local;Initial Catalog=Webwinkel;User ID=lars;Password=test1234;Encrypt=False;TrustServerCertificate=True");

        static public string ConString = "Data Source=WINSrv-01.fhict.local;Initial Catalog=Webwinkel;User ID=lars;Password=test1234;Encrypt=False;TrustServerCertificate=True";
    }
}