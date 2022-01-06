using AutoMapper;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Models;
using System.Linq.Expressions;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Services
{
    public class BookmarkService : IBookmarkService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookmarkService(IUoWFactory uowFactory, IMapper mapper)
        {
            _unitOfWork = uowFactory.CreateUoW();
            _mapper = mapper;
        }
        public async Task<List<BookmarkDTO>> GetBookmarksAsync()
        {
            var bookmarks = await _unitOfWork.Bookmarks.GetAllAsync();

            return _mapper.Map<List<BookmarkDTO>>(bookmarks);
        }

        public async Task<List<BookmarkDTO>> GetBookmarksByUserIdAsync(int userId)
        {
            var bookmarks = await _unitOfWork.Bookmarks.GetWhereAsync(ir => ir.UserId == userId);

            return _mapper.Map<List<BookmarkDTO>>(bookmarks);
        }

        public async Task<List<BookmarkDTO>> GetBookmarksByRecipeIdAsync(int recipeId)
        {
            var bookmarks = await _unitOfWork.Bookmarks.GetWhereAsync(ir => ir.RecipeId == recipeId);

            return _mapper.Map<List<BookmarkDTO>>(bookmarks);
        }

        public async Task<int> GetBookmarksCountByRecipeIdAsync(int recipeId)
        {
            return await _unitOfWork.Bookmarks.GetCountAsync(ir => ir.RecipeId == recipeId);
        }

        public async Task<bool> AnyBookmarksAsync(Expression<Func<Bookmark, bool>> expression)
        {
            return await _unitOfWork.Bookmarks.AnyExistingAsync(expression);
        }

        public async Task PostBookmarkAsync(BookmarkDTO bookmark)
        {
            await _unitOfWork.Bookmarks.AddAsync(_mapper.Map<Bookmark>(bookmark));
            await _unitOfWork.SaveAsync();
        }

        public async Task PutBookmarkAsync(BookmarkDTO bookmark)
        {
            await _unitOfWork.Bookmarks.UpdateAsync(_mapper.Map<Bookmark>(bookmark));
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteBookmarkAsync(int userId, int recipeId)
        {
            var bookmark = await _unitOfWork.Bookmarks
                .GetFirstOrDefaultAsync(ir => ir.UserId == userId &&
                                              ir.RecipeId == recipeId);
            if (bookmark == null) throw new KeyNotFoundException();

            await _unitOfWork.Bookmarks.DeleteAsync(bookmark);
            await _unitOfWork.SaveAsync();
        }

        private bool _disposed;

        public virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing) _unitOfWork.Dispose();
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}