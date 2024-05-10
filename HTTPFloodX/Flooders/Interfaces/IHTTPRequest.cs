namespace HTTPFloodX.Flooders.Interfaces;

public interface IHTTPRequest
{
    Task<bool> SendRequestAsync();
}