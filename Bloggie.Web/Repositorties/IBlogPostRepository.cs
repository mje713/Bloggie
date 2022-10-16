using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.Repositorties
{
    public interface IBlogPostRepository
    {
        Task<IEnumerable<BlogPost>> GetAllAsync();
        Task<BlogPost> GetAsync(Guid id);
        Task<BlogPost> AddAsync(BlogPost blogpost);
        Task<BlogPost> UpdateAsync(BlogPost blogpost);
        Task<bool> DeleteAsync(Guid id);

    }
}
