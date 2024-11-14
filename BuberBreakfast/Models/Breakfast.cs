using ErrorOr;
using BuberBreakfast.ServiceError;

namespace BuberBreakfast.Models;

public class Breakfast
{
    public const int MinNameLength = 3;
    public const int MaxNameLength = 30;
    public const int MinDescriptionLength = 5;
    public const int MaxDescriptionLength = 50;
    public Guid Id { get; set; } 
    public string Name { get; set; } 
    public string Description { get; set; }
    public DateTime StartDateTime { get; set; } 
    public DateTime EndDateTime { get; set; } 
    public DateTime LastModifiedDateTime { get; set; } 
    public ICollection<string> Savory { get; set; } = new List<string>(); 
    public ICollection<string> Sweet { get; set; } = new List<string>(); 

    public Breakfast() { 
        Name = string.Empty;
        Description = string.Empty;
        StartDateTime = DateTime.UtcNow;
        EndDateTime = DateTime.UtcNow.AddHours(1);
        LastModifiedDateTime = DateTime.UtcNow;
        Savory = new List<string>();
        Sweet = new List<string>();
    }

    public Breakfast(Guid id, string name, string description, DateTime startDateTime, DateTime endDateTime, DateTime lastModifiedDateTime, List<string> savory, List<string> sweet)
    {
        Id = id;
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        LastModifiedDateTime = lastModifiedDateTime;
        Savory = savory;
        Sweet = sweet;
    }

    public static ErrorOr<Breakfast> Create(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        List<string> savory,
        List<string> sweet,
        Guid? id = null)
    {
        List<Error> errors = new();

        if (name.Length < MinNameLength || name.Length > MaxNameLength)
        {
            errors.Add(Errors.Breakfast.InvalidName);
        }

        if (description.Length < MinDescriptionLength || description.Length > MaxDescriptionLength)
        {
            errors.Add(Errors.Breakfast.InvalidDescription);
        }

        if (errors.Count > 0)
        {
            return errors;
        }

        return new Breakfast(
            id ?? Guid.NewGuid(),
            name,
            description,
            startDateTime,
            endDateTime,
            DateTime.UtcNow,
            savory,
            sweet
        );
    }
}
