using ManageFleet.Infra.Data.Interfaces;

namespace ManageFleet.Application.Services
{
    public abstract class AppService
    {
        private readonly IUnitOfWork _uow;

        protected AppService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        
        public void BeginTransaction()
        {
            _uow.BeginTransaction();
        }
        
        public void Commit()
        {
            _uow.Commit();
        }
    }
}