namespace Domain.Core;

public interface IRepositoryView<IDomainViewObject> where IDomainViewObject : class, IDomainView, IDisposable
{
    Task<List<IDomainViewObject>> GetAll();

}
