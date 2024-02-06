namespace Infra.CrossCutting;

public class APIResponse<T>
{
    public T? Content { get; set; } = default(T);

    public int? Code { get; set; }

    public List<string>? Errors { get; set; } = new();

    protected bool IsValid()
    {
        return !(Errors?.Count > 0);
    }

    public void AddInformation(int cod, string message)
    {
        Code = cod;

        Errors.Add(message);
    }

    public void SetContent(int code, T? content)
    {
        Code = code;

        Content = content;
    }

    public APIResponse<T> Response()
    {
        return this;
    }
}
