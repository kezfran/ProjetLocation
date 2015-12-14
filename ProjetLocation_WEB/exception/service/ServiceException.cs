﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLocation.service
{
    public class ServiceException : Exception
    {
        /**
     * Constructs a new exception with null as its detail message. The cause is not initialized, and may subsequently be initialized by a call
     * to {@link java.lang.Throwable#initCause(java.lang.Throwable) Throwable.initCause(Throwable)}.
     */
        public ServiceException() : base() { }
        /**
       * Constructs a new exception with the specified detail message. The cause is not initialized, and may subsequently be initialized by a call
       * to {@link java.lang.Throwable#initCause(java.lang.Throwable) Throwable.initCause(Throwable)}.
       * 
       * @param message The detail message. The detail message is saved for later retrieval by the
       *        {@link java.lang.Throwable#getMessage() Throwable.getMessage()} method
       */
        public ServiceException(string message) : base(message) { }

        public ServiceException(string message, Exception cause) : base(message, cause) { }
    }
}
