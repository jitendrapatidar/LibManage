using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using veripark.ConfigurationSettings;
using veripark.Infrastructure;
using veripark.ViewMode.Entities;

namespace LMS.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IRoleService _roleService;
        public IndexModel(ILogger<IndexModel> logger, IRoleService roleService)
        {
            _logger = logger;
            _roleService = roleService;
        }

        public void OnGet()
        {
             //var roles = _roleService.GetAll();
            //RoleEntity roleEntity = new RoleEntity {
            //    Name = "Student",
            //    IsActive = true
            //};
            //_roleService.Save(roleEntity);
            //var role = _roleService.GetById(3);
            //role.Name = "Test";
           // _roleService.Update(3, role);
           // _roleService.Delete(1002);
          // _roleService.Delete(1003);



        }
        public void OnPost() {
        
        }    
    }
}
