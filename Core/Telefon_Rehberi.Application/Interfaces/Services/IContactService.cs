using System.Text.Json.Serialization;
using Telefon_Rehberi.Application.ViewModels;
using Telefon_Rehberi.Domain.Entities;

namespace Telefon_Rehberi.Application.Interfaces.Services
{
    public interface IContactService
    {
        Task<List<ContactViewModel>> GetAllAsync(string? firstName = null, string? lastName = null, string? phone = null);
        Task AddAsync(ContactAddViewModel contactAddViewModel);
        Task UpdateAsync(ContactUpdateViewModel updateViewModel);
        Task DeleteAsync(string Id);
        Task<ContactUpdateViewModel> GetAsync(string Id);
        Task<List<ContactViewModel>> GetContactsByFilter(string? firstName=null, string? lastName=null, string? phone=null);


    }
}
