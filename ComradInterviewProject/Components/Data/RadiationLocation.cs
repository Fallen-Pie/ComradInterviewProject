namespace ComradInterviewProject.Components.Data;

public class RadiationLocation
{
    public string Location { get; init; }
    public HashSet<RadiationDoseRecord> DoseRecords { get; } = new();

    public RadiationLocation(string location)
    {
        Location = location;
    }
}