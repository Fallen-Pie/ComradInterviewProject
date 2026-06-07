using System.Globalization;

namespace ConradInterviewProject.Components.Data;

public class DataImporter
{
    public List<RadiationLocation> ImportData(string filePath)
    {
        var locations = new Dictionary<string, RadiationLocation>();

        if (!File.Exists(filePath))
        {
            return new List<RadiationLocation>();
        }

        var lines = File.ReadAllLines(filePath);
        if (lines.Length <= 1) return new List<RadiationLocation>();

        // Expecting columns: Location, Procedure, AED, Comparison
        for (int i = 1; i < lines.Length; i++)
        {
            var line = lines[i];
            if (string.IsNullOrWhiteSpace(line)) continue;

            var parts = line.Split(',');
            if (parts.Length < 4) continue;

            string locationName = parts[0].Trim();
            string procedure = parts[1].Trim();
            string aedStr = parts[2].Trim();
            string comparison = parts[3].Trim();

            if (!float.TryParse(aedStr, NumberStyles.Any, CultureInfo.InvariantCulture, out float aedValue))
            {
                continue;
            }

            if (!locations.TryGetValue(locationName, out var location))
            {
                location = new RadiationLocation(locationName);
                locations.Add(locationName, location);
            }

            try
            {
                var record = new RadiationDoseRecord
                {
                    Procedure = procedure,
                    Comparison = comparison,
                    AedValue = aedValue
                };

                location.DoseRecords.Add(record);
            }
            catch (ArgumentException)
            {
                // Skip records with invalid AED (<= 0)
            }
        }

        return locations.Values.ToList();
    }
}
