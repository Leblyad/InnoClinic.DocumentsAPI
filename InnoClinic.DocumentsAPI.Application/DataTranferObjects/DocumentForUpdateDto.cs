using System.ComponentModel.DataAnnotations;

namespace InnoClinic.DocumentsAPI.Application.DataTranferObjects
{
    public class DocumentForUpdateDto
    {
        [Required]
        public string Url { get; set; }
        [Required]
        public Guid ResultId { get; set; }
    }
}
