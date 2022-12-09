namespace MCS.Web.ViewModels.Department
{
    using System.Collections.Generic;

    public class DepartmentListViewModel
    {
        public DepartmentListViewModel()
        {
            this.Departments = new HashSet<DepartmentViewModel>();
        }

        public IEnumerable<DepartmentViewModel> Departments { get; set; }
    }
}
