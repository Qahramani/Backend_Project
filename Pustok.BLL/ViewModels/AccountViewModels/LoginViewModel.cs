﻿namespace Pustok.BLL.ViewModels.AccountViewModels;

public class LoginViewModel 
{
    public string Email { get; set; }
    public string Password { get; set; }
    public bool SaveMe { get; set; } = false;
}
