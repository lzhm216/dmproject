using System.Collections.Generic;
using Abp.Application.Services.Dto;
using SPA.DocumentManager.TaskBooks;

namespace SPA.DocumentManager.TaskBooks.Dtos
{
    public class GetTaskBookForEditOutput
{
////BCC/ BEGIN CUSTOM CODE SECTION
////ECC/ END CUSTOM CODE SECTION
        public TaskBookEditDto TaskBook { get; set; }

}
}