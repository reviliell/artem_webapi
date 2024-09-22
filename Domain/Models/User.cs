using System.Text.Json.Serialization;
using Domain.Enums;

namespace Domain.Models;

public class User
{
    public required int Id { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))] public required UserGender Gender { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public string? Post { get; set; }
    public int? SchoolId { get; set; }
}