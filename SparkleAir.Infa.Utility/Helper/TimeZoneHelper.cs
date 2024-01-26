﻿using System;
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
            return gmtTime;
		}

        public static TimeSpan ConvertToLocal(TimeSpan gmtTime, int timeZone)
        {
            TimeSpan timeOffset = TimeSpan.FromHours(timeZone);
            TimeSpan localTime = gmtTime + timeOffset;
            return localTime;
        }
    }
}
