﻿using System;

namespace Gallifrey.Exceptions.IntergrationPoints
{
    public class NoResultsFoundException : Exception
    {
        public NoResultsFoundException(string message)
            : base(message)
        {

        }

        public NoResultsFoundException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
