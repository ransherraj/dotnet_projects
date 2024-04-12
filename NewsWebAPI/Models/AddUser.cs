namespace NewsAPP.Models
{
    public class AddUser
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public DateTime UserCreatedDate { get; set; }
        public string? UserCreatedBy { get; set; }
        public DateTime UserModifiedDate { get; set; }
        public string? UserModifiedBy { get; set; }
        public int UserIsactive { get; set; }
    }

}
