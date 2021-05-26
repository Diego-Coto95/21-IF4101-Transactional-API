using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace _21_IF4101_Transactional_API.Models.Entities
{
    public partial class NewsComment
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Date { get; set; }
        public string Comment { get; set; }
        public int IdNews { get; set; }

        public virtual News IdNewsNavigation { get; set; }
    }
}
