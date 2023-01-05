using Azure;
using Azure.Data.Tables;
using InnoClinic.DocumentsAPI.Core.Entities.Attributes;
using System.ComponentModel.DataAnnotations;

namespace InnoClinic.DocumentsAPI.Core.Entities.Models
{
    [Collection("Document")]
    public class Document : ITableEntity
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public Guid ResultId { get; set; }
        [Required]
        public string Type = nameof(Document);
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}
