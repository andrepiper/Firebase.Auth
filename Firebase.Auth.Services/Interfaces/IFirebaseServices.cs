using Firebase.Auth.Services.Common;
using FirebaseAdmin.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firebase.Auth.Services.Interfaces
{
    public interface IFirebaseServices
    {
        Task<UserRecord> CreateUser(
            string username,
            string password,
            string email,
            string displayName,
            string phoneNumber,
            string? photoLocation);
    }
}
