using AutoMapper;
using Part_2_Lesson_4.Hdd.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_2_Lesson_4.Hdd.Mapper
{
    public class MapperHdd:Profile
    {
       public MapperHdd()
        {
            CreateMap<HddMetrics, HddMetricsDto>();
        }
    }
}
