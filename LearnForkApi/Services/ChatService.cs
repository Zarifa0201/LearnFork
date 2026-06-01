using LearnForkApi.DTOs;
using LearnForkApi.Mappers;
using LearnForkModule;

namespace LearnForkApi.Services;

public class ChatService : IChatService
{
    private static readonly List<Chat> Chats = new();

    public ChatResponse CreateChat(CreateChatRequest request)
    {
        var chat = new Chat(request.Topic);
        Chats.Add(chat);

        return ChatMapper.ToChatResponse(chat);
    }

    public List<ChatResponse> GetAllChats()
    {
        return Chats
            .Select(ChatMapper.ToChatResponse)
            .ToList();
    }

    public MessageResponse AddMessage(Guid chatId, AddMessageRequest request)
    {
        var chat = FindChat(chatId);
        var message = chat.AddMessage(request.Text, request.Sender);

        return ChatMapper.ToMessageResponse(message);
    }

    public AskAiResponse AskAI(Guid chatId, AskAiRequest request)
    {
        var chat = FindChat(chatId);

        var provider = new AIProvider(request.ProviderName);
        var apiKey = new ApiKey(request.ApiKey, request.ProviderName);

        var result = chat.AskAI(request.Prompt, provider, apiKey);

        return new AskAiResponse(
            ChatMapper.ToMessageResponse(result.userMessage),
            ChatMapper.ToMessageResponse(result.aiMessage)
        );
    }

    public BranchResponse CreateBranch(Guid chatId, CreateBranchRequest request)
    {
        var chat = FindChat(chatId);
        var branch = chat.CreateBranch(request.MessageId, request.Title);

        return ChatMapper.ToBranchResponse(branch);
    }

    public List<MessageResponse> SearchMessages(Guid chatId, string keyword)
    {
        var chat = FindChat(chatId);

        return chat.SearchMessages(keyword)
            .Select(ChatMapper.ToMessageResponse)
            .ToList();
    }

    private static Chat FindChat(Guid chatId)
    {
        var chat = Chats.FirstOrDefault(c => c.ChatId == chatId);

        if (chat == null)
        {
            throw new ArgumentException("Чат не знайдено.");
        }

        return chat;
    }
}