using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LainsaSciModelo
{
    public class DireccionView
    {
        private Direccion direccion;

        public Direccion Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        private String poseedor;

        public String Poseedor
        {
            get { return poseedor; }
            set { poseedor = value; }
        }
    }
}
