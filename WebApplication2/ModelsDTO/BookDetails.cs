using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.ModelsDTO
{
    public class BookDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int fileId { get; set; }
        public string price { get; set; }
        public int categoryID { get; set; }
        public int bookID { get; set; }
        public int publisherID { get; set; }

    }
}
