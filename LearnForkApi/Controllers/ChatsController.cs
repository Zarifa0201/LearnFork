using LearnForkApi.DTOs;
using LearnForkApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearnForkApi.Controllers;

[ApiController]
[Route("api/chats")]
public class ChatsController : ControllerBase
{
    private readonly IChatService _chatService;

    public ChatsController(IChatService chatService)
    {
        _chatService = chatService;
    }

    [HttpPost]
    public ActionResult<ChatResponse> CreateChat([FromBody] CreateChatRequest request)
    {
        try
        {
            return Ok(_chatService.CreateChat(request));
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public ActionResult<List<ChatResponse>> GetAllChats()
    {
        return Ok(_chatService.GetAllChats());
    }

    [HttpPost("{chatId:guid}/messages")]
    public ActionResult<MessageResponse> AddMessage(
        Guid chatId,
        [FromBody] AddMessageRequest request)
    {
        try
        {
            return Ok(_chatService.AddMessage(chatId, request));
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("{chatId:guid}/ask-ai")]
    public ActionResult<AskAiResponse> AskAI(
        Guid chatId,
        [FromBody] AskAiRequest request)
    {
        try
        {
            return Ok(_chatService.AskAI(chatId, request));
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("{chatId:guid}/branches")]
    public ActionResult<BranchResponse> CreateBranch(
        Guid chatId,
        [FromBody] CreateBranchRequest request)
    {
        try
        {
            return Ok(_chatService.CreateBranch(chatId, request));
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{chatId:guid}/search")]
    public ActionResult<List<MessageResponse>> SearchMessages(
        Guid chatId,
        [FromQuery] string keyword)
    {
        try
        {
            return Ok(_chatService.SearchMessages(chatId, keyword));
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}