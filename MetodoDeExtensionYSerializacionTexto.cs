using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Entidades
{
    public static class GuardaString
    {
        public static bool Guardar(this string texto, string archivo)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                + "\\" + archivo;
	    //si el path no existe tira error, habria q hacer un try catch aca tmb
            StreamWriter sw = new StreamWriter(path, true);
            try
            {
                sw.WriteLine(texto);
            }
            catch (Exception e)
            {
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }
            return false;
        }
    }
}

