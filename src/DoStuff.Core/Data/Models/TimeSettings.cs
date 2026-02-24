namespace DoStuff.Core.Data.Models;

public class TimeSettings : ItemBase
{
    public required Guid UserKey { get;set; }

    public int RefreshInterval { get; set; } = 100;

    public List<TimeZoneSetting> TimeZones { get; set; } = [];
}

public class TimeZoneSetting
{
    public required string Id { get; set; }
    public string? Name { get; set; }
}

public class TimeZoneDisplayTime
{
    public required string Id { get; set; }
    public string? Name { get; set; }
    public string? Value { get; set; }
}