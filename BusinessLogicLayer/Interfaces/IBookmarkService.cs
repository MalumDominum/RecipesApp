using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace BusinessLogicLayer.Interfaces
{
    public interface IBookmarkService : IDisposable
    {
        Task<List<BookmarkDTO>> GetBookmarksAsync();

        Task<List<BookmarkDTO>> GetBookmarksByUserIdAsync(int userId);

        Task<List<BookmarkDTO>> GetBookmarksByRecipeIdAsync(int recipeId);

        Task<bool> AnyBookmarksAsync(Expression<Func<Bookmark, bool>> expression);

        Task PostBookmarkAsync(BookmarkDTO bookmark);

        Task PutBookmarkAsync(BookmarkDTO bookmark);

        Task DeleteBookmarkAsync(int userId, int recipeId);
    }
}
