namespace MCS.Web.ViewModels.User
{
    using System.Collections.Generic;

    public class UserListViewModel
    {
        public UserListViewModel()
        {
            this.Users = new HashSet<UserViewModel>();
        }

        public IEnumerable<UserViewModel> Users { get; set; }
    }
}
