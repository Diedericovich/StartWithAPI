namespace StartWithAPI
{
    public class Photo
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public bool IsProfilePicture { get; set; }

        //foreign key
        public int AppUserId { get; set; }

        public AppUser User { get; set; }

    }
}