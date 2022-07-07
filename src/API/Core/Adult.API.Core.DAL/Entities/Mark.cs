﻿namespace Adult.API.Core.DAL.Entities
{
    public class Mark
    {
        public long Id { get; set; }
        public DateTime Time { get; set; }
        public bool Liked { get; set; }
        public string SourceUserId { get; set; }
        public string SubjectUserId { get; set; }
    }
}
