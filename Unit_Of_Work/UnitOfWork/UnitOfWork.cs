using Microsoft.EntityFrameworkCore;
using Unit_Of_Work.DMO;
using Unit_Of_Work.Repository;

namespace Unit_Of_Work.UnitOfWork
{
	public class UnitOfWork : IDisposable
	{

		AuthContext _context;
		public IRepository<Authentication> _authRepository;
		public UnitOfWork(IRepository<Authentication> repository,AuthContext context)
		{
			_context= context;
			_authRepository= repository;
		}
		public void Save()
		{
			try
			{
				using (var transaction =  _context.Database.BeginTransaction())
				{
					try
					{
						// hata yoksa ise, işlem veri tabanına kaydedilsin.
						_context.SaveChanges();
						transaction.Commit();
					}
					catch (Exception ex)
					{
						//hata alındı işlemler geri alınıyor 
						transaction.Rollback();
					}
				}

			}catch (Exception ex)
			{

			}

		}

		
				
	



        public void Dispose()
		{
			// veri tabanını bellekten düşür
			_context.Dispose();

			// GC : Garbage Collection
			// Gel Bu nesneyi bellekten sil
			GC.SuppressFinalize(this);


		}
	}
}
