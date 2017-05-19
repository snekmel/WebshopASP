using DalWebshop.Models;

namespace DalWebshop.Repositorys
{
    public class AuthRepository
    {
        public static Gebruiker CheckAuth(string email, string password)
        {
            Gebruiker returnUser = null;
            foreach (Gebruiker g in Gebruiker.All())
            {
                if (g.Email == email && g.Wachtwoord == password)
                {
                    returnUser = g;
                }
            }

            return returnUser;
        }
    }
}