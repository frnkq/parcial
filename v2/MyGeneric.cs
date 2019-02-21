using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreLibs
{
    public class MyGeneric<T,U> where T : class, new() where U : struct
    {
        T key;
        U value;
        Dictionary<T, U> diccionario;

        public MyGeneric()
        {
            diccionario = new Dictionary<T, U>();
        }

        //MyGeneric<StringBuilder, int> gen = new MyGeneric<StringBuilder, int>();
    }
}
