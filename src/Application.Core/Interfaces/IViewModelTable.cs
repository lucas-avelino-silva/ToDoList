namespace Application.Core;

public interface IViewModelTable : IViewModelView
{
    Guid? Id { get; set; }
}
