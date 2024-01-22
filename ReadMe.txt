[V]新增方案資料夾，新增專案
	01表現層：
		SparkleAir.FrontEnd.Site (MVC)

	02商業邏輯層：
		SparkleAir.BLL.Service (類別庫)
		SparkleAir.IDAL.IRepository (類別庫)

	03資料存取層：
		SparkleAir.DAL.DapperRepository (類別庫)
		SparkleAir.DAL.DTORepository (類別庫)
		SparkleAir.DAL.EFRepository (類別庫)

	04基礎建設層：
		SparkleAir.Infa.Dto (類別庫)
		SparkleAir.Infa.EFModel (類別庫)
		SparkleAir.Infa.Entity (類別庫)
		SparkleAir.Infa.Utility (類別庫)

	05單元測試：
		SparkleAir.FrontEnd.Site.Tests

[V]加入參考
	SparkleAir.FrontEnd.Site 參考：
		SparkleAir.BLL.Service
		SparkleAir.IDAL.IRepository
		SparkleAir.DAL.DapperRepository
		SparkleAir.DAL.DTORepository
		SparkleAir.DAL.EFRepository
		SparkleAir.Infa.Dto
		SparkleAir.Infa.EFModel
		SparkleAir.Infa.Utility


	SparkleAir.BLL.Service 參考：
		SparkleAir.IDAL.IRepository
		SparkleAir.Infa.Dto
		SparkleAir.Infa.Entity
		SparkleAir.Infa.Utility

	SparkleAir.IDAL.IRepository 參考：
		SparkleAir.Infa.Dto
		SparkleAir.Infa.Entity

	SparkleAir.DAL.DapperRepository, SparkleAir.DAL.DTORepository, SparkleAir.DAL.EFRepository
	以上三個 Repository 參考的內容是一樣的：
		SparkleAir.IDAL.IRepository
		SparkleAir.Infa.EFModel
		SparkleAir.Infa.Entity
		SparkleAir.Infa.Utility
		
	SparkleAir.Infa.Utility 參考：
		SparkleAir.Infa.Dto
		SparkleAir.Infa.EFModel
		SparkleAir.Infa.Entity
		

[V]EFModel
	建立ADO.NET實體資料模型（AppDbContext）
	完成後把App.config 的 <connectionStrings>
	移至SparkleAir.FrontEnd.Site 的 Web.config 裡面
	
[V]Dapper
	在 SparkleAir.Infa.Utility 加入：
		參考：
			System.Configuration (這樣才能讀取連線字串)

		取得資料庫連線字串的方法：
			SqlDbHelper.GetConnectionString()

	在 SparkleAir.DAL.DapperRepository 呼叫Helper.GetSqlString()取得連線字串
		

[V]管理NuGet套件
	SparkleAir.FrontEnd.Site：
		加入：Dapper
		移除：EntityFramework 中文套件

	SparkleAir.DAL.EFRepository：
		加入：EntityFramework

	SparkleAir.DAL.DapperRepository：
		加入：Dapper

[V]建置方案