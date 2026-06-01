namespace LearnForkApi.DTOs;

public record CreateChatRequest(string Topic);

public record AddMessageRequest(string Text, string Sender);

public record AskAiRequest(
    string Prompt,
    string ProviderName,
    string ApiKey
);

public record CreateBranchRequest(
    Guid MessageId,
    string Title
);