using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    public class EditModel : PageModel
    {
        private readonly BloggieDbContext bloggieDbContext;

        [BindProperty]
        public BlogPost BlogPost { get; set; }

        public EditModel(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }
        public void OnGet(Guid id)
        {
            BlogPost = bloggieDbContext.BlogPosts.Find(id);



        }

        public IActionResult OnPost()
        {
            var existingBlogPost = bloggieDbContext.BlogPosts.Find(BlogPost.id);
           
            if (existingBlogPost != null)
            {
                existingBlogPost.Heading = BlogPost.Heading;
                existingBlogPost.PageTitle = BlogPost.PageTitle;
                existingBlogPost.Content = BlogPost.Content;
                existingBlogPost.Heading = BlogPost.Heading;
                existingBlogPost.ShortDescription = BlogPost.ShortDescription;
                existingBlogPost.FeturedImageUrl = BlogPost.FeturedImageUrl;
                existingBlogPost.UrlHandle = BlogPost.UrlHandle;
                existingBlogPost.PublishedDate = BlogPost.PublishedDate;
                existingBlogPost.Author = BlogPost.Author;
                existingBlogPost.Visible = BlogPost.Visible;

            }

            bloggieDbContext.SaveChanges();
            return RedirectToPage("/Admin/Blogs/List");
        }
        
    }
}
