using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SparkleAir.Infa.Utility.Helper
{
    public class UploadHelper
    {
        public string UploadImageFile(HttpPostedFileBase file, string path)
        {
            //判斷有無上傳檔案，沒有則丟出例外
            if (file == null || file.ContentLength == 0) throw new ArgumentNullException("file");
            //取得檔名並判斷是否為允許的檔案類型

            string[] allowExts = { ".jpg", ".jpeg", "png" };
            string ext = Path.GetExtension(file.FileName).ToLower();
            if (!allowExts.Contains(ext)) throw new ArgumentException($"不允許上傳此類檔案({ext})");
            //為避免不同時間上傳相同檔名，每次要取唯一檔名
            string fileName = Path.GetRandomFileName();
            //與副檔名合併成正常檔名
            string newFileName = fileName + ext;
            string fullName = Path.Combine(path, newFileName);
            //存放上傳檔案並取得檔名
            file.SaveAs(fullName);

            return newFileName;
        }
    }
}
