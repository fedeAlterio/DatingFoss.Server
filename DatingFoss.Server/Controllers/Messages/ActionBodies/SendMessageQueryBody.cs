namespace DatingFoss.Server.Controllers.Messages.ActionBodies;

public record SendMessageQueryBody(string Content, string ToUsername);
