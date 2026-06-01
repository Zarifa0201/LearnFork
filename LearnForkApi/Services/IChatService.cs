

using LearnForkApi.DTOs;

namespace LearnForkApi.Services;

public interface IChatService
{
    ChatResponse CreateChat(CreateChatRequest request);

    List<ChatResponse> GetAllChats();

    MessageResponse AddMessage(Guid chatId, AddMessageRequest request);

    AskAiResponse AskAI(Guid chatId, AskAiRequest request);

    BranchResponse CreateBranch(Guid chatId, CreateBranchRequest request);

    List<MessageResponse> SearchMessages(Guid chatId, string keyword);
}