namespace ConradInterviewProject.Components.Data;

public static class RadiationData
{
    public static HashSet<RadiationLocation> RadiationLocations;

    static RadiationData()
    {
        DataImporter radiationData = new();
        RadiationLocations = radiationData.ImportData("RadiationDose.csv");
    }
}