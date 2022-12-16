//using System.Linq;
//using System.Threading.Tasks;

//using Ganss.Xss;
//using MCS.Data.Models;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.SignalR;

//public class ChatHub : Hub
//{
//    private readonly UserManager<ApplicationUser> userManager;

//    public ChatHub(UserManager<ApplicationUser> userManager)
//    {
//        this.userManager = userManager;
//    }

//    public async Task Send(SendMessageInputModel inputModel)
//    {
//        var sanitizer = new HtmlSanitizer();
//        var message = sanitizer.Sanitize(inputModel.Message);

//        if (string.IsNullOrEmpty(message) ||
//            string.IsNullOrWhiteSpace(message) ||
//            string.IsNullOrEmpty(message))
//        {
//            return;
//        }

//        var caller = this.userManager
//            .Users
//            .First(x => x.Id == inputModel.CallerId)
//            .ProfilePictureUrl;

//        await this.Clients
//            .User(inputModel.UserId)
//            .SendAsync("RecieveMessage", message, caller);

//        await this.Clients
//            .Caller
//            .SendAsync("SendMessage", message);
//    }
//}
