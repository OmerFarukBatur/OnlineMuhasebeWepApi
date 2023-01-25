using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeWepApi.Presentation.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeWepApi.Presentation.Controller
{
    public sealed class TestController : ApiController
    {
        [HttpGet]
        public IActionResult Deneme()
        {
            return Ok("Başarılı");
        }
    }
}
