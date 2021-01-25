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
        private readonly LibraryContext _context;
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
            return _context.Checkouts.ToList();
        }

        public Checkout GetById(int checkoutId)
        {
            return GetAll().FirstOrDefault(x => x.Id == checkoutId);
        }

        public List<CheckoutHistory> GetCheckoutHistory(int id)
        {
            return _context.CheckoutHistories
                .Include(h => h.LibraryAsset)
                .Include(h => h.LibraryCard)
                .Where(h => h.LibraryAsset.Id == id).ToList();
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
                .Where(c => c.LibraryAsset.Id == assetId)
                .OrderBy(c => c.Since)
                .FirstOrDefault();
        }

        public void MarkFound(int assetId)
        {
            var now = DateTime.Now;
            
            UpdateAssetStatus(assetId, "Available");
            RemoveExistingCheckouts(assetId);
            CloseExistingCheckoutHistory(assetId,now);        
            _context.SaveChanges();
        }

        private void UpdateAssetStatus(int assetId, string flag)
        {
            var item = _context.LibraryAssets
                   .FirstOrDefault(x => x.Id == assetId);
            _context.Update(item);
            item.Status = _context.Statuses
             .FirstOrDefault(status => status.Name == flag);
        }

        private void CloseExistingCheckoutHistory(int assetId, DateTime now)
        {
            var history = _context.CheckoutHistories
               .FirstOrDefault(x => x.LibraryAsset.Id == assetId && x.CheckedIn == null);
            if (history != null)
            {
                _context.Update(history);
                history.CheckedIn = now;
            }
        }

        private void RemoveExistingCheckouts(int assetId)
        {
            var checkout = _context.Checkouts
               .FirstOrDefault(x => x.LibraryAsset.Id == assetId);
            if (checkout != null)
            {
                _context.Remove(checkout);
            }
        }

        public void MarkLost(int assetId)
        {
            UpdateAssetStatus(assetId, "Lost");
            _context.SaveChanges();
        }

        public void PlaceHold(int assetId, int libraryCardId)
        {
            var now = DateTime.Now;
            var asset = _context.LibraryAssets
                .FirstOrDefault(x=>x.Id == assetId);
            var card = _context.LibraryCards
                .FirstOrDefault(x=>x.Id == libraryCardId);
            if(asset.Status.Name == "Available")
            {
                UpdateAssetStatus(assetId, "On Hold");
            }
            var hold = new Hold
            {
                HoldPlaced = now,
                LibraryAsset = asset,
                LibraryCard = card,
            };
            _context.Add(hold);
            _context.SaveChanges();
        }




        public void CheckInItem(int assetId, int libraryCardId)
        {
            var now = DateTime.Now;
            var item = _context.LibraryAssets
                .FirstOrDefault(a => a.Id == assetId);
           
            //DONE: remove any existing chekouts on the item
            RemoveExistingCheckouts(assetId);

            //DONE: close any existing checkout history
            CloseExistingCheckoutHistory(assetId, now);
            //DONE: look for existing holds on the item
            var currentHolds = _context.Holds
                .Include(h=>h.LibraryAsset)
                .Include(h=>h.LibraryCard)
                .Where(h=>h.LibraryAsset.Id== assetId);

            //DONE: if there are holds, chekcout the item to the librarycard with the earliest hold.

            if (currentHolds.Any())
            {
                CheckouToEarliestHold(assetId, currentHolds);
            }
            //TODO: otherwise update the item status to available
            UpdateAssetStatus(assetId, "Available");
            _context.SaveChanges();
        }

        private void CheckouToEarliestHold(int assetId, IQueryable<Hold> currentHolds)
        {
            var earliestHold = currentHolds
                .OrderBy(x=>x.HoldPlaced).FirstOrDefault();
            var card = earliestHold.LibraryCard;
            _context.Remove(earliestHold);
            _context.SaveChanges();
            CheckOutItem(assetId, card.Id);
        }

        public void CheckOutItem(int assetId, int libraryCardId)
        {
            if (IsCheckOut(assetId))
            {
                return;
            }
            var item = _context.LibraryAssets
                .FirstOrDefault(a=> a.Id == assetId);
            UpdateAssetStatus(assetId, "Checked Out");
            var libraryCard = _context.LibraryCards
                .Include(x=>x.Checkouts)
                .FirstOrDefault(x=>x.Id == libraryCardId);

            var now = DateTime.Now;
            var checkout = new Checkout
            {
                LibraryAsset = item,
                LibraryCard = libraryCard,
                Since = now,
                Until = GetDefaultCheckoutTime(now)
            };
            _context.Add(checkout);
            var checkoutHistory = new CheckoutHistory
            {
                CheckedOut = now,
                LibraryAsset = item,
                LibraryCard = libraryCard,
            };
            _context.Add(checkoutHistory);
            _context.SaveChanges();
        }

        private DateTime GetDefaultCheckoutTime(DateTime now)
        {
            return now.AddDays(30);
        }

        private bool IsCheckOut(int assetId)
        {
            return _context.Checkouts
                .Where(x=>x.LibraryAsset.Id == assetId).Any();

        }

        public string GetCurrentHoldPatronName(int holdId)
        {
            var hold = _context.Holds
                .Include(x=>x.LibraryAsset)
                .Include(x=>x.LibraryCard)
                .FirstOrDefault(x=>x.Id == holdId);

            var cardId = hold?.LibraryCard.Id;
            var patron = _context.Patrons
                .Include(x=>x.LibraryCard)
                .FirstOrDefault(x=>x.LibraryCard.Id==cardId);
            return $"{patron?.FirstName} {patron?.LastName}";
        }

        public DateTime GetCurrentHoldPlaced(int holdId)
        {
            return _context.Holds
              .Include(x => x.LibraryAsset)
              .Include(x => x.LibraryCard)
              .FirstOrDefault(x => x.Id == holdId)
              .HoldPlaced;
        }

        public string GetCurrentCheckoutPatron(int assetId)
        {
            var checkout = GetCheckoutByAssetId(assetId);
            if (checkout == null) {
                return "";
            };
            var cardId = checkout.LibraryCard.Id;
            var patron = _context.Patrons
                .Include(x=>x.LibraryCard)
                .FirstOrDefault(x=>x.LibraryCard.Id== cardId);
           return $"{patron?.FirstName} {patron?.LastName}";
        }

        private Checkout GetCheckoutByAssetId(int assetId)
        {
            return _context.Checkouts
                  .Include(x => x.LibraryAsset)
                  .Include(x => x.LibraryCard)
                  .FirstOrDefault(x => x.LibraryAsset.Id == assetId);
        }
    }
}
