using LearnForkApi.DTOs;
using LearnForkModule;

namespace LearnForkApi.Mappers;

public static class ChatMapper
{
    public static ChatResponse ToChatResponse(Chat chat)
    {
        return new ChatResponse(
            chat.ChatId,
            chat.Topic,
            chat.CreatedAt,
            chat.UpdatedAt
        );
    }

    public static MessageResponse ToMessageResponse(Message message)
    {
        return new MessageResponse(
            message.MessageId,
            message.Text,
            message.Sender,
            message.CreatedAt,
            message.GetShortPreview()
        );
    }

    public static BranchResponse ToBranchResponse(Branch branch)
    {
        return new BranchResponse(
            branch.BranchId,
            branch.Title,
            branch.ParentMessage.MessageId,
            branch.CreatedAt
        );
    }
}