using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System.Threading.Tasks;

namespace AirQualityServer.Actions
{
    internal sealed class FirebaseNotifier
    {
        #region Constructors
        /// <summary>
        /// Creates an instance of FiebaseNotifier.
        /// </summary>
        /// <param name="projectId">The Google Cloud Platform project ID that should be associated with.</param>
        public FirebaseNotifier(string projectId)
        {
            Firebase = FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.GetApplicationDefault(),
                ProjectId = projectId
            });
        }
        #endregion

        #region Properties
        public FirebaseApp Firebase { get; private set; }
        #endregion

        #region Public methods
        //var registrationToken = "ePI9Ft9mK1g:APA91bEa596H83ycG0YJ_7l_sSoKFnAbfAXq38fifq8IhG6tV5DDGLkCiGZoQBeOp_gMdz98RGXwH7QiENI1c6PeABVUiexHvmJhmXj5stRUSEZerHt5LJTt7oRamzFORDn7YThfEr0R";

        /// <summary>
        /// Asynchronously sends a notification to an user via <b>token</b> through Firebase service.
        /// </summary>
        /// <param name="title">The <b>title</b> of the notification.</param>
        /// <param name="body">The <b>body</b> of the notification.</param>
        /// <param name="token">The <b>token</b> used to identify the target user.</param>
        /// <returns>Returns a string response if the message has been successfully sent.</returns>
        public async Task<string> SendNotificationAsync(string title, string body, string token)
        {
            var message = new Message()
            {
                Notification = new Notification()
                {
                    Title = title,
                    Body = body
                },
                Token = token,
            };
            return await FirebaseMessaging.DefaultInstance.SendAsync(message);
        }
        #endregion
    }
}