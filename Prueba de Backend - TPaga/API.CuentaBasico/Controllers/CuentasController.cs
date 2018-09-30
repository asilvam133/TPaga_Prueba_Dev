using API.CuentaBasico.Models;
using API.CuentaBasico.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.CuentaBasico.Controllers
{
    public class CuentasController : ApiController
    {
        // GET: api/Cuentas
        [Route("~/api/Cuentas")]
        [HttpGet]
        public IEnumerable<Cuenta> Get()
        {
            return CuentasRepository.Cuentas as IEnumerable<Cuenta>;
        }

        // GET: api/Cuentas/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cuentas
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Cuentas/5
        [Route("~/api/Cuentas/{id}/AgregarSaldo")]
        [HttpPut]
        public void Put(int id, [FromBody]Cuenta cuenta)
        {
            Cuenta _cuenta = CuentasRepository.Cuentas.Find(x => x.Id == id);
            _cuenta.Saldo += cuenta.Saldo;
        }

        // PUT: api/Cuentas/5
        [Route("~/api/Cuentas/{id}/SaldoCero")]
        [HttpPut]
        public void Put(int id)
        {
            Cuenta _cuenta = CuentasRepository.Cuentas.Find(x => x.Id == id);
            _cuenta.Saldo = 0;
        }

        // DELETE: api/Cuentas/5
        public void Delete(int id)
        {
        }
    }
}
