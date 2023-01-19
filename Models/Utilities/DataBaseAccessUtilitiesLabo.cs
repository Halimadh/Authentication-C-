using System.Data.SqlClient;
using System.Data;

namespace WebApp.Models.Utilities
{
    public class DataBaseAccessUtilitiesLabo
    {
        public static object ScalarRequest(SqlCommand MyCommand)
        {
            try
            {
                try
                {
                    MyCommand.Connection.Open();
                }
                catch (SqlException e)
                {
                    throw new MyException(e, "DataBase Error", e.Message, "DAL_labo");
                }

                return MyCommand.ExecuteScalar();
            }
            catch (SqlException e)
            {
                throw new MyException(e, "DataBase Error", e.Message, "DAL_labo");
            }
            finally
            {
                MyCommand.Connection.Close();
            }
        }


        public static DataTable SelectRequest(SqlCommand MyCommand)
        {
            try
            {
                DataTable Table;
                SqlDataAdapter SelectAdapter = new SqlDataAdapter(MyCommand);
                Table = new DataTable();
                SelectAdapter.Fill(Table);
                return Table;
            }
            catch (SqlException e)
            {
                throw new MyException(e, "DataBase Error", e.Message, "DAL_labo");
            }
            finally
            {
                MyCommand.Connection.Close();
            }
        }

        public class MyException : Exception
        {

            string _Level;
            string _MyExceptionTitle;
            string _MyExceptionMessage;


            public string Level
            {
                get
                {
                    return this._Level;
                }
            }

            public string MyExceptionTitle
            {
                get
                {
                    return this._MyExceptionTitle;
                }
            }

            public string MyExceptionMessage
            {
                get
                {
                    return this._MyExceptionMessage.ToString();
                }
            }


            public MyException(string MyExceptionTitle, string MyExceptionMessage, string lev) : base(MyExceptionMessage)
            {
                this._Level = lev;
                this._MyExceptionTitle = MyExceptionTitle;
                this._MyExceptionMessage = MyExceptionMessage;
            }

            public MyException(Exception e, string MyExceptionTitle, string MyExceptionMessage, string lev) : base(e.Message)
            {
                this._Level = lev;
                this._MyExceptionTitle = MyExceptionTitle;
                this._MyExceptionMessage = MyExceptionMessage;
            }


        }
    }

}
