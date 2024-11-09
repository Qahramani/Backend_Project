using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Pustok.DAL.DataContext.AppSettingModels;
using Pustok.DAL.Enums;

namespace Pustok.DAL.DataContext;

public class DataInitializer
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly AppDbContext _dbConetxt;
    private readonly IConfiguration _configuration;

    public DataInitializer(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, AppDbContext dbConetxt, IConfiguration configuration)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _dbConetxt = dbConetxt;
        _configuration = configuration;
    }

    public async Task SeedData()
    {
        await _dbConetxt.Database.MigrateAsync();

        await createRolesAsync();

        await createSuperAdminAsync();
    }

    private async Task createRolesAsync()
    {
        var roles = Enum.GetNames(typeof(RoleType));

        foreach (var role in roles)
        {
            if (await _roleManager.FindByNameAsync(role) != null)
                continue;

            await _roleManager.CreateAsync(new IdentityRole { Name = role});
        }
    }

    private async Task createSuperAdminAsync()
    {
        var superAdmin = _configuration.GetSection("SuperAdmin").Get<SuperAdmin>();

        if (superAdmin == null) return;

        var existSuperAdmin = await _userManager.FindByNameAsync(superAdmin.Username);
        if (existSuperAdmin != null) return;

        var superAdminUser = new AppUser
        { 
            Fullname = superAdmin.Fullname,
            UserName = superAdmin.Username,
            Email = superAdmin.Email
        };

        var result = await _userManager.CreateAsync(superAdminUser,superAdmin.Password);

        if (!result.Succeeded)
            throw new Exception("User is not created");

        result = await _userManager.AddToRolesAsync(superAdminUser,[RoleType.SuperAdmin.ToString(),RoleType.Admin.ToString()]);

        if (!result.Succeeded) 
            throw new Exception("User can't assigned");
    }
}

