// JSON placeholder response model

using System.Text.Json.Serialization;

public class TodoModel
{
    public int UserId { get; set; }
    public int Id { get; set; }
    public string? Title { get; set; }

    [JsonPropertyName("completed")]
    public bool Completed { get; set; }
}