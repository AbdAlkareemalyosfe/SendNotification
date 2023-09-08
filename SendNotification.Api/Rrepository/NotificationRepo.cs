
using FirebaseAdmin.Messaging;
using Newtonsoft.Json;
using System.Text;
using SendNotification.Api.Sitting;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Extensions.Options;

namespace SendNotification.Api.Rrepository
{
    public class NotificationRepo : INotificationRepo
    {
        private readonly SittingNotification _sitting ;
        public NotificationRepo( IOptions<SittingNotification> sitting)
        {
            _sitting = sitting.Value;
        }

            public async Task<string> SendNotification(string Message)
            {

                var serverKey = _sitting.Serverkey;
                 var senderId = _sitting.SenderID;
                var data = new
                {
                    to = "/topics/all",
                    notification = new
                    {
                        title = "إشعار جديد",
                        body = Message,
                    }
                };
                var jsonBody = JsonConvert.SerializeObject(data);
                using (var httpRequest = new HttpRequestMessage(HttpMethod.Post, "https://fcm.googleapis.com/fcm/send"))
                {
                    httpRequest.Headers.TryAddWithoutValidation("Authorization", $"key={serverKey}");
                    httpRequest.Headers.TryAddWithoutValidation("Sender", $"id={senderId}");
                    httpRequest.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                    using (var httpClient = new HttpClient())
                    {
                        var result = httpClient.Send(httpRequest);
                        if (result.IsSuccessStatusCode)
                        {
                            return "Success";
                        }

                    }
                }
                return "Faild";
            }
        }
       
    }

