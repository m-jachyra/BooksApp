using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BooksApi.Models
{
    public class User : IdentityUser
    {
        public List<Review> Reviews { get; set; }
        public List<Opinion> ReviewOpinions { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }
    }
}
