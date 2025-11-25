using System.Text.Json.Serialization;

namespace CleanArchitectureUsersApp.Domain.Enumumerations.Validation
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ValidationSeverity
    {
        Information,
        Warning,
        Error
    }
}
