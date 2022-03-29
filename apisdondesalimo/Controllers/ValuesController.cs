using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using apisdondesalimo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apisdondesalimo.Controllers
{
    [Route("api/Cliente")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Clientes> Get()
        {
            Clientes cliente1 = new Clientes();
            cliente1.documento = 36948269;
            cliente1.email = "Lpopowsky@gmail.com";
            cliente1.idCliente = 1;
            cliente1.nickname = "lucseat";
            cliente1.nombre = "lucas";
            cliente1.password = "pepe";
            cliente1.telefono = 12345678;
            cliente1.tipoDocumento = "DNI";
            cliente1.usuario = "Lucseat";
            return new Clientes[] { cliente1  };
        }

       
    }
}
