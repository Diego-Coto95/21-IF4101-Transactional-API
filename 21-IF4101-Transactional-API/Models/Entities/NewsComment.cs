using System;
using System.Collections.Generic;

#nullable disable

namespace _21_IF4101_Transactional_API.Models.Entities
{
    public partial class NewsComment
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public int IdNews { get; set; }

        public virtual News IdNewsNavigation { get; set; }
    }
}
