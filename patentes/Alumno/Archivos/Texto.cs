using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;

namespace Archivos
{
    public class Texto : IArchivo<Queue<Patente>>
    {
        public void Guardar(string archivo, Queue<Patente> datos)
        {
            Queue<Patente> retorno = new Queue<Patente>();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo;

            StreamWriter sw = new StreamWriter(path);

            StringBuilder sb = new StringBuilder();

            foreach (Patente p in datos)
                sb.AppendLine(p.CodigoPatente);

            try
            {
                sw.Write(sb.ToString());
                sw.Close();
            }catch(Exception e)
            {

            }
        }   

        public void Leer(string archivo, out Queue<Patente> datos)
        {
            Queue<Patente> retorno = new Queue<Patente>();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo;

            StreamReader sr = new StreamReader(path);

            try
            {
                while(sr.ReadLine() != null)
                {
                    Patente p = sr.ReadLine().ValidarPatente();
                    retorno.Enqueue(p);
                }
                sr.Close();
            }catch(Exception e)
            {

            }

            datos = retorno;
        }
    }
}
