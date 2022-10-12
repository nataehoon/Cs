using Microsoft.EntityFrameworkCore;

namespace FirstBlazorWeb.Data
{
    public interface IBoardService
    {
        Task<List<Board>> GetBoardsAsync(string boardtype);
        Task CreateBoardAsync(Board model);
        Task UpdateBoardAsync(Board model, int bono);
        Task DeleteBoardAsync(int bono);
        Task<List<Board>?> GetBoardSearchAsync(string keyword, string category, string boardtype);
        Task<Board> GetBoardByBonoAsync(int bono);
        Task UpdateRecommendAsync(int bono, string boardrecom);
    }
    public class BoardService :IBoardService
    {
        private readonly EXLogContext _context;
        private readonly NavigationManager _navigationManager;

        public BoardService(EXLogContext context, NavigationManager navigationManager)
        {
            _context = context;
            _navigationManager = navigationManager;
        }

        public async Task CreateBoardAsync(Board model)
        {
            _context.Boards.Add(model);
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("/board/" + model.Boardtype);
        }

        public async Task DeleteBoardAsync(int bono)
        {
            var result = await _context.Boards.FindAsync(bono);
            if(result != null)
            {
                _context.Boards.Remove(result);
                await _context.SaveChangesAsync();
                _navigationManager.NavigateTo("/board/" + result.Boardtype);
            }
        }

        public async Task<Board> GetBoardByBonoAsync(int bono)
        {
            return await _context.Boards.FindAsync(bono);
        }

        public async Task<List<Board>> GetBoardsAsync(string boardtype)
        {
            return (await _context.Boards.ToListAsync()).Where(b => b.Boardtype == boardtype).OrderByDescending(b => b.Bono).ToList();
        }

        public async Task<List<Board>?> GetBoardSearchAsync(string keyword, string category, string boardtype)
        {
            var result = await _context.Boards.ToListAsync();
            if (category.Equals("subject"))
            {
                return result.Where(b => b.Title.Contains(keyword) && b.Boardtype == boardtype).ToList();
            }
            else if (category.Equals("content"))
            {
                return result.Where(b => b.Content.Contains(keyword) && b.Boardtype == boardtype).ToList();
            }
            else if (category.Equals("subcont"))
            {
                return result.Where(b => b.Boardtype == boardtype && (b.Title.Contains(keyword) || b.Content.Contains(keyword))).ToList();
            }
            else if (category.Equals("user"))
            {
                return result.Where(b => b.Boardtype == boardtype && b.Id.Contains(keyword)).ToList();
            }
            else if (keyword == null)
            {
                return result.OrderByDescending(b => b.Bono).ToList();
            }
            return null;
        }

        public async Task UpdateBoardAsync(Board model, int bono)
        {
            var result = await _context.Boards.FindAsync(bono);
            if(result != null)
            {
                result.Boardtype = model.Boardtype;
                result.Recommend = model.Recommend;
                result.Title = model.Title;
                result.Content = model.Content;
                result.Image = model.Image;
                result.Attachfile = model.Attachfile;
                _context.Boards.Update(result);
                await _context.SaveChangesAsync();
            }
            _navigationManager.NavigateTo("/boarddetail/"+ model.Bono);
        }

        public async Task UpdateRecommendAsync(int bono, string boardrecom)
        {
            var result = await _context.Boards.FindAsync(bono);
            if (boardrecom.Equals("up") && result != null)
            {
                result.Recommend++;
                _context.Boards.Update(result);
                await _context.SaveChangesAsync();
            }
            else
            {
                result.Recommend--;
                _context.Boards.Update(result);
                await _context.SaveChangesAsync();
            }

        }
    }
}
