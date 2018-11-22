using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Metodo encargado de guardar en un archivo de texto los datos pasados por parametro
        /// Si existe el archivo lo sobreescribe, si no, lo crea
        /// </summary>
        /// <param name="archivo">Path del archivo</param>
        /// <param name="datos">Datos a escribir en el archivo</param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter sw = new StreamWriter(archivo);
            try
            {
                sw.Write(datos);
                return true;
            }catch(Exception e)
            {
                return false;
            }
            finally
            {
                if(sw != null)
                {
                    sw.Close();
                }
            }
        }

        /// <summary>
        /// Metodo encargado de leer los datos de un archivo de texto
        /// </summary>
        /// <param name="archivo">Path del archivo</param>
        /// <param name="datos">Variable donde se guardara el archivo</param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            StreamReader sr = new StreamReader(archivo);
            datos = "";
            try
            {
                datos = sr.ReadToEnd();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }
        }
    }
}

