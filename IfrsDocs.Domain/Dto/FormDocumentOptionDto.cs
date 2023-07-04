namespace IfrsDocs.Domain.Dto
{
    public class FormDocumentOptionDto
    {
        public FormDocumentOptionDto(int documentOptionId)
        {
            DocumentOptionId = documentOptionId;
        }

        public int DocumentOptionId { get; set; }
    }
}
