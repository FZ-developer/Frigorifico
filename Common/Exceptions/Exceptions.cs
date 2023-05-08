using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class Exceptions : Exception
    {
        public Exceptions(string mensaje) : base(mensaje)
        {

        }
    }
}
