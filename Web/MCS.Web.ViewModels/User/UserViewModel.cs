namespace MCS.Web.ViewModels.User
{
    using System.Collections.Generic;

    using MCS.Data.Models;

    public class UserViewModel
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }
    }
}
