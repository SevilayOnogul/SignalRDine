using Microsoft.AspNetCore.SignalR;
using SignalRDine.DataAccessLayer.Concrete;

namespace SignalRDine.Api.Hubs
{
    public class SignalRHub : Hub
    {
        SignalRDineContext context = new SignalRDineContext();

        public async Task SendCategoryCount()
        {
            var value=context.Categories.Count();
            await Clients.All.SendAsync("ReceiveCategoryCount",value);
        }

    }
}
