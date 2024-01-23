using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.Utility.Helper
{
    public static class TimeZoneHelper
    {
        /// <summary>
        /// 把當地時間轉換成 GMT
        /// </summary>
        /// <param name="localTime"></param>
        /// <param name="timeZone"></param>
        /// <returns></returns>
  
        public static DateTime ConvertToGMT(string localTime, int timeZone)
        {
            DateTime localDateTime = DateTime.ParseExact(localTime, "yyyy-MM-dd HH:mm:ss", null, System.Globalization.DateTimeStyles.AssumeLocal);
            TimeSpan timeOffset = TimeSpan.FromHours(timeZone);
            DateTime gmtTime = localDateTime - timeOffset;
            return gmtTime;
        }

        public static DateTime ConvertToLocal(DateTime gmtTime, int timeZone)
        {
            TimeSpan timeOffset = TimeSpan.FromHours(timeZone);
            DateTime localTime = gmtTime + timeOffset;
            return localTime;
        }
    }
}
