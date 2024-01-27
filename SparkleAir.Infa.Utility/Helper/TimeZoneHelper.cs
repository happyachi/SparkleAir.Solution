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
  
        public static TimeSpan ConvertToGMT(TimeSpan localTime, int timeZone)
        {
            TimeSpan timeOffset = TimeSpan.FromHours(timeZone);
            TimeSpan gmtTime = localTime - timeOffset;
            return AdjustTimeToValidRange(gmtTime); 
        }

        public static TimeSpan ConvertToLocal(TimeSpan gmtTime, int timeZone)
        {
            TimeSpan timeOffset = TimeSpan.FromHours(timeZone);
            TimeSpan localTime = gmtTime + timeOffset; 
            return AdjustTimeToValidRange(localTime);
        }

        private static TimeSpan AdjustTimeToValidRange(TimeSpan time)
        {
            // 將時間值調整為有效範圍
            if (time < TimeSpan.Zero)
            {
                return TimeSpan.FromHours(24) + time; // 將負值時間轉換為對應的正值時間
            }
            else if (time > TimeSpan.FromHours(23) + TimeSpan.FromMinutes(59) + TimeSpan.FromSeconds(59))
            {
                return TimeSpan.FromHours(0) +time;
            }
            else
            {
                return time;
            }
        }
    }
}
