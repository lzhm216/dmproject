using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SPA.DocumentManager.TaskBooks;

namespace SPA.DocumentManager.TaskBooks.Dtos
{
    public class CreateOrUpdateTaskBookInput
    {
        [Required]
        public TaskBookEditDto TaskBook { get; set; }


		
		//// custom codes 
		
        //// custom codes end
    }
}