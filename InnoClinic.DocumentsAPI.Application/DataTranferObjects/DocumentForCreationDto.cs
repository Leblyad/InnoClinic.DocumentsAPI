using System.ComponentModel.DataAnnotations;

namespace InnoClinic.DocumentsAPI.Application.DataTranferObjects
{
    public class DocumentForCreationDto
    {
        [Required]
        public Guid ResultId { get; set; }
        public string FileName { get; set; }
        public byte[] Value { get; set; }
    }
}
