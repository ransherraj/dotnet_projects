﻿namespace NewsWebAPI.Models
{
    public class EditUser
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public DateTime UserModifiedDate { get; set; }
        public string? UserModifiedBy { get; set; }
        public int UserIsactive { get; set; }
    }
}
