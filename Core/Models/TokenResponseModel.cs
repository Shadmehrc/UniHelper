namespace Domain.Models;

public class TokenResponseModel
{
    public string Token { get; set; }
    public DateTime ValidUntil { get; set; }
}