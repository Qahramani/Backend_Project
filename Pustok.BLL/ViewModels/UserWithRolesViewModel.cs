﻿namespace Pustok.BLL.ViewModels;
public class UserWithRolesViewModel
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public List<string> Roles { get; set; }
    public bool IsActive { get; set; }
}

