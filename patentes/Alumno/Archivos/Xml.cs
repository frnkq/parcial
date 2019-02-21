using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Entidades;

namespace Archivos
{
    public class Xml : IArchivo<Queue<Patente>>
    {
        public void Guardar(string archivo, Queue<Patente> datos)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo;

            XmlWriter writer = XmlWriter.Create(path);
            XmlSerializer ser = new XmlSerializer(typeof(Queue<Patente>));

            try
            {
                ser.Serialize(writer, datos);
                writer.Close();
            }catch(Exception e)
            {

            }
            
        }

        public void Leer(string archivo, out Queue<Patente> datos)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo;
            XmlReader reader = XmlReader.Create(path);
            XmlSerializer ser = new XmlSerializer(typeof(Patente[]));
            Patente[] fromFile = null;
            try
            {
                fromFile = (Patente[])ser.Deserialize(reader);

                reader.Close();
            }catch(Exception e)
            {

            }
            Queue<Patente> retorno = new Queue<Patente>();
            foreach(Patente p in fromFile)
            {
                retorno.Enqueue(p);
            }

            datos = retorno;
        }
    }
}
