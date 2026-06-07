namespace ConradInterviewProject.Components.Data;

public class RadiationLocation
{
    string Location { get; }
    HashSet<RadiationDoseRecord> DoseRecords { get; }
}