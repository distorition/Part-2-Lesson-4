using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_2_Lesson_4.Interfaces
{
  public  interface ICpuMetricsRepository<T>where T:class
    {
        IList<T> GeatAll();
        T GetById(int id);
        void Create(T item);
        void Update(T ittem);
        void Delte(int id);


    }
}
