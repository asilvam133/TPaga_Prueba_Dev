using API.CuentaBasico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace API.CuentaBasico.Repositories
{
    public class CuentasRepository
    {
        private static List<Cuenta> _cuentas;

        public static List<Cuenta> Cuentas
        {
            get
            {
                if (_cuentas == null)
                {
                    _cuentas = new List<Cuenta>();
                    Cliente cliente = new Cliente
                    {
                        Id = 1,
                        Nombre = "Cliente TPaga",
                        Telefono = "3216549870",
                        Direccion = "Calle 1 # 1-1",
                        Ciudad = "Bogotá"
                    };

                    Cuenta cuenta = new Cuenta
                    {
                        Id = 1,
                        Numero = "6665554466",
                        Saldo = 4000000,
                        Cliente = cliente
                    };

                    _cuentas.Add(cuenta);
                }

                return _cuentas;
            }
            set
            {
                _cuentas = value;
            }
        }

        private static CuentaBitcoins _cuentaBitcoins;

        public static CuentaBitcoins CuentaBitcoins
        {
            get
            {
                if (_cuentaBitcoins == null)
                {
                    _cuentaBitcoins = new CuentaBitcoins();
                    _cuentaBitcoins.Cuenta = CuentasRepository.Cuentas[0];
                    _cuentaBitcoins.Bitcoins = new List<Bitcoin>();

                    for (int i = 3; i > 0; i--)
                    {
                        _cuentaBitcoins.Bitcoins.Add(ConstruirBitcoin(_cuentaBitcoins.Cuenta, DateTime.Now.AddDays((-1) * i)));
                    }
                }

                return _cuentaBitcoins;
            }
            set { _cuentaBitcoins = value; }
        }

        private static Bitcoin ConstruirBitcoin(Cuenta cuenta, DateTime fechaEmision)
        {
            Bitcoin bitcoin = new Bitcoin();
            bitcoin.FechaEmision = fechaEmision;

            string inputStream = cuenta.Id + cuenta.Numero + bitcoin.FechaEmision.ToString("yyyy-MM-dd HH:mm:ss");

            SHA1 sha1 = SHA1Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha1.ComputeHash(encoding.GetBytes(inputStream));
            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }

            bitcoin.Id = sb.ToString();
            return bitcoin;
        }

    }
}