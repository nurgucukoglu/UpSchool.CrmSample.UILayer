using System.ComponentModel.DataAnnotations;

namespace CrmSample.UILayer.Models
{
    public class ForgotPasswordModel
    {
        [EmailAddress]
        public string Email { get; set; }
    }
}
