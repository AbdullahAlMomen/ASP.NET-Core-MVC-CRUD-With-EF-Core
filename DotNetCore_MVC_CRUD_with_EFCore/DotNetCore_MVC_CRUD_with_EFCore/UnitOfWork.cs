using DotNetCore_MVC_CRUD_with_EFCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Text;

namespace DotNetCore_MVC_CRUD_with_EFCore
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
       
        private bool _disposed;
        private string _errorMessage = string.Empty;
       private MVCDemoDbContext _context;


        public UnitOfWork(MVCDemoDbContext context)
        {
            //Context = new TContext();
            _context= context;
            EmployeeRepository = new EmployeeRepository(context);
        }
     

        public IEmployeeRepository EmployeeRepository { get; private set; }

        //public void Commit()
        //{
        //    //Commits the underlying store transaction
        //    _objTran.Commit();
        //}

        //public void CreateTransaction()
        //{
        //    //It will Begin the transaction on the underlying store connection
        //     Context.Database.BeginTransaction();
        //}

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //public void Rollback()
        //{
        //    _objTran.Rollback();
        //}

        public void Save()
        {
            try
            {
                //Calling DbContext Class SaveChanges method 
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                //_objTran?.Dispose();
                _context.Dispose();
            }
        }
    }
}
