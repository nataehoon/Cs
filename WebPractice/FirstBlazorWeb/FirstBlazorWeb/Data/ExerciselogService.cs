using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
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
        Task<int> GetExerciselogCountAsync(string id);

        Task<List<Exercise>> GetExercisesAsync();
        Task<List<Exercise>> GetExerciseNameAsync(string extype);
        Task<List<Exercise>> GetExerciseCountAsync(string extype, string exname);
        Task CreateExerciseAsync(Exercise model);
        Task DeleteExerciseAsync(string exname);
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

        public async Task CreateExerciseAsync(Exercise model)
        {
            _context.Exercises.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task CreateExerciselogAsync(Exerciselog model)
        {
            _context.Exerciselogs.Add(model);
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("/exerciselog/"+model.Id);
        }

        public async Task DeleteExerciseAsync(string exname)
        {
            var result = await _context.Exercises.FindAsync(exname);
            if(result != null)
            {
                _context.Exercises.Remove(result);
                await _context.SaveChangesAsync();
            }
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

        public async Task<List<Exercise>> GetExerciseCountAsync(string extype, string exname)
        {
            return (await _context.Exercises.ToListAsync()).Where(e => e.Extype == extype && e.Exname == exname).ToList();
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

        public async Task<int> GetExerciselogCountAsync(string id)
        {
            return (await _context.Exerciselogs.ToListAsync()).Count;
        }

        public async Task<List<Exerciselog>> GetExerciselogsAsync()
        {
            var result = await _context.Exerciselogs.ToListAsync(); 
            return _context.Exerciselogs.OrderByDescending(result => result.Exno).ToList();
        }

        public async Task<List<Exercise>> GetExerciseNameAsync(string extype)
        {
            return (await _context.Exercises.ToListAsync()).Where(e => e.Extype == extype).ToList();
        }

        public async Task<List<Exercise>> GetExercisesAsync()
        {
            return await _context.Exercises.ToListAsync();
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
