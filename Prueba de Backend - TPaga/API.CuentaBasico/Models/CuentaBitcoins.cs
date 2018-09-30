using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.CuentaBasico.Models
{
    public class CuentaBitcoins
    {
        private List<Bitcoin> _bitcoins;

        public List<Bitcoin> Bitcoins
        {
            get { return _bitcoins; }
            set { _bitcoins = value; }
        }

        private Cuenta _cuenta;

        public Cuenta Cuenta
        {
            get { return _cuenta; }
            set { _cuenta = value; }
        }

    }
}