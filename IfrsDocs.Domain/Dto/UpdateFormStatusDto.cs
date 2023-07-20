using System.Collections.Generic;
using System.IO;
using IfrsDocs.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace IfrsDocs.Domain
{
    public class UpdateFormStatusDto
    {
        public int Status { get; set; }
        public int UserId { get; set; }
        public List<AttachmentData> Attachments { get; set; }
    }
}
