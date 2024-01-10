using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SW.MB.Processing.Interfaces
{
    public interface IUserService
    {
        public bool Authenticate(NetworkCredential credential);
    }
}
