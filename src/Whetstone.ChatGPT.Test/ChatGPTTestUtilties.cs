// SPDX-License-Identifier: MIT

namespace Whetstone.ChatGPT.Test
{
    internal static class ChatGPTTestUtilties
    {
        internal static string GetChatGPTKey()
        {
#if NETFRAMEWORK
            string chatGPTKey = System.Environment.GetEnvironmentVariable(EnvironmentSettings.ENV_CHATGPT_KEY);
#else
            string? chatGPTKey = System.Environment.GetEnvironmentVariable(EnvironmentSettings.ENV_CHATGPT_KEY);
#endif
            return chatGPTKey;
        }


        internal static IChatGPTClient GetClient()
        {
            var chatGPTKey = GetChatGPTKey();

            return new ChatGPTClient(chatGPTKey);
        }

    }
}
