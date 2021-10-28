using System;

namespace MacawSitecoreProject.Models
{
    public class MoveLikeReadModel
    {
        public Guid MovieId { get; set; }
        public decimal Like { get; set; }
    }
}