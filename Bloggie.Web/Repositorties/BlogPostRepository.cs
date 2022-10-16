using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Repositorties
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BloggieDbContext bloggieDbContext;

        public BlogPostRepository(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }
        public async Task<BlogPost> AddAsync(BlogPost blogpost)
        {
            var blogPost = new BlogPost();

            await bloggieDbContext.BlogPosts.AddAsync(blogPost);
            await bloggieDbContext.SaveChangesAsync();
            return blogpost;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existingBlog = await bloggieDbContext.BlogPosts.FindAsync(id);

            if (existingBlog != null)
            {
                bloggieDbContext.BlogPosts.Remove(existingBlog);
                await bloggieDbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await bloggieDbContext.BlogPosts.ToListAsync();
        }

        public async Task<BlogPost> GetAsync(Guid id)
        {
           return await bloggieDbContext.BlogPosts.FindAsync(id);
        }

        public async Task<BlogPost> UpdateAsync(BlogPost blogpost)
        {
            var existingBlogPost = await bloggieDbContext.BlogPosts.FindAsync(blogpost.id);

            if (existingBlogPost != null)
            {
                existingBlogPost.Heading = blogpost.Heading;
                existingBlogPost.PageTitle = blogpost.PageTitle;
                existingBlogPost.Content = blogpost.Content;
                existingBlogPost.Heading = blogpost.Heading;
                existingBlogPost.ShortDescription = blogpost.ShortDescription;
                existingBlogPost.FeturedImageUrl = blogpost.FeturedImageUrl;
                existingBlogPost.UrlHandle = blogpost.UrlHandle;
                existingBlogPost.PublishedDate = blogpost.PublishedDate;
                existingBlogPost.Author = blogpost.Author;
                existingBlogPost.Visible = blogpost.Visible;

            }

            await bloggieDbContext.SaveChangesAsync();
            return existingBlogPost;
        }
    }
}
