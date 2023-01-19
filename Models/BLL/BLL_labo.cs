using WebApp.Models.DAL;
using WebApp.Models.Entities;

namespace WebApp.Models.BLL
{
    public class BLL_labo
    {
        public static Labo GetUser(string email, string pwd)
        {
            return DAL_labo.SelectByEmailPassword(email, pwd);
        }
        public static Labo GetUserByEmail(string email)
        {
            return DAL_labo.SelectByEmail(email);
        }
        public static int Add(Labo labo)
        {
            return DAL_labo.Add(labo);
        }

        public static void Update(int id, Labo labo)
        {
            DAL_labo.Update(id, labo);
        }

        public static void Delete(int Id)
        {
            DAL_labo.Delete(Id);
        }
       
        public static List<Labo> GetAll()
        {
            return DAL_labo.SelectAll();
        }

    }
}
