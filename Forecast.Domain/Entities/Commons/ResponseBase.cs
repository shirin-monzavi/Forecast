namespace Forecast.Domain.Entities.Commons;

public record ResponseBase<TData>
{
    public TData? Data { get; init; }
    public string Reason { get; init; }
    public bool Error { get; init; }
}
