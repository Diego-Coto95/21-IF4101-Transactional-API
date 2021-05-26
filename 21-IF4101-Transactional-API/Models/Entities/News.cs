using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace _21_IF4101_Transactional_API.Models.Entities
{
    public partial class News
    {
        public News()
        {
            NewsComment = new HashSet<NewsComment>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string PublicationDate { get; set; }
        public string ModificationDate { get; set; }
        public string FileNews { get; set; }
        public string Imagen { get; set; }

        public virtual ICollection<NewsComment> NewsComment { get; set; }
    }
}
