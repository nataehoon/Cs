using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FirstBlazorWeb.Data
{
    public interface IExerciselogService
    {
        Task<List<Exerciselog>> GetExerciselogsAsync();
        Task CreateExerciselogAsync(Exerciselog model);
        Task UpdateExerciselogAsync(Exerciselog model, int exno);
        Task DeleteExerciselogAsync(int exno);
        Task<Exerciselog> GetExerciselogByExnoAsync(int exno);
        Task<List<Exerciselog>> GetExerciselogByIdAsync(string id);
        Task<List<Exerciselog>> GetExerciselogByExtypeAsync(string extype);
        Task<List<Exerciselog>> GetExerciselogByExnameAsync(string exname);

    }
    public class ExerciselogService : IExerciselogService
    {
        private readonly EXLogContext _context;
        private readonly NavigationManager _navigationManager;

        public ExerciselogService(EXLogContext context, NavigationManager navigationManager)
        {
            _context = context;
            _navigationManager = navigationManager;
        }
        public async Task CreateExerciselogAsync(Exerciselog model)
        {
            _context.Exerciselogs.Add(model);
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("/exerciselog/"+model.Id);
        }

        public async Task DeleteExerciselogAsync(int exno)
        {
            var result = await _context.Exerciselogs.FindAsync(exno);
            string id = string.Empty;
            if(result != null)
            {
                id = result.Id;
                _context.Exerciselogs.Remove(result);
                await _context.SaveChangesAsync();
            }
            _navigationManager.NavigateTo("/exerciselog/"+id, forceLoad:true);
        }

        public async Task<List<Exerciselog>> GetExerciselogByExnameAsync(string exname)
        {
            return ((await _context.Exerciselogs.ToListAsync()).Where(e => e.Exname == exname)).ToList();
        }

        public async Task<Exerciselog> GetExerciselogByExnoAsync(int exno)
        {
            var result = await _context.Exerciselogs.FindAsync(exno);
            return result;
            /*return await _context.Exerciselogs.SingleOrDefaultAsync(e => e.Exno == exno);*/
        }

        public async Task<List<Exerciselog>> GetExerciselogByExtypeAsync(string extype)
        {
            var result = await _context.Exerciselogs.ToListAsync();
            return (result.Where(e => e.Extype == extype)).ToList();
        }

        public async Task<List<Exerciselog>> GetExerciselogByIdAsync(string id)
        {
            var result = await _context.Exerciselogs.ToListAsync();
            return (result.Where(e => e.Id == id)).OrderByDescending(e => e.Exno).ToList();
        }

        public async Task<List<Exerciselog>> GetExerciselogsAsync()
        {
            var result = await _context.Exerciselogs.ToListAsync(); 
            return _context.Exerciselogs.OrderByDescending(result => result.Exno).ToList();
        }

        public async Task UpdateExerciselogAsync(Exerciselog model, int exno)
        {
            var result = await _context.Exerciselogs.FindAsync(exno);
            if(result != null)
            {
                result.Exdate = model.Exdate;
                result.Exlog = model.Exlog;
                result.Memo = model.Memo;
                result.Exname = model.Exname;
                result.Exrep = model.Exrep;
                result.Exset = model.Exset;
                _context.Exerciselogs.Update(result);
                await _context.SaveChangesAsync();
            }
            _navigationManager.NavigateTo("/exerciselog/"+model.Id);
        }
    }
}
