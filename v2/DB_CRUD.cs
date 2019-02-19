using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
namespace Libs
{
    class Program
    {
        private static SqlConnection connection;
        private static string connectionString;
        private static SqlCommand insertCommand;
        private static SqlCommand updateCommand;
        private static SqlCommand deleteCommand;

        private static SqlCommand selectCommand;
        private static SqlDataReader dataReader;

        //connection string and connection initialization
        static void Init()
        {
            string dbName = "MyDb";
            connectionString ="Data Source=.\\SQLEXPRESS; Initial Catalog="+dbName+"; Integrated Security=True;";

            //initializations
            //or new SqlCommand(str command, connection);
            connection = new SqlConnection(connectionString);

            insertCommand = new SqlCommand();
            updateCommand = new SqlCommand();
            deleteCommand = new SqlCommand();
            selectCommand = new SqlCommand();

            //Commandtypes
            insertCommand.CommandType = System.Data.CommandType.Text;
            updateCommand.CommandType = System.Data.CommandType.Text;
            deleteCommand.CommandType = System.Data.CommandType.Text;
            selectCommand.CommandType = System.Data.CommandType.Text;

            //Connection
            insertCommand.Connection = connection;
            updateCommand.Connection = connection;
            deleteCommand.Connection = connection;
            selectCommand.Connection = connection;

            //Commands
            string insertText = "INSERT INTO Personas (Nombre,Edad,Pais) VALUES('Vik','15','Argentina')";
            string updateText = "UPDATE Personas set Pais='Bolivia' WHERE Pais = 'Bolvia'";
            string deleteText = "DELETE FROM Personas WHERE Nombre='franquito'";

            string selectAll = "SELECT * FROM Personas";
            //string selectConstraint = "SELECT * FROM Personas WHERE Pais='Argentina'";
            //string selectSome = "SELECT Nombre from Personas";

            insertCommand.CommandText = insertText;
            updateCommand.CommandText = updateText;
            deleteCommand.CommandText = deleteText;
            selectCommand.CommandText = selectAll;

            connection.Open();
        }

        static bool Insert()
        {
            try
            {
                insertCommand.ExecuteNonQuery();
                Console.WriteLine("Db insertion successfull");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed on db insertion");
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                Console.WriteLine("------------------------------");
            }
        }

        static bool Update()
        {
            try
            {
                updateCommand.ExecuteNonQuery();
                Console.WriteLine("Update successfull");
                return true;
            }catch(Exception e)
            {
                Console.WriteLine("Failed on db insertion");
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                Console.WriteLine("------------------------------");
            }
        }

        static bool Delete()
        {

            try
            {
                deleteCommand.ExecuteNonQuery();
                Console.WriteLine("Deletion successfull");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed eletion on db insertion");
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                Console.WriteLine("------------------------------");
            }
        }

        static bool Select()
        {
            try
            {
                dataReader = selectCommand.ExecuteReader();
                System.Console.WriteLine("Selecting all");
                while (dataReader.Read())
                {
                    string nombre = dataReader["Nombre"].ToString();
                    string edad = dataReader["Edad"].ToString();
                    string pais = dataReader["Pais"].ToString();
                    string persona = String.Format("{0} - {1} -- {2}", nombre, edad, pais);
                    System.Console.WriteLine(persona);
                }
                Console.WriteLine("Selection successfull");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed on db insertion");
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                dataReader.Close();
                Console.WriteLine("------------------------------");
            }

        }

        static bool SelectArgentinos()
        {
            try
            {
                selectCommand.CommandText ="SELECT * FROM Personas WHERE Pais='Argentina'";

                dataReader = selectCommand.ExecuteReader();
                System.Console.WriteLine("Selecting args");
                while (dataReader.Read())
                {
                    string nombre = dataReader["Nombre"].ToString();
                    string edad = dataReader["Edad"].ToString();
                    string pais = dataReader["Pais"].ToString();
                    string persona = String.Format("{0} - {1} -- {2}", nombre, edad, pais);
                    System.Console.WriteLine(persona);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed on db insertion");
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                dataReader.Close();
                Console.WriteLine("------------------------------");
            }
        }

        static bool SelectNombres()
        {
            try
            {
                selectCommand.CommandText = "SELECT Nombre from Personas";
                dataReader = selectCommand.ExecuteReader();

                System.Console.WriteLine("Selecting nombres");
                while (dataReader.Read())
                {
                    string nombre = dataReader["Nombre"].ToString();
                    //string edad = dataReader["Edad"].ToString();
                    //string pais = dataReader["Pais"].ToString();
                    string persona = String.Format("{0}", nombre);
                    System.Console.WriteLine(persona);
                }
                Console.WriteLine("Selection successfull");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed on db insertion");
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                dataReader.Close();
                Console.WriteLine("------------------------------");
            }
        }

        static void Kill()
        {
            try
            {
                connection.Close();
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                if(dataReader != null)
                  dataReader.Close();
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("_________________killed");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            Init();
            Insert();
            Update();
            Delete();
            Select();
            SelectArgentinos();
            SelectNombres();
            Kill();

        }
    }
}
