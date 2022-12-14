using System.Data;

namespace Bloggie.Web.Models.Domain
{
    public class BlogPost
    {
        public Guid id { get; set; }

        public string Heading { get; set; }
        public string PageTitle { get; set; }
        public string Content { get; set; }
        public string ShortDescription { get; set; }
        public string FeturedImageUrl { get; set; }
        public string UrlHandle { get; set; }
        public DataSetDateTime PublishedDate { get; set; }
        public string Author { get; set; }

        public bool Visible { get; set; }
    }
}
