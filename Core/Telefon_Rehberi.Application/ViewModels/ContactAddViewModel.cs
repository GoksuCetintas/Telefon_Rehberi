using Microsoft.AspNetCore.Http;

namespace Telefon_Rehberi.Application.ViewModels;

public class ContactAddViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}

