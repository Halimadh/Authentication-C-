using System.Data;
using System.Data.SqlClient;
using WebApp.Models.Entities;
using WebApp.Models.Utilities;

namespace WebApp.Models.DAL
{
    public class DAL_labo
    {
        public static int Add(Labo labo)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string StrSQL = "INSERT INTO [dbo].[Labo] (Name,Email,Password,Acronyme,Tel,Etablissement,Responsable) output INSERTED.Id VALUES (@Name,@Email,@Password,@Acronyme,@Tel,@Etablissement,@Responsable)";
                SqlCommand command = new SqlCommand(StrSQL, con);
                command.Parameters.AddWithValue("@Name", labo.Name ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Email", labo.Email ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Password", labo.Password ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Acronyme", labo.Acronyme ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Tel", labo.Tel ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Etablissement", labo.Etablissement ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Responsable", labo.Responsable ?? (object)DBNull.Value);
                return Convert.ToInt32(DataBaseAccessUtilitiesLabo.ScalarRequest(command)); 
            }
        }

        // Method Update Article
        public static void Update(int id, Labo labo) 
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string StrSQL = "UPDATE [dbo].[Labo] SET Name=@Name,Email =@Email, Password =@Password, Acronyme =@Acronyme,Tel=@Tel,Etablissement=@Etablissement,Responsable=@Responsable WHERE Id = @EntityKey";
                SqlCommand command = new SqlCommand(StrSQL, con); 
                command.Parameters.AddWithValue("@Name", labo.Name ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Email", labo.Email ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Password", labo.Password ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Acronyme", labo.Acronyme ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Tel", labo.Tel ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Etablissement", labo.Etablissement ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Responsable", labo.Responsable ?? (object)DBNull.Value);
                DataBaseAccessUtilities.NonQueryRequest(command);
            }
        }

        // Method Delete Article
        public static void Delete(int EntityKey)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string StrSQL = "DELETE FROM [dbo].[Labo] WHERE Id=@EntityKey";
                SqlCommand command = new SqlCommand(StrSQL, con);
                command.Parameters.AddWithValue("@EntityKey", EntityKey);
                DataBaseAccessUtilities.NonQueryRequest(command);
            }
        }
        private static Labo GetEntityFromDataRow(DataRow dataRow)
        {
            Labo labo = new Labo();
            labo.Id = Convert.ToInt32(dataRow["Id"]);
            labo.Name = dataRow["Name"].ToString();
            labo.Email = dataRow["Email"].ToString();
            labo.Password = dataRow["Password"].ToString();
            labo.Acronyme = dataRow["Acronyme"].ToString();
            labo.Tel= dataRow["Tel"].ToString();
            labo.Etablissement = dataRow["Etablissement"].ToString();
            labo.Responsable = dataRow["Responsable"].ToString();
            return labo;
        }
        public static Labo SelectByEmailPassword(string email, string password)
        {
            using (SqlConnection con = DBUserConnection.GetConnection())
            {
                con.Open();
                string StrSQL = "SELECT * FROM [dbo].[Labo] WHERE Email=@email AND Password=@password";
                SqlCommand command = new SqlCommand(StrSQL, con);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);
                DataTable dt = DataBaseAccessUtilitiesLabo.SelectRequest(command);
                if (dt != null && dt.Rows.Count != 0)
                    return GetEntityFromDataRow(dt.Rows[0]);
                else
                    return null;
            }
        }
        public static Labo SelectByEmail(string email)
        {
            using (SqlConnection con = DBUserConnection.GetConnection())
            {
                con.Open();
                string StrSQL = "SELECT * FROM [dbo].[Labo] WHERE Email=@email";
                SqlCommand command = new SqlCommand(StrSQL, con);
                command.Parameters.AddWithValue("@email", email);
                DataTable dt = DataBaseAccessUtilitiesLabo.SelectRequest(command);
                if (dt != null && dt.Rows.Count != 0)
                    return GetEntityFromDataRow(dt.Rows[0]);
                else
                    return null;
            }
        }

        // Fill List Of **** With DataTable
        private static List<Labo> GetListFromDataTable(DataTable dt)
        {
            List<Labo> list = new List<Labo>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                    list.Add(GetEntityFromDataRow(dr));
            }
            return list;
        }


        // Get ALL 
        public static List<Labo> SelectAll()
        {
            DataTable dataTable;
            using (SqlConnection con = DBConnection.GetConnection())
            {
                con.Open();
                string StrSQL = "SELECT * FROM Article";
                SqlCommand command = new SqlCommand(StrSQL, con);
                dataTable = DataBaseAccessUtilities.SelectRequest(command);
            }
            return GetListFromDataTable(dataTable);
        }
    }
}
