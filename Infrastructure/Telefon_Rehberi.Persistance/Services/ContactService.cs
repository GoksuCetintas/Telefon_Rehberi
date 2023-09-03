using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telefon_Rehberi.Application.Interfaces.Repositories;
using Telefon_Rehberi.Application.Interfaces.Services;
using Telefon_Rehberi.Application.ViewModels;
using Telefon_Rehberi.Domain.Entities;

namespace Telefon_Rehberi.Persistance.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactService(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }
        public async Task AddAsync(ContactAddViewModel contactAddViewModel)
        {
            var contact = _mapper.Map<Contact>(contactAddViewModel);
            await _contactRepository.AddAsync(contact);
        }

        public async Task DeleteAsync(string Id)
        {
            var contact = await _contactRepository.GetByIdAsync(Id);
            if (contact != null)
            {
                await _contactRepository.DeleteAsync(contact);
            }
        }

        public async Task<List<ContactViewModel>> GetAllAsync(string? firstName = null, string? lastName = null, string? phone = null)
        {
            var contacts = await _contactRepository.GetAllAsync();
            if (firstName == null && lastName == null && phone == null)
            {
                var listContactViewModel = _mapper.Map<List<ContactViewModel>>(contacts);
                return listContactViewModel;
            }
            if (firstName != null)
            {
                contacts = contacts.Where(x => x.FirstName.ToLower().Contains(firstName)).ToList();
            }
            if (lastName != null)
            {
                contacts = contacts.Where(x => x.LastName.ToLower().Contains(lastName)).ToList();
            }
            if (phone != null)
            {
                contacts = contacts.Where(x => x.Phone.ToLower().Contains(phone)).ToList();
            }
            var a = _mapper.Map<List<ContactViewModel>>(contacts);
            return a;

        }

        public async Task<ContactUpdateViewModel> GetAsync(string Id)
        {
            var contact = await _contactRepository.GetByIdAsync(Id);
            return _mapper.Map<ContactUpdateViewModel>(contact);
        }

        public async Task<List<ContactViewModel>> GetContactsByFilter(string? firstName = null, string? lastName = null, string? phone = null)
        {
            var searchString = await _contactRepository.GetAllAsync();
            if (firstName != null)
            {
                searchString = searchString.Where(x => x.FirstName.ToLower().Contains(firstName)).ToList();
            }
            if (lastName != null)
            {
                searchString = searchString.Where(x => x.LastName.ToLower().Contains(lastName)).ToList();
            }
            if (phone != null)
            {
                searchString = searchString.Where(x => x.Phone.ToLower().Contains(phone)).ToList();
            }
            return _mapper.Map<List<ContactViewModel>>(searchString);
        }

        public async Task UpdateAsync(ContactUpdateViewModel updatedVm)
        {
            var contact = await _contactRepository.GetByIdAsync(updatedVm.Id);
            if (contact != null)
            {
                contact.FirstName = updatedVm.FirstName;
                contact.LastName = updatedVm.LastName;
                contact.Email = updatedVm.Email;
                contact.Phone = updatedVm.Phone;
                await _contactRepository.UpdateAsync(contact);
            }
        }
    }
}
