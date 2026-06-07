using ComradInterviewProject.Components.Data;
using Xunit;

namespace ComradInterviewProject.Tests;

public class DataImporterTests : IDisposable
{
    private readonly string _testCsvPath = "test_data.csv";
    private readonly DataImporter _importer = new();

    public void Dispose()
    {
        if (File.Exists(_testCsvPath))
        {
            File.Delete(_testCsvPath);
        }
    }

    [Fact]
    public void ImportData_FileNotFound_ThrowsFileNotFoundException()
    {
        // Arrange
        var nonExistentPath = "non_existent.csv";

        // Act & Assert
        Assert.Throws<FileNotFoundException>(() => _importer.ImportData(nonExistentPath));
    }

    [Fact]
    public void ImportData_EmptyFile_ReturnsEmptyHashSet()
    {
        // Arrange
        File.WriteAllText(_testCsvPath, "");

        // Act
        var result = _importer.ImportData(_testCsvPath);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void ImportData_OnlyHeader_ReturnsEmptyHashSet()
    {
        // Arrange
        File.WriteAllText(_testCsvPath, "Location,Procedure,AED,Comparison");

        // Act
        var result = _importer.ImportData(_testCsvPath);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void ImportData_ValidCsv_ImportsCorrectData()
    {
        // Arrange
        var csvContent = @"Location,Procedure,AED,Comparison
Location A,Procedure 1,1.5,Comparison 1
Location B,Procedure 2,2.0,Comparison 2";
        File.WriteAllText(_testCsvPath, csvContent);

        // Act
        var result = _importer.ImportData(_testCsvPath);

        // Assert
        Assert.Equal(2, result.Count);
        
        var locA = result.Single(l => l.Location == "Location A");
        Assert.Single(locA.DoseRecords);
        var recordA = locA.DoseRecords.First();
        Assert.Equal("Procedure 1", recordA.Procedure);
        Assert.Equal(1.5f, recordA.AedValue);
        Assert.Equal("Comparison 1", recordA.Comparison);

        var locB = result.Single(l => l.Location == "Location B");
        Assert.Single(locB.DoseRecords);
    }

    [Fact]
    public void ImportData_DuplicateLocations_MergesRecords()
    {
        // Arrange
        var csvContent = @"Location,Procedure,AED,Comparison
Location A,Procedure 1,1.5,Comparison 1
Location A,Procedure 2,2.5,Comparison 2";
        File.WriteAllText(_testCsvPath, csvContent);

        // Act
        var result = _importer.ImportData(_testCsvPath);

        // Assert
        Assert.Single(result);
        var locA = result.Single();
        Assert.Equal("Location A", locA.Location);
        Assert.Equal(2, locA.DoseRecords.Count);
    }

    [Fact]
    public void ImportData_DuplicateRecords_IgnoresDuplicates()
    {
        // Arrange
        var csvContent = @"Location,Procedure,AED,Comparison
Location A,Procedure 1,1.5,Comparison 1
Location A,Procedure 1,1.5,Comparison 1";
        File.WriteAllText(_testCsvPath, csvContent);

        // Act
        var result = _importer.ImportData(_testCsvPath);

        // Assert
        Assert.Single(result);
        var locA = result.Single();
        Assert.Single(locA.DoseRecords);
    }

    [Fact]
    public void ImportData_InvalidAedValue_SkipsRecord()
    {
        // Arrange
        var csvContent = @"Location,Procedure,AED,Comparison
Location A,Procedure 1,0.0,Comparison 1
Location A,Procedure 2,-1.0,Comparison 2
Location A,Procedure 3,1.5,Comparison 3
Location A,Procedure 4,not_a_number,Comparison 4";
        File.WriteAllText(_testCsvPath, csvContent);

        // Act
        var result = _importer.ImportData(_testCsvPath);

        // Assert
        Assert.Single(result);
        var locA = result.Single();
        Assert.Single(locA.DoseRecords);
        Assert.Equal("Procedure 3", locA.DoseRecords.First().Procedure);
    }

    [Fact]
    public void ImportData_MalformedLine_SkipsLine()
    {
        // Arrange
        var csvContent = @"Location,Procedure,AED,Comparison
Location A,Procedure 1,1.5,Comparison 1
Location B,Procedure 2
Location C,Procedure 3,2.5,Comparison 3,Extra Column";
        File.WriteAllText(_testCsvPath, csvContent);

        // Act
        var result = _importer.ImportData(_testCsvPath);

        // Assert
        // Location B line has only 2 parts, should be skipped.
        // Location C line has 5 parts, should be imported (it splits and takes first 4).
        Assert.Equal(2, result.Count);
        Assert.Contains(result, l => l.Location == "Location A");
        Assert.Contains(result, l => l.Location == "Location C");
        Assert.DoesNotContain(result, l => l.Location == "Location B");
    }
}
