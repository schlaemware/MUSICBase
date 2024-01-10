using System.Net;
using SW.MB.Processing.Interfaces;
using SW.MB.Processing.Services.Abstracts;

namespace SW.MB.Processing.Services
{
    internal class UserService : BaseService, IUserService
    {
        public bool Authenticate(NetworkCredential credential)
        {
            throw new NotImplementedException();
        }
    }
}
