using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlConnection _conexion;
        private static SqlCommand _comando;

        static PaqueteDAO()
        {
            string connectionString = "Data Source=.\\SQLEXPRESS; Initial Catalog=correo-sp-2017; Integrated Security=True;";
            _conexion = new SqlConnection(connectionString);
        }

        public static bool Insertar(Paquete p)
        {
            try
            {
                _conexion.Open();
                string alumno = "Franco Canevali";
		//Paquetes es la tabla, correo-sp-2017 la base de datos
                string insertCommand = String.Format("INSERT INTO Paquetes (direccionEntrega,trackingID,alumno) " +
                                        "VALUES('{0}','{1}','{2}')", 
                                        p.DireccionEntrega, p.TrackingId, alumno);
                _comando = new SqlCommand(insertCommand, _conexion);
                _comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (_conexion != null)
                    _conexion.Close();
            }

        }

      
    }
}

