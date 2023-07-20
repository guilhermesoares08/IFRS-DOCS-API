using System.IO;

namespace IfrsDocs.Domain.Entities
{
    public class AttachmentData
    {
        public string FileName { get; set; }
        public Stream ContentStream { get; set; }
    }
}
