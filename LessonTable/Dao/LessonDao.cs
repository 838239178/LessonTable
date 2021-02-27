using LessonTable.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace LessonTable.Dao
{

    public class LessonDao
    {
        private readonly LessonModel model;

        public LessonDao()
        {
            model = new LessonModel();
        }

        private T WaitResult<T>(Task<T> task)
        {
            task.Wait();
            return task.Result;
        }

        public List<lesson> GetLessons(string teacher)
        {
            DbSqlQuery<lesson> ls = model.lesson.SqlQuery("select * from dbo.lesson where teacher = {0}", teacher);
            return WaitResult(ls.ToListAsync());
        }

        public List<lesson> GetLessons(int day, int time)
        {
            DbSqlQuery<lesson> ls = model.lesson.SqlQuery("select * from dbo.lesson where time = {0} and day = {1}", time, day);
            return WaitResult(ls.ToListAsync());
        }
    }
}
