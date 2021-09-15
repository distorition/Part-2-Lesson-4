using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_2_Lesson_4
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<CpuMetrics, CpuMetricsDto>();
        }
    }
}
