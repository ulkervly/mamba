using Mamba.Core.Models;
using Mamba.Data.DAL;
using Microsoft.AspNetCore.Identity;

namespace Mamba.ViewService
{
    public class LayoutService
    {
        private readonly MambaContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LayoutService(MambaContext context, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;

        }

        public async Task<AppUser> GetUser()
        {

            AppUser user = null;

            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                user = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
            }

            return user;
        }
    }
}
