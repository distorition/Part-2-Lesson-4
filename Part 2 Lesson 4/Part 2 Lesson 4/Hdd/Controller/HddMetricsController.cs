using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Part_2_Lesson_4.Hdd.Dto;
using Part_2_Lesson_4.Hdd.Interfaces;
using Part_2_Lesson_4.Hdd.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_2_Lesson_4.Hdd.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HddMetricsController : ControllerBase
    {
        public readonly IHddInterfaces hddIntefaces;
        public readonly IMapper mapper;
        public HddMetricsController(IHddInterfaces hddInter, IMapper mapp)
        {
            hddIntefaces = hddInter;
            mapper = mapp;
        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            IList<HddMetrics> hddMetrics = hddIntefaces.GetAll();
            var Hddmet = new HddMetricsPesponse()
            {
                HddMetric = new List<HddMetricsDto>()
            };
            foreach(var meta in hddMetrics)
            {
                Hddmet.HddMetric.Add(mapper.Map<HddMetricsDto>(meta));
            }
            return Ok();

        }
    }
}
