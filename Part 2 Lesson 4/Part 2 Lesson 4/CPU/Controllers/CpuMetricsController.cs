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
    public class CpuMetricsController : ControllerBase
    {
        private readonly AgainRepositry reposittory;
        private readonly IMapper mapper;
        public CpuMetricsController(AgainRepositry repository,IMapper maper)
        {
            reposittory = repository;
            mapper = maper;
        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            IList<CpuMetrics> metrics = reposittory.GeatAll();
            var response = new AllCpuMetricsResponse()
            {
                Metrics = new List<CpuMetricsDto>()
                
            };
            foreach (var met in metrics)
            {
                response.Metrics.Add(mapper.Map<CpuMetricsDto>(met));
            }
            return Ok();
        }
    }
}
