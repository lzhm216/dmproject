using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SPA.DocumentManager.TaskBooks;

namespace SPA.DocumentManager.TaskBooks.Dtos
{
    public class CreateOrUpdateTaskBookInput
{
////BCC/ BEGIN CUSTOM CODE SECTION
////ECC/ END CUSTOM CODE SECTION
        [Required]
        public TaskBookEditDto TaskBook { get; set; }

}
}