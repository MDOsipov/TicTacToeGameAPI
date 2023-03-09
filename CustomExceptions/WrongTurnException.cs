using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    public class WrongTurnException : CustomException
    {
        public WrongTurnException(string message)
            :base(message)
        {

        }
    }
}
