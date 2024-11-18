using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Routing;
using Pustok.BLL.Exceptions;
using Pustok.BLL.Helpers.Contracts;
using Pustok.BLL.Services.Abstraction;
using Pustok.BLL.ViewModels.AccountViewModels;
using Pustok.DAL.Enums;
using System.Security.Principal;

namespace Pustok.BLL.Services.Implementation;

public class AccountManager : IAccountService
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMapper _mapper;
    private readonly IUrlHelper _urlHelper;
    private readonly IEmailService _emailService;

    public AccountManager(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor, IMapper mapper, IUrlHelper urlHelper, IEmailService emailService)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
        _mapper = mapper;
        _urlHelper = urlHelper;
        _emailService = emailService;
    }

    public async Task<bool> LoginAsync(LoginViewModel loginVm, ModelStateDictionary modelState)
    {

        if (_httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? true)
        {
            modelState.AddModelError(string.Empty, "User already signed in");

            return false;
        }
           

        if (!modelState.IsValid)
            return false;

      

        var user = await _userManager.FindByEmailAsync(loginVm.Email);

       

        if (user == null)
        {
            modelState.AddModelError(string.Empty, "Email or Password is incorrect");

            return false;
        }

        if (!user.IsActive)
        {
            modelState.AddModelError(string.Empty, "User is inactivated");

            return false;
        }
        if (!user.EmailConfirmed)
        {
            // Email is not confirmed, return an error
            modelState.AddModelError("", "Please confirm your email address before logging in.");
            return false;
        }

        var result = await _signInManager.PasswordSignInAsync(user, loginVm.Password, loginVm.SaveMe, true);

        if (result.IsLockedOut)
        {
            modelState.AddModelError("", "YOUR ACCOUNT WAS BLOCKED DUE TO FALSE PASSWORD ATTEMPTS");
            return false;
        }

        

        if (!result.Succeeded)
        {
            modelState.AddModelError("", "Email or Password is incorrect");

            return false;
        }
        return true;
    }



    public async Task<ServiceResponse> RegisetrAsync(RegisterViewModel registerVm, ModelStateDictionary modelState)
    {
        if (_httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? true)
        {
            return new ServiceResponse
            {
                Success = false,
                Errors = {"User already registered"}
            };
        }
          


        var user = _mapper.Map<AppUser>(registerVm);

        var result = await _userManager.CreateAsync(user,registerVm.Password);

        if (!result.Succeeded)
        {
            return new ServiceResponse
            {
                Success = false,
                Errors = result.Errors.Select(e => e.Description).ToList()
            };
        }

        

        await _userManager.AddToRoleAsync(user, RoleType.Member.ToString());

        
        // Generate email verification token
        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        var callbackUrl = _urlHelper.Action("VerifyEmail", "Account",
            new { userId = user.Id, token = token }, protocol: "https");

        // Send verification email
        var emailBody = $"Please confirm your email by clicking <a href='{callbackUrl}'>here</a>.";
        await _emailService.SendEmailAsync(user.Email, "Verify Your Email", emailBody);

        return new ServiceResponse { Success = true };
    }
    public async Task<bool> LogoutAsync()
    {
        if (!_httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? false)
            return false;

        await _signInManager.SignOutAsync();

        return true;
    }

}
public class ServiceResponse
{
    public bool Success { get; set; }
    public List<string> Errors { get; set; } = new List<string>(); 
}