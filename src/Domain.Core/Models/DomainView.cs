namespace Domain.Core.Models;

public class DomainView : IDomainView
{
    ~DomainView() => Dispose();

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
