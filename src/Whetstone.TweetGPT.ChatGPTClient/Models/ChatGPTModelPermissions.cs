﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Whetstone.TweetGPT.ChatGPTClient.Models
{
    public class ChatGPTModelPermissions
    {

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("object")]
        public string? @Object { get; set; }


        [JsonPropertyName("created")]
        public int Created { get; set; }


        [JsonPropertyName("allow_create_engine")]
        public bool AllowCreateEngine { get; set; }

        [JsonPropertyName("allow_sampling")]
        public bool AllowSampling { get; set; }

        [JsonPropertyName("allow_logprobs")]
        public bool AllowLogprobs { get; set; }

        [JsonPropertyName("allow_search_indices")]
        public bool AllowSearchndices { get; set; }

        [JsonPropertyName("allow_view")]
        public bool AllowView { get; set; }

        [JsonPropertyName("allow_fine_tuning")]
        public bool AllowFineTuning { get; set; }

        [JsonPropertyName("organization")]
        public string? Organization { get; set; }

        [JsonPropertyName("group")]
        public object? Group { get; set; }

        [JsonPropertyName("is_blocking")]
        public bool IsBlocking { get; set; }

    }
}
