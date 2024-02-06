using Application.Core;

namespace Application.ViewModel;

public interface IInputTaskViewModel : IViewModelView
{
    string? Title { get; set; }

    string? Description { get; set; }

    bool? Completed { get; set; }
}
