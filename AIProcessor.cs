using OpenAI.Chat;

namespace AI_Test
{
    public class AIProcessor
    {
        private ChatClient client;

        // set valid api key
        private string api_key = "";

        public AIProcessor()
        {
            client = new OpenAI.Chat.ChatClient(model: "gpt-4o", apiKey: api_key);
        }

        public string GenerateTitle(ApplicationRequest request)
        {
            var messages = new List<ChatMessage>();
            messages.Add(ChatMessage.CreateSystemMessage("Tu esi palīgs, kurš ģenerē saprotamus, īsus pieteikumu nosaukumus."));
            messages.Add(ChatMessage.CreateUserMessage($"Izveido īsu nosaukumu šādam pieteikumam:\n\n{request.Description}"));
            return client.CompleteChat(messages).Value.Content[0].Text;
        }

        public string DetermineType(ApplicationRequest request)
        {
            var messages = new List<ChatMessage>();
            messages.Add(ChatMessage.CreateSystemMessage("Tu esi AI, kas nosaka pieteikuma tipu. Atbildi ar vienu vārdu: 'Kļūda', 'Pilnveidojums', 'Konsultācija' vai 'Neattiecas'."));
            messages.Add(ChatMessage.CreateUserMessage($"Apraksts: {request.Description}\nSagaidāmais rezultāts: {request.ExpectedResult}"));
            return client.CompleteChat(messages).Value.Content[0].Text;
        }
    }
}
