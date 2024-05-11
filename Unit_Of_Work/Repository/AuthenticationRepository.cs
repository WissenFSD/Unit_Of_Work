using Unit_Of_Work.DMO;

namespace Unit_Of_Work.Repository
{
	public class AuthenticationRepository : IRepository<Authentication>
	{
		public AuthContext _context;

		public AuthenticationRepository(AuthContext context)
        {
            _context= context;
        }
        public bool Add(Authentication model)
		{
			_context.Add(model);

			return true;
		}
	}
}
