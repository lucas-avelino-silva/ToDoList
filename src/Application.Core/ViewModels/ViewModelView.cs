namespace Application.Core;

public class ViewModelView : IViewModelView
{
    ~ViewModelView() => Dispose();

    public virtual void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
