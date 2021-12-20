using DataAccessLayer;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Infrastructure
{
    public class UoWFactory : IUoWFactory
    {
        public IUnitOfWork CreateUoW()
        {
            return new UnitOfWork();
        }
    }
}
