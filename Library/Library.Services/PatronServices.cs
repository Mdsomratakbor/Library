using Library.Data.Models;
using Library.Entities;
using Library.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Services
{
    public class PatronServices : IPatronServices
    {
        private readonly LibraryContext _context = null;
            public PatronServices(LibraryContext context)
        {
            _context = context;
        }
        public void Add(Patron newPatron)
        {
            _context.Add(newPatron);
            _context.SaveChanges();
        }

        public Patron Get(int id)
        {
            return GetAll()
                  .FirstOrDefault(x => x.Id == id);
        }

        public List<Patron> GetAll()
        {
            return _context.Patrons
                .Include(x => x.LibraryCard)
                  .Include(x => x.HomeLibraryBranch).ToList();
        }

        public List<CheckoutHistory> GetCheckoutHistories(int patronId)
        {
            var cardId = _context.Patrons
                .Include(x => x.LibraryCard)
                .FirstOrDefault(x=>x.Id==patronId)
                .LibraryCard.Id;
            return _context.CheckoutHistories
                .Include(x => x.LibraryCard)
                .Include(x => x.LibraryAsset)
                .Where(x => x.LibraryCard.Id == cardId)
                .OrderByDescending(x=>x.CheckedOut)
                .ToList();

        }

        public List<Checkout> GetCheckouts(int patronId)
        {
            var cardId = _context.Patrons
                .Include(x => x.LibraryCard)
                .FirstOrDefault(x => x.Id == patronId)
                .LibraryCard.Id;

            return _context.Checkouts
                .Include(x => x.LibraryCard)
                .Include(x => x.LibraryAsset)
                .Where(x => x.LibraryCard.Id == cardId)
                .ToList();
        }

        public List<Hold> GetHolds(int patronId)
        {
            throw new NotImplementedException();
        }
    }
}
