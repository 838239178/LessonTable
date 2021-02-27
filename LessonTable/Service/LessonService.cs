using LessonTable.Dao;
using LessonTable.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonTable.Service
{
    public class LessonService
    {
        private static LessonService instance = null;
        public static LessonService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LessonService();
                }
                return instance;
            }
        }

        private readonly LessonDao dao;

        private LessonService()
        {
            dao = new LessonDao();
        }

        private string WeekMode(int validWeek)
        {
            return validWeek % 2 == 0 ? "double" : "single";
        }

        public lesson GetValidLesson(int day, int time, int validWeek)
        {
            List<lesson> ls = dao.GetLessons(day, time);
            string mode = WeekMode(validWeek); 
            foreach (var item in ls)
            {
                if(item.startweek <= validWeek && item.endweek >= validWeek)
                {
                    if (mode.Equals(item.mode) || "normal".Equals(item.mode)) 
                        return item;
                }
            }

            return new lesson();
        }
    }
}
