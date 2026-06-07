namespace ConradInterviewProject.Components.Data;

public record RadiationDoseRecord
{
    public required string Procedure { get; init; }
    public required string Comparison { get; init; }
    public required float AedValue
    {
        get;
        init =>
            field = (value > 0)
                ? value
                : throw new ArgumentException("AED must be greater than 0");
    }

    public string AED => (AedValue <= 0.001f) ? ">" + AedValue : AedValue.ToString();
}
