namespace Infra.CrossCutting;

public class ResponseService<ViewModelObject>
{
    public ViewModelObject? Content { get; set; }

    public List<string>? Errors { get; set; } = new();

    public bool IsValid()
    {
        return !(Errors?.Count > 0);
    }

    public void AddInformation(string message)
    {
        Errors.Add(message);
    }
}
