using System;

namespace MacawSitecoreProject.Models
{
    public class FullMoveDetailModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Director Director { get; set; }
        public int Like { get; set; }
    }
}