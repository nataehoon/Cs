using Microsoft.EntityFrameworkCore;

namespace FirstBlazorWeb.Data
{
    public interface ICommentService
    {
        Task<List<Comment>> GetCommentsByBonoAsync(int bono);
        Task CreateCommentAsync(Comment model);
        Task UpdateCommentAsync(Comment model, int cono);
        Task DeleteCommentAsync(int cono);
    }
    public class CommentService : ICommentService
    {
        private readonly EXLogContext _context;
        private readonly NavigationManager _navigationManager;

        public CommentService(EXLogContext context, NavigationManager navigationManager)
        {
            _context = context;
            _navigationManager = navigationManager;
        }

        public async Task CreateCommentAsync(Comment model)
        {
            _context.Comments.Add(model);
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("/board");
        }

        public async Task DeleteCommentAsync(int cono)
        {
            var result = await _context.Comments.FindAsync(cono);
            if(result != null)
            {
                _context.Comments.Remove(result);
                await _context.SaveChangesAsync();
            }
            _navigationManager.NavigateTo("/board");
        }

        public async Task<List<Comment>> GetCommentsByBonoAsync(int bono)
        {
            var result = await _context.Comments.FindAsync(bono);
            if(result != null)
            {
                return await _context.Comments.ToListAsync();
            }
            else
            {
                return null;
            }
        }

        public async Task UpdateCommentAsync(Comment model, int cono)
        {
            var result = await _context.Comments.FindAsync(cono);
            if(result != null)
            {
                result.Comment1 = model.Comment1;
                result.Recommend = model.Recommend;
                _context.Comments.Update(result);
                await _context.SaveChangesAsync();
            }
        }
    }
}
