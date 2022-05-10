using IdentityModel.Client;

namespace Timesheets.Services.Abstracts
{
    public interface IIdentityService
    {
        string Authenticate(string user, string password);
    }
}
