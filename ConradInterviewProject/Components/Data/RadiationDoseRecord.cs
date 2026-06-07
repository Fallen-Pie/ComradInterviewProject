using System.Runtime.Intrinsics.X86;

namespace ConradInterviewProject.Components.Data;

public record RadiationDoseRecord
{
    public string Procedure { get; }
    public string Comparison { get; }
    private float AedValue
    {
        get;
        init =>
            field = (value > 0)
                ? value
                : throw new ArgumentException("AED must be greater than 0");
    }

    public string AED => AedValue.ToString("F1");

    public override int GetHashCode()
    {
        return Procedure.GetHashCode();
    }
}