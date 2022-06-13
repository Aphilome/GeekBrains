using Timesheets.Models.Identity;

namespace Timesheets.Services.Abstracts
{
    public interface IIdentityService
    {
        TokenResponse? Authenticate(string user, string password);

        string RefreshToken(string? token);
    }
}
