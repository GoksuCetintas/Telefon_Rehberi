using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telefon_Rehberi.Application.Interfaces.Repositories;
using Telefon_Rehberi.Domain.Entities;
using Telefon_Rehberi.Persistance.Data.Context;

namespace Telefon_Rehberi.Persistance.Repositories.EntityFramework
{
    public class EfContactRepository : GenericRepository<Contact>, IContactRepository
    {
        private readonly ApplicationDbContext _db;

        public EfContactRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
