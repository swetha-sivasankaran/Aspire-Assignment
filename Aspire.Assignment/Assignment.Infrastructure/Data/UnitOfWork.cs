using Assignment.Contracts.Data;
using Assignment.Contracts.Data.Repositories;
using Assignment.Core.Data.Repositories;
using Assignment.Migrations;
using Assignment.Migrations.Migrations;

namespace Assignment.Core.Data
{
    public class UnitOfWork : IUnitOfWork
    {
       // private readonly DatabaseContext _context;
        private readonly AspireAssignmentDBContext _aspireAssignmentDBContext;
        //public UnitOfWork(DatabaseContext context, AspireTaskDBContext dbcontext)

        public UnitOfWork(AspireAssignmentDBContext aspireAssignmentDBContext)
        {
            //_context = context;
            _aspireAssignmentDBContext = aspireAssignmentDBContext;
        }
        public IAppRepository App => new AppRepository(_aspireAssignmentDBContext);

        public IUserRepository User => new UserRepository(_aspireAssignmentDBContext);

        public IEmployeeRepository Employee=> new EmployeeRepository(_aspireAssignmentDBContext);

        public IReferencetblRepository referencetbl=> new ReferencetblRepository(_aspireAssignmentDBContext);

        public IEmployerRepository Employer=> new EmployerRepository(_aspireAssignmentDBContext);

        public async Task CommitAsync()
        {
            await _aspireAssignmentDBContext.SaveChangesAsync();
        }
    }
}