using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Infrastructure;

public interface IUoWFactory
{
    IUnitOfWork CreateUoW();
}