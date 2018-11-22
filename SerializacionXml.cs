using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Metodo encargado de serializar un objeto en un archivo XML
        /// </summary>
        /// <param name="archivo">Path del archivo</param>
        /// <param name="datos">Objeto a ser serializado</param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            ///Se utiliza XmlWriter debido a que XmlTextWriter no esta disponible
            ///Microsoft recomienda la utilizacion de esta clase a partir de .net 2.0
            ///https://docs.microsoft.com/es-es/dotnet/api/system.xml.xmltextwriter?redirectedfrom=MSDN&view=netframework-4.7.2
            XmlWriter xmlWriter = XmlWriter.Create(archivo);
            XmlSerializer ser = new XmlSerializer(typeof(T));
            try
            {
                ser.Serialize(xmlWriter, datos);
                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                xmlWriter.Close();
            }

        }

        /// <summary>
        /// Metodo encargado de des-serializar un archivo XML a un objeto
        /// </summary>
        /// <param name="archivo">Path del archivo</param>
        /// <param name="datos">Variable donde se guardara el objeto des-serializado</param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            ///Se utiliza XmlReader debido a que XmlReader no esta disponible
            ///Microsoft recomienda la utilizacion de esta clase a partir de .net 2.0
            ///https://docs.microsoft.com/es-es/dotnet/api/system.xml.xmltextreader?redirectedfrom=MSDN&view=netframework-4.7.2
            XmlReader xmlReader = XmlReader.Create(archivo);
            XmlSerializer ser = new XmlSerializer(typeof(T));
            try
            {
                datos = (T)ser.Deserialize(xmlReader);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                xmlReader.Close();
            }

        }
    }
}

