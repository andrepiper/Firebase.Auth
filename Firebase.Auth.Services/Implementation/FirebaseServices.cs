using Firebase.Auth.Services.Common;
using Firebase.Auth.Services.Interfaces;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firebase.Auth.Services.Implementation
{
    public class FirebaseServices : IFirebaseServices
    {
        private readonly FirebaseApp _firebaseApp;
        public FirebaseServices(string authJsonFile) 
        {
            var appOptions = new AppOptions()
            {
                Credential = GoogleCredential.FromFile(authJsonFile),
            };
            _firebaseApp = FirebaseApp.Create(appOptions);
        }

        public async Task<UserRecord> CreateUser(string username, 
            string password, 
            string email, 
            string displayname,
            string phoneNumber,
            string? photoLocation)
        {
            var defaultAuth = FirebaseAuth.GetAuth(_firebaseApp);

            var args = new UserRecordArgs()
            {
                Email = email,
                EmailVerified = false,
                PhoneNumber = phoneNumber,
                Password = password,
                DisplayName = displayname,
                PhotoUrl = photoLocation,
                Disabled = false,
            };

            return await defaultAuth.CreateUserAsync(args);

        }
    }
}
