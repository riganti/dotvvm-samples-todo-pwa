using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading.Tasks;
using TodoPwa.BL.Models;
using TodoPwa.BL.Options;

namespace TodoPwa.BL.Services
{
    public class PushNotificationService : IPushNotificationService
    {
        private readonly IOptions<PushNotificationOptions> pushNotificationOptions;
        private readonly IRestClient restClient;

        public PushNotificationService(
            IOptions<PushNotificationOptions> pushNotificationOptions,
            IRestClient restClient)
        {
            this.pushNotificationOptions = pushNotificationOptions;
            this.restClient = restClient;
        }

        public async Task SendNotificationAsync(TodoItemNotificationModel todoItemNotificationModel)
        {
            restClient.BaseUrl = new Uri(pushNotificationOptions.Value.FirebaseUrlBase);

            var pushNotificationModel = new PushNotificationModel();
            var pushNotificationString = JsonConvert.SerializeObject(pushNotificationModel);

            var request = new RestRequest(pushNotificationOptions.Value.FirebasePushNotificationSendEndpoint, Method.POST);
            request.RequestFormat = DataFormat.Json;

            request.AddHeader("Authorization", $"key={pushNotificationOptions.Value.FirebaseServerKey}");
            request.AddParameter("application/json", pushNotificationString, ParameterType.RequestBody);

            var response = await restClient.ExecutePostAsync(request);
        }
    }
}