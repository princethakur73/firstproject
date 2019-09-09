namespace WebApplication.Core
{
    public partial class UserPictureMapping
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public string PictureId { get; set; }

        public int DisplayOrder { get; set; }
    }
}
