using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.Utility.Helper
{
	public class SqlDbHelper
	{
		/// <summary>
		/// 取得字串連線
		/// </summary>
		/// <param name="keyOfConn">連線的key值</param>
		/// <returns></returns>
		public static string GetConnectionString(string keyOfConn)
		{
			try
			{
				string conn = System.Configuration.ConfigurationManager.ConnectionStrings[keyOfConn].ToString();
				return conn;
			}
			catch (Exception )
			{
				throw new Exception($"找不到名為 {keyOfConn} 的連線字串");
			}
		}
	}
}
