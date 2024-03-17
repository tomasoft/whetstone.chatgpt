// SPDX-License-Identifier: MIT
using System.Net.NetworkInformation;
using System.Net;
using System;
using Blazorise;
using Whetstone.ChatGPT.Models;
using Microsoft.AspNetCore.Components;
using Whetstone.ChatGPT.Blazor.App.Models;

namespace Whetstone.ChatGPT.Blazor.App.Components
{
    public partial class ChatOptionsSelector
    {

        [Parameter]
        public float Temperature { get; set; } = 0.7f;

        public string? SelectedModel { get; set; }

        [Parameter]
        public EventCallback<Exception> OnException { get; set; }

        [Parameter]
        public EventCallback<CompletionOptions> OnCompletionOptionsChanged { get; set; }

        [Parameter]
        public int MaxTokens { get; set; } = 4000;

        [CascadingParameter]
        public int? DefaultMaxTokens { get; set; } = 2000;

        private IEnumerable<ChatGPTModel>? models = default!;


        protected override async Task OnInitializedAsync()
        {
            try
            {
                ChatClient.Credentials = new ChatGPTCredentials();
                
                ChatGPTListResponse<ChatGPTModel>? listResponse = await ChatClient.ListModelsAsync();

                if(listResponse?.Data is not null)
                {
                    foreach (var item in listResponse.Data.Where(item => item.Id != null && item.Id.Contains('\\')))
                        item.Id = item.Id?.Split('\\').LastOrDefault();

                    models = listResponse.Data.OrderBy(x => x.Id);
                }

                SelectedModel = LmStudioModels.CustomModel;

                if (DefaultMaxTokens is not null)
                {
                    MaxTokens = DefaultMaxTokens.Value;
                }
            }
            catch (Exception ex)
            {
                await OnException.InvokeAsync(ex);
            }

            await base.OnInitializedAsync();
        }

    }
}
