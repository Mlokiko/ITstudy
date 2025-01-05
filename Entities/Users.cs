namespace ITstudy.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; } // Jak wymusić żeby było unique?
        public DateTime JoinDate { get; set; } // znowu, current time ustawić
        public string ProfilePictureURL { get; set; }                               // to jako nieliczne nie jest wymagane
        public string Bio {  get; set; }                                            // to jako nieliczne nie jest wymagane
        public int RankID { get; set; }

        public virtual Ranks Ranks { get; set; }
    }
}
