namespace SendNotification.Api.Rrepository
{
    public interface INotificationRepo
    {
        Task<string> SendNotification(string Message);
    }
}
