using System.ComponentModel.DataAnnotations;

namespace BooksApi.Models
{
    public class UserListDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }

    public class UserDetails
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }

    public class UserReviewDto
    {
        public string Username { get; set; }
    }
}
