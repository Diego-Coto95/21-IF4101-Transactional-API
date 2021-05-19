using System;
using System.Collections.Generic;

#nullable disable

namespace _21_IF4101_Transactional_API.Models
{
    public partial class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime PublicationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public string FileNew { get; set; }
        public string Imagen { get; set; }
    }
}
