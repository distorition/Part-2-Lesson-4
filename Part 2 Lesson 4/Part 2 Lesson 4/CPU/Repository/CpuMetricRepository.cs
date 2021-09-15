using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_2_Lesson_4
{
    public class CpuMetricRepository: IRepository<CpuMetrics>
    {
        private const string ConnectionString = @"Data Source=metrics.db; Version=3;Pooling=True;Max Pool Size=100;";
        public CpuMetricRepository()
        {
            SqlMapper.AddTypeHandler(new TimeSpanHadler());
        }

        public void Create(CpuMetrics item)
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Execute("INSERT INTO cpumetrics(value, time) VALUES(@value, @time)",
                    new
                    {
                        value = item.Value,
                        time = item.Time.TotalSeconds
                    });
            }


        }

        public void Delete(int id)
        {
         using (var conncetion=new SqliteConnection(ConnectionString))
            {
                conncetion.Execute("DELETE FROM cpumetrics WHERE id=@id",
                    new
                    {
                        id = id
                    });

            }
        }

        public IList<CpuMetrics> GetAll()
        {
            using(var connection= new SqliteConnection(ConnectionString))
            {
                return connection.Query<CpuMetrics>("SELECT id ,Time,Value FROM cpumetrics").ToList();
            }
        }

        public CpuMetrics GetById(int id)
        {
           using (var conncetion= new SqliteConnection(ConnectionString))
            {
               return  conncetion.QuerySingle<CpuMetrics>("SELECT id,Time,value FROM cpumetrics WHERE @id=id",
                    new
                    {
                        id = id
                    });
            }
        }

        public void Update(CpuMetrics item)
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Execute("UPDATE cpumetrics SET value = @value, time = @time WHERE id=@id",
                    new
                    {
                        value = item.Value,
                        time = item.Time.TotalSeconds,
                        id = item.id
                    });
            }
        }
    }
}
