using System.ComponentModel.DataAnnotations;

namespace InnoClinic.DocumentsAPI.Application.DataTranferObjects
{
    public class PhotoForUpdateDto
    {
        [Required]
        public string Url { get; set; }
    }
}
