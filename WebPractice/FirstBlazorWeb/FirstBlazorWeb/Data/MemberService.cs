using Microsoft.EntityFrameworkCore;

namespace FirstBlazorWeb.Data
{
    public interface IMemberService
    {
        Task<List<Member>> GetMembersAsync();
        Task CreateMemberAsync(Member model);
        Task UpdateMemberAsync(Member model, string id);
        Task DeleteMemberAsync(string id);
        Task<Member> GetMemberByIdAsync(string id);
        Task<List<Member>> GetMemberByResAsync(string res);
        Task UpdateMemberResponsibilityAsync(string responsibility, string id);
        Task<List<Member>> GetMemberNickAsync(string nick);
    }
    public class MemberService : IMemberService
    {
        private readonly EXLogContext _context;
        private readonly NavigationManager _navigationManager;

        public MemberService(EXLogContext context, NavigationManager navigationManager)
        {
            _context = context;
            _navigationManager = navigationManager;
        }

        public async Task CreateMemberAsync(Member model)
        {
            _context.Members.Add(model);
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("/");
        }

        public async Task DeleteMemberAsync(string id)
        {
            var result = await _context.Members.FindAsync(id);
            if(result != null)
            {
                _context.Members.Remove(result);
                await _context.SaveChangesAsync();
            }
            _navigationManager.NavigateTo("/");
        }

        public async Task<Member> GetMemberByIdAsync(string id)
        {
            var result = await _context.Members.FindAsync(id);
            await Task.Delay(300);
            return result;
        }

        public async Task<List<Member>> GetMemberByResAsync(string res)
        {
            return (await _context.Members.ToListAsync()).Where(m => m.Resposibility == res).ToList();
        }

        public async Task<List<Member>> GetMemberNickAsync(string nick)
        {
            var result = await _context.Members.ToListAsync();
            result = result.Where(m => m.Nick.Equals(nick)).ToList();
            if(result.Count > 0)
            {
                return result;
            }else
            {
                return null;
            }
        }

        public async Task<List<Member>> GetMembersAsync()
        {
            return await _context.Members.ToListAsync();
        }

        public async Task UpdateMemberAsync(Member model, string id)
        {
            var result = await _context.Members.FindAsync(id);
            if (result != null)
            {
                result.Name = model.Name;
                result.Pw = model.Pw;
                result.Gender = model.Gender;
                result.Age = model.Age;
                result.Nick = model.Nick;
                result.Email = model.Email;
                result.Hp = model.Hp;
                result.Exhistory = model.Exhistory;
                result.Pimage = model.Pimage;
                result.Mehistory = model.Mehistory;
                result.Postop = model.Postop;
                result.Memo = model.Memo;
                result.Resposibility = model.Resposibility;
                _context.Members.Update(result);
                await _context.SaveChangesAsync();
            }
            _navigationManager.NavigateTo("/"+model.Id);
        }

        public async Task UpdateMemberResponsibilityAsync(string responsibility, string id)
        {
            var result = await _context.Members.FindAsync(id);
            if (result != null)
            {
                result.Resposibility = responsibility;
                _context.Members.Update(result);
                await _context.SaveChangesAsync();
            }
        }
    }
}
