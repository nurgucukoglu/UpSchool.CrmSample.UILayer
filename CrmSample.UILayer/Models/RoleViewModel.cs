using System.ComponentModel.DataAnnotations;

namespace CrmSample.UILayer.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage ="lütfen rol adını boş geçmeyin")]
        public string RoleName { get; set; }
    }
}
