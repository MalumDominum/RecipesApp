using DataAccessLayer;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Infrastructure;

public class UoWFactory : IUoWFactory
{
    public IUnitOfWork CreateUoW() => new UnitOfWork();
}