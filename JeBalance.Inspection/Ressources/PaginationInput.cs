﻿using System.Text.Json.Serialization;

namespace JeBalance.Inspection.Ressources
{
    public abstract class PaginationInput
    {
        [JsonPropertyName("limit")] public int Limit { get; set; }

        [JsonPropertyName("offset")] public int Offset { get; set; }

        public PaginationInput()
        {
        }
    }
}