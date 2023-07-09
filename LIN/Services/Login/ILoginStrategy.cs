namespace LIN.Services.Login;


public interface ILoginStrategy
{
    
    Task<(string message, bool can)> Login(string username, string? password);

    void Dispose();

}