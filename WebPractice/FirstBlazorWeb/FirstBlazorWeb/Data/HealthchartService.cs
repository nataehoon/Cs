using Microsoft.EntityFrameworkCore;

namespace FirstBlazorWeb.Data
{
    public interface IHealthchartService
    {
        Task<List<Healthchart>> GetHealthchartsAsync();
        Task CreateHealthchartAsync(Healthchart model);
        Task UpdateHealthchartAsync(Healthchart model, int heno);
        Task DeleteHealthchartAsync(int id);
        Task<List<Healthchart>> GetAllHealthchartByIdAsync(string id);
        Task<Healthchart> GetHealthchartByHenoAsync(int heno);
        Task<int> GetHealthchartCountAsync(string id);
    }
    public class HealthchartService : IHealthchartService
    {
        private readonly EXLogContext _context;
        private readonly NavigationManager _navigationManager;

        public HealthchartService(EXLogContext context, NavigationManager navigationManager)
        {
            _context = context;
            _navigationManager = navigationManager;
        }

        public async Task CreateHealthchartAsync(Healthchart model)
        {
            _context.Healthcharts.Add(model);
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("/healthchart");
        }

        public async Task DeleteHealthchartAsync(int heno)
        {
            var result = await _context.Healthcharts.FindAsync(heno);
            string id = string.Empty;
            if(result != null)
            {
                id = result.Id;
                _context.Healthcharts.Remove(result);
                await _context.SaveChangesAsync();
            }
            _navigationManager.NavigateTo("/healthchart", forceLoad:true);
        }

        public async Task<List<Healthchart>> GetAllHealthchartByIdAsync(string id)
        {
            return (await _context.Healthcharts.ToListAsync()).Where(h => h.Id == id).OrderByDescending(h => h.Heno).ToList();
        }

        public async Task<Healthchart> GetHealthchartByHenoAsync(int heno)
        {
            return await _context.Healthcharts.FindAsync(heno);
        }

        public async Task<int> GetHealthchartCountAsync(string id)
        {
            return (await _context.Healthcharts.ToListAsync()).Count;
        }

        public async Task<List<Healthchart>> GetHealthchartsAsync()
        {
            return await _context.Healthcharts.ToListAsync();
        }

        public async Task UpdateHealthchartAsync(Healthchart model, int heno)
        {
            var result = await _context.Healthcharts.FindAsync(heno);
            if(result != null)
            {
                result.Weight = model.Weight;
                result.Height = model.Height;
                result.Fat = model.Fat;
                result.Muscle = model.Muscle;
                result.Jobtype = model.Jobtype;
                result.Totalcho = model.Totalcho;
                result.Hdl = model.Hdl;
                result.Ldl = model.Ldl;
                result.Bun = model.Bun;
                result.Crtn = model.Crtn;
                result.Memo = model.Memo;
                _context.Healthcharts.Update(result);
                await _context.SaveChangesAsync();
            }
            _navigationManager.NavigateTo("/healthchart");
        }
    }
}
