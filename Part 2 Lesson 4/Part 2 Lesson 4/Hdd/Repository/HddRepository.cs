using Dapper;
using Microsoft.Data.Sqlite;
using Part_2_Lesson_4.Hdd.Dto;
using Part_2_Lesson_4.Hdd.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_2_Lesson_4.Hdd.Repository
{
    public class HddRepository: IHddInterfaces
    {
        public readonly string connectionString = @"Data Source=metrics.db; Version=3;Pooling=True;Max Pool Size=100;";

        public HddRepository()
        {
            SqlMapper.AddTypeHandler(new TimeSpanHadler());
        }

        public IList<HddMetrics> GetAll()
        {
           using(var connect=new SqliteConnection(connectionString))
            {
                return connect.Query<HddMetrics>("SELECT id,Time,value FROM Hddmetrics ").ToList();
            }
        }

        public HddMetrics GetById(int id)
        {
            using (var connect=new SqliteConnection(connectionString))
            {
              return  connect.QuerySingle<HddMetrics>("SELECT id,Time,value FROM Hddmetrcs WHERE id=@id",
                    new
                    {
                        id = id
                    });
            }
        }

        public void Create(HddMetrics item)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Execute("INSERT INTO Hddmetrics (value,time) VALUES(@values,@time)",
                    new
                    {
                        value = item.value,
                        time = item.Time.TotalSeconds
                    });
            }
        }

        public void Update(HddMetrics item)
        {
            using(var connect=new SqliteConnection(connectionString))
            {
                connect.Execute("UPDATE Hddmetrics SET value=@value,Time=@Time,id=@id",
                    new
                    {
                        value = item.value,
                        Time = item.Time.TotalSeconds,
                        id = item.id
                    });
            }
        }

        public void Delete(int id)
        {
            using (var connect= new SqliteConnection(connectionString))
            {
                connect.Execute("DELETE FROM Hddmetrics WHERE id=@id",
                    new
                    {
                        id = id
                    });
            }
        }
    }
}
