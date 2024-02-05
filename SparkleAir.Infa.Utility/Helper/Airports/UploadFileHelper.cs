using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SparkleAir.Infa.Utility.Helper.Airports
{
    public class UploadFileHelper
    {
        /// <summary>
		/// 將上傳檔案存放到指定資料夾
		/// </summary>
		/// <param name="file">上傳的檔案</param>
		/// <param name="path">檔案存放資料夾</param>
		/// <returns>回傳實際存檔的檔名</returns>
		/// <exception cref="ArgumentNullException">若沒上傳檔案,丟出此例外</exception>
		/// <exception cref="ArgumentException">上傳非圖片檔案,丟出此例外</exception>
		/// <exception cref="Exception">指定的資料夾不存在,丟出此例外</exception>
		public string UploadImageFile(HttpPostedFileBase file, string path)
        {
            //判斷資料夾是否存在
            if (!Directory.Exists(path)) throw new Exception($"資料夾不存在{path}");

            //判斷有沒有上傳檔案,若沒有,丟出此例外
            if (file == null || file.ContentLength == 0) throw new ArgumentNullException("file");
            //取得副檔名並判斷是不是允許的檔案類型
            string[] allowExts = { ".jpg", ".jpeg", ".png", ".gif" };
            string ext = Path.GetExtension(file.FileName).ToLower();

            if (!allowExts.Contains(ext)) throw new ArgumentException($"不允許上傳此類檔案{ext}");

            //為了避免不同時間上傳相同檔名,造成覆蓋,所以每次都要取得一個唯一的檔名
            string fileName = Path.GetRandomFileName();


            //與副檔名合併成一個正常檔名
            string newFileName = fileName + ext;
            string fullName = Path.Combine(path, newFileName);
            //將上傳檔案存放,並取得檔名
            file.SaveAs(fullName);

            return newFileName;



        }
    }
}
