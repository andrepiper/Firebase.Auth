using Firebase.Auth.Common;
using Firebase.Auth.Middleware.Implementation;
using Firebase.Auth.Services.Interfaces;
using FirebaseAdmin.Auth;
using Newtonsoft.Json.Linq;

namespace Firebase.Auth.Middleware
{
    public class FirebaseMiddleware : IFirebaseMiddleware
    {
        private readonly IFirebaseServices _firebaseServices;
        public FirebaseMiddleware(IFirebaseServices firebaseServices)
        {
            _firebaseServices = firebaseServices;
        }

        public async Task<BackendResponse<UserRecord>> CreateUser(string username, string password, string email, string displayName, string phoneNumber, string? photoLocation)
        {
            BackendResponse<UserRecord> backendResponse = new BackendResponse<UserRecord>();
            UserRecord userRecord;
            try
            {
                userRecord = await _firebaseServices.CreateUser(username, 
                                                                password, 
                                                                email, 
                                                                displayName, 
                                                                phoneNumber, 
                                                                photoLocation
                                                                );

                backendResponse.Payload = userRecord;
                backendResponse.Success = true;
            }
            catch (FirebaseAuthException ex)
            {
                backendResponse.Success = false;
                backendResponse.ErrorMessage = ex.Message; 
            }
            catch (Exception ex)
            {
                backendResponse.Success = false;
                backendResponse.ErrorMessage = ex.Message;
            }
            return backendResponse;
        }

        public async Task<BackendResponse<UserRecord>> RetrieveUser(string email)
        {
            BackendResponse<UserRecord> backendResponse = new BackendResponse<UserRecord>();
            UserRecord userRecord;
            try
            {
                userRecord = await _firebaseServices.RetrieveUser(email);

                backendResponse.Payload = userRecord;
                backendResponse.Success = true;
            }
            catch (FirebaseAuthException ex)
            {
                backendResponse.Success = false;
                backendResponse.ErrorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                backendResponse.Success = false;
                backendResponse.ErrorMessage = ex.Message;
            }
            return backendResponse;
        }
    }
}