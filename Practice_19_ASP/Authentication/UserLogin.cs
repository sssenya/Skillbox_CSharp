using System.ComponentModel.DataAnnotations;

namespace Practice_19_ASP.Authentication {
    public class UserLogin {
        [Required, MaxLength(20)]
        public string UserName { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
