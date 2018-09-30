using API.CuentaBasico.Models;
using API.CuentaBasico.Repositories;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace API.CuentaBasico.Controllers
{
    public class CuentasBitcoinsController : ApiController
    {
        private static object locker = new object();
        public static List<string> BitcoinsDesembolsados = new List<string>();

        // GET: api/Cuentas
        [Route("~/api/Cuentas/Bitcoins")]
        [HttpGet]
        public CuentaBitcoins Get()
        {
            return CuentasRepository.CuentaBitcoins;
        }

        [Route("~/api/Cuentas/Bitcoins/{id}")]
        [HttpGet]
        public CuentaBitcoins Get(int id)
        {
            if(CuentasRepository.Cuentas.Count(x => x.Cliente.Id == id) > 0)
            {
                return CuentasRepository.CuentaBitcoins;
            }
            return null;
        }

        [Route("~/api/Cuentas/Bitcoins/Desembolsar")]
        [HttpPut]
        public string Post([FromBody]Bitcoin bitcoin)
        {
            string mensajeConfirmacion = string.Empty;

            if (bitcoin == null || string.IsNullOrEmpty(bitcoin.Id) || string.IsNullOrWhiteSpace(bitcoin.Id))
            {
                lock (locker)
                {
                    if (!BitcoinsDesembolsados.Contains(bitcoin.Id))
                    {
                        BitcoinsDesembolsados.Add(bitcoin.Id);

                        mensajeConfirmacion = "Bitcoin desembolsado";

                        Thread.Sleep(4000);
                    }
                    else
                    {
                        mensajeConfirmacion = "El bitcoin ya fue desembolsado";
                    }
                } 
            }

            return mensajeConfirmacion;
        }

        // PUT: api/CuentasBitcoins/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CuentasBitcoins/5
        public void Delete(int id)
        {
        }
    }
}
