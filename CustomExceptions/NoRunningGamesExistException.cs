﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    public class NoRunningGamesExistException : CustomException
    {
        public NoRunningGamesExistException(string message)
            :base(message)
        {

        }
    }
}
