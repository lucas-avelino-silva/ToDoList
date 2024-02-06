using Application.Core;

namespace Application.ViewModel;

public class InputTaskViewModel : ViewModelView, IInputTaskViewModel
{
    ~InputTaskViewModel() => Dispose();

    public override void Dispose()
    {
        GC.SuppressFinalize(this);
    }


    public string? Title { get; set; }

    public string? Description { get; set; }

    public bool? Completed { get; set; }
}
