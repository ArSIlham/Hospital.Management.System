using System.Data.SqlClient;

namespace Hospital.Management.System.Data.IUnitOfWork
{
	public interface IUnitOfWork
	{
		SqlTransaction BeginTransaction();

		SqlConnection GetConnection();

		SqlTransaction GetTransaction();

		void SaveChanges();
	}
}
