[V]�s�W��׸�Ƨ��A�s�W�M��
	01��{�h�G
		SparkleAir.FrontEnd.Site (MVC)
		SparkleAir.Web.API (API)

	02�ӷ~�޿�h�G
		SparkleAir.BLL.Service (���O�w)
		SparkleAir.IDAL.IRepository (���O�w)

	03��Ʀs���h�G
		SparkleAir.DAL.DapperRepository (���O�w)
		SparkleAir.DAL.DTORepository (���O�w)
		SparkleAir.DAL.EFRepository (���O�w)

	04��¦�س]�h�G
		SparkleAir.Infa.Criteria (���O�w)
		SparkleAir.Infa.Dto (���O�w)
		SparkleAir.Infa.EFModel (���O�w)
		SparkleAir.Infa.Entity (���O�w)
		SparkleAir.Infa.Utility (���O�w)
		SparkleAir.Infa.ViewModel (���O�w)

	05�椸���աG
		SparkleAir.FrontEnd.Site.Tests
		SparkleAir.Web.API.Tests

[V]�[�J�Ѧ�
	SparkleAir.FrontEnd.Site �ѦҡG
		SparkleAir.BLL.Service
		SparkleAir.IDAL.IRepository
		SparkleAir.DAL.DapperRepository
		SparkleAir.DAL.DTORepository
		SparkleAir.DAL.EFRepository
		SparkleAir.Infa.Dto
		SparkleAir.Infa.EFModel
		SparkleAir.Infa.Utility
		SparkleAir.Infa.Criteria
		SparkleAir.Infa.ViewModel

	SparkleAir.BLL.Service �ѦҡG
		SparkleAir.IDAL.IRepository
		SparkleAir.Infa.Dto
		SparkleAir.Infa.Entity
		SparkleAir.Infa.Utility
		SparkleAir.Infa.Criteria

	SparkleAir.IDAL.IRepository �ѦҡG
		SparkleAir.Infa.Dto
		SparkleAir.Infa.Entity
		SparkleAir.Infa.Criteria

	SparkleAir.DAL.DapperRepository, SparkleAir.DAL.DTORepository, SparkleAir.DAL.EFRepository
	�H�W�T�� Repository �ѦҪ����e�O�@�˪��G
		SparkleAir.IDAL.IRepository
		SparkleAir.Infa.EFModel
		SparkleAir.Infa.Entity
		SparkleAir.Infa.Utility
		SparkleAir.Infa.Criteria
		
	SparkleAir.Infa.Utility �ѦҡG
		SparkleAir.Infa.Dto
		SparkleAir.Infa.EFModel
		SparkleAir.Infa.Entity
		

[V]EFModel
	�إ�ADO.NET�����Ƽҫ��]AppDbContext�^
	�������App.config �� <connectionStrings>
	����SparkleAir.FrontEnd.Site �� Web.config �̭�
	
[V]Dapper
	�b SparkleAir.Infa.Utility �[�J�G
		�ѦҡG
			System.Configuration (�o�ˤ~��Ū���s�u�r��)

		���o��Ʈw�s�u�r�ꪺ��k�G
			SqlDbHelper.GetConnectionString()

	�b SparkleAir.DAL.DapperRepository �I�sHelper.GetSqlString()���o�s�u�r��
		

[V]�޲zNuGet�M��
	SparkleAir.FrontEnd.Site�G
		�[�J�GDapper
		�����GEntityFramework ����M��

	SparkleAir.DAL.EFRepository�G
		�[�J�GEntityFramework

	SparkleAir.DAL.DapperRepository�G
		�[�J�GDapper

[V]�ظm���

[]�ظmAPI�M��
	Global.asax�[�J�H�U�{���X�A�F���^�Ǫ�Data��JSON�榡
		GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

	�޲z�M��[�J�G
		EntityFramework
		Dapper

	�[�J�Ѧ�
		SparkleAir.BLL.Service
		SparkleAir.IDAL.IRepository
		SparkleAir.DAL.DapperRepository
		SparkleAir.DAL.DTORepository
		SparkleAir.DAL.EFRepository
		SparkleAir.Infa.Dto
		SparkleAir.Infa.EFModel
		SparkleAir.Infa.Utility
		SparkleAir.Infa.Criteria
		SparkleAir.Infa.ViewModel

		