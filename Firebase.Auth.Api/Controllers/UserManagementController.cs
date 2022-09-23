using Firebase.Auth.Common;
using Firebase.Auth.Common.Models;
using Firebase.Auth.Middleware.Implementation;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Firebase.Auth.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserManagementController : ControllerBase
    {
        private readonly IFirebaseMiddleware _firebaseMiddleware;
        private readonly ILogger<UserManagementController> _logger;

        public UserManagementController(ILogger<UserManagementController> logger,
            IFirebaseMiddleware firebaseMiddleware)
        {
            _firebaseMiddleware = firebaseMiddleware;
            _logger = logger;
        }

        [HttpPost(Name = "CreateUser")]
        public async Task<BackendResponse<UserRecord>> CreateUser(UserModel user)
        {
            return await _firebaseMiddleware.CreateUser(
               user.Username,
               user.Password,
               user.Email,
               user.DisplayName,
               user.PhoneNumber,
               user.PhotoLocation);
        }
    }
}