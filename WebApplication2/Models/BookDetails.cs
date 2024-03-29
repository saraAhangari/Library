﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class BookDetails
    {
        [Key]
        public int fileId { get; set; }
        public string price { get; set; }
        public int categoryID { get; set; }
        public int bookID { get; set; }
        public int publisherID { get; set; } //one to many

    }
}
