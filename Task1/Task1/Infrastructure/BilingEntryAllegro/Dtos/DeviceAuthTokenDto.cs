﻿using System.Text.Json.Serialization;

namespace Task1.Infrastructure.BilingEntryAllegro;

public class DeviceAuthTokenDto
{
    [JsonPropertyName("access_token")]
    public string? AccessToken { get; set; }

    [JsonPropertyName("token_type")]
    public string? TokenType { get; set; }

    [JsonPropertyName("refresh_token")]
    public string? RefreshToken { get; set; }

    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }

    [JsonPropertyName("scope")]
    public string? Scope { get; set; }

    [JsonPropertyName("allegro_api")]
    public bool AllegroApi { get; set; }

    [JsonPropertyName("jti")]
    public string? Jti { get; set; }

    [JsonPropertyName("error")]
    public string? Error { get; set; }
}

