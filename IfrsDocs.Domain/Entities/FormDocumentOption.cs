namespace IfrsDocs.Domain
{
    public  class FormDocumentOption
    {
        public int FormId { get; set; }
        public int DocumentOptionId { get; set; }
        public Form Form { get; set; }
        public DocumentOption DocumentOption { get; set; }
    }
}
