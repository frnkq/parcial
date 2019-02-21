using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using Entidades;

namespace Archivos
{
    public class Sql : IArchivo<Queue<Patente>>
    {
        protected SqlCommand comando;
        protected SqlConnection conexion;

        public Sql()
        {
            this.comando = new SqlCommand();
            this.comando.CommandType = CommandType.Text;

            string connectionString = "Data Source=.\\SQLEXPRESS; Initial Catalog=patentes-sp-2018; Integrated Security=True;";
            this.conexion = new SqlConnection(connectionString);
        }

        public void Guardar(string archivo, Queue<Patente> datos)
        {
            
            try
            {
                this.conexion.Open();
                this.comando.Connection = this.conexion;

                foreach (Patente p in datos)
                {
                    this.comando.CommandText = String.Format("INSERT INTO {0} (patente,tipo) VALUES('{1}','{2}')", 
                    archivo, p.CodigoPatente, p.TipoCodigo.ToString());

                    try
                    {
                        this.comando.ExecuteNonQuery();
                    }catch(Exception e)
                    {

                    }
                }
                this.conexion.Close();
            }catch(Exception e)
            {

            }
            throw new NotImplementedException();
        }

        public void Leer(string archivo, out Queue<Patente> datos)
        {
            Queue<Patente> retorno = new Queue<Patente>();
            try
            {
                this.conexion.Open();

                this.comando.CommandText = "SELECT * FROM " + archivo;
                this.comando.Connection = this.conexion;

                SqlDataReader dataReader = this.comando.ExecuteReader();

                Patente p;
               
                while(dataReader.Read())
                {
                    p = new Patente(dataReader["patente"].ToString(), 
                        (Patente.Tipo)Enum.Parse(typeof(Patente.Tipo), dataReader["tipo"].ToString()));

                    retorno.Enqueue(p);
                }
                dataReader.Close();
                this.conexion.Close();

                
            }catch(Exception e)
            {

            }
            datos = retorno;
        }
    }
}
