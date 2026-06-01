namespace LearnForkApi.DTOs;

public record ChatResponse(
    Guid ChatId,
    string Topic,
    DateTime CreatedAt,
    DateTime UpdatedAt
);

public record MessageResponse(
    Guid MessageId,
    string Text,
    string Sender,
    DateTime CreatedAt,
    string ShortPreview
);

public record AskAiResponse(
    MessageResponse UserMessage,
    MessageResponse AiMessage
);

public record BranchResponse(
    Guid BranchId,
    string Title,
    Guid ParentMessageId,
    DateTime CreatedAt
);
