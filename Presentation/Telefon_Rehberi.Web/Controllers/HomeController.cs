using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Telefon_Rehberi.Application.Interfaces.Repositories;
using Telefon_Rehberi.Application.Interfaces.Services;
using Telefon_Rehberi.Application.ViewModels;
using Telefon_Rehberi.Domain.Entities;
using Telefon_Rehberi.Persistance.Repositories.EntityFramework;
using Telefon_Rehberi.Web.Models;

namespace Telefon_Rehberi.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContactService _contactService;

        public HomeController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IActionResult> Index(string? firstName = null, string? lastName = null, string? phone = null)
        {   
            var contacts = await _contactService.GetAllAsync(firstName, lastName, phone);
            ViewBag.FirstName = firstName;
            ViewBag.LastName = lastName;
            ViewBag.Phone = phone;
            return View(contacts);           
        }
        [HttpGet]
        public async Task<IActionResult> Update(string Id)
        {
            var contactViewModel = await _contactService.GetAsync(Id);
            return View(contactViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ContactUpdateViewModel updateViewModel)
        {
            await _contactService.UpdateAsync(updateViewModel);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string Id)
        {
            await _contactService.DeleteAsync(Id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(ContactAddViewModel contactAddViewModel)
        {
            await _contactService.AddAsync(contactAddViewModel);
            return RedirectToAction(nameof(Index));
        }

    }
}