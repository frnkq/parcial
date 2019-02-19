using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MyException : Exception
    {
		public MyException()
		{
			
		}
        public MyException(string mensaje) : base(mensaje)
        {

        }
        public MyException(string mensaje, Exception inner) : base(mensaje, inner)
        {

        }
    }
}

