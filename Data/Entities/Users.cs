using System.ComponentModel.DataAnnotations;

namespace ITstudy.Data.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public required string UserName { get; set; }  // takie required będzie działać?
        public string PasswordHash { get; set; }
        public string Email { get; set; } // Jak wymusić żeby było unique?
        public DateTime JoinDate { get; set; } // znowu, current time ustawić
        public string ProfilePictureURL { get; set; }                               // to jako nieliczne nie jest wymagane
        public string Bio { get; set; }                                            // to jako nieliczne nie jest wymagane
        public int RankId { get; set; }

        public virtual Ranks Rank { get; set; }
    }
}
