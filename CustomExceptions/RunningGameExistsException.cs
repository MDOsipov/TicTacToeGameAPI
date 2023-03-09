﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    public class RunningGameExistsException : CustomException
    {
        public RunningGameExistsException(string message)
            :base(message)
        {

        }
    }
}

