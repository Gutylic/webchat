using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class logicaPanelUsuario
    {
        public int erroresPassword(string password)
        {
            if (password.Length > 5 || password.Length <= 10)
            {
                return 1;
            }
            return -1;
        }

    }
}
