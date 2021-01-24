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
    public class CheckoutServices : ICheckout
    {
        private LibraryContext _context;
        public CheckoutServices(LibraryContext context)
        {
            _context = context;
        }
        public void Add(Checkout newCheckout)
        {
            _context.Add(newCheckout);
            _context.SaveChanges();
        }


        public List<Checkout> GetAll()
        {
           return  _context.Checkouts.ToList();
        }

        public Checkout GetById(int checkoutId)
        {
            return GetAll().FirstOrDefault(x=>x.Id == checkoutId);
        }

        public List<CheckoutHistory> GetCheckoutHistory(int id)
        {
            return _context.CheckoutHistories
                .Include(h => h.LibraryAsset)
                .Include(h=>h.LibraryCard)
                .Where(h=>h.LibraryAsset.Id == id).ToList();
        }

   

        public List<Hold> GetCurrentHolds(int id)
        {
            return _context.Holds
                .Include(h => h.LibraryAsset)
                .Where(h => h.LibraryAsset.Id == id).ToList();
        }
        public Checkout GetLatestCheckout(int assetId)
        {
            return _context.Checkouts
                .Where(c=>c.LibraryAsset.Id== assetId)
                .OrderBy(c=>c.Since)
                .FirstOrDefault();
        }

        public void MarkFound(int assetId)
        {
            throw new NotImplementedException();
        }

        public void MarkLost(int assetId)
        {
            throw new NotImplementedException();
        }

        public void PlaceHold(int assetId, int libraryCardId)
        {
            throw new NotImplementedException();
        }




        public void CheckInItem(int assertId, int libraryCardId)
        {
            throw new NotImplementedException();
        }

        public void CheckOutItem(int assetId, int libraryCardId)
        {
            throw new NotImplementedException();
        }
        public string GetCurrentHoldPatronName(int id)
        {
            throw new NotImplementedException();
        }

        public DateTime GetCurrentHoldPlaced(int id)
        {
            throw new NotImplementedException();
        }
    }
}
