using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LainsaSciModelo
{
    public class ErrorControl
    {
        private DateTime errorDateTime;

        public DateTime ErrorDateTime
        {
            get { return errorDateTime; }
            set { errorDateTime = value; }
        }
        private Usuario errorUsuario;

        public Usuario ErrorUsuario
        {
            get { return errorUsuario; }
            set { errorUsuario = value; }
        }
        private Exception errorException;

        public Exception ErrorException
        {
            get { return errorException; }
            set { errorException = value; }
        }

        private Proceso errorProcess;

        public Proceso ErrorProcess
        {
            get { return errorProcess; }
            set { errorProcess = value; }
        }
    }
}
