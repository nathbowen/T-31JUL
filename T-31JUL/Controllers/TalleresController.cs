using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T_31JUL.Data;
using T_31JUL.Model;

namespace T_31JUL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalleresController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Talleres> Get()
        {
            var talleres = new List<Talleres>
            {
                new Talleres { IdTaller = 1, Nombre="Introducción a la Programación", Descripcion="Descripcion", FechaInicio=new DateTime(2023, 08, 31), DuracionHoras=5, CupoMaximo=10, Inscripciones=2}
            };

            return talleres;
        }
    }
}
