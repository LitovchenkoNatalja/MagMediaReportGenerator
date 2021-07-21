//created as an example
namespace MagMediaReportGenerator.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<T> RepositoryOf<T>() where T : class;
    }
}
