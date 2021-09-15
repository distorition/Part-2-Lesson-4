using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Part_2_Lesson_4.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_2_Lesson_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapperController : ControllerBase
    {
        private readonly AgainRepositry reposittory;
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CpuMetrics, CpuMetricsDto>());//первй тип это что мы передаем второй тип это куда передаем то есть данные из CpuMetrics передаем в CpuMetricsDto
            var mapper = config.CreateMapper();
            IList<CpuMetrics> metrics = reposittory.GeatAll();
            var response = new AllCpuMetricsResponse()
            {
                Metrics = new List<CpuMetricsDto>()
            };
            foreach (var metric in metrics)
            {
                response.Metrics.Add(mapper.Map<CpuMetricsDto>(metric));
            }
            return Ok();
        }
       
    }
}
