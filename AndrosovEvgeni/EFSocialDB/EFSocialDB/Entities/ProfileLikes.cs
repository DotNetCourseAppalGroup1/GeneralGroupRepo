namespace EFSocialDB.Entities
{
    public class ProfileLikes : EntityModel
    {
        public int TargetId { get; set; }
        public int UserId { get; set; }

        public virtual Users Users { get; set; }
    }
}
