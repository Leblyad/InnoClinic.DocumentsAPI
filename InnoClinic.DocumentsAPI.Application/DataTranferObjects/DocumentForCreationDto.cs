using System.ComponentModel.DataAnnotations;

namespace InnoClinic.DocumentsAPI.Application.DataTranferObjects
{
    public class DocumentForCreationDto
    {
        [Required]
        public string Url { get; set; }
        [Required]
        public Guid ResultId { get; set; }
    }
}
