using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    public class PlaceOccupiedException : CustomException
    {
        public PlaceOccupiedException(string message)
            :base(message)
        {

        }
    }
}
