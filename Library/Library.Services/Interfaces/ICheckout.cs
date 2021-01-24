using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Services.Interfaces
{
    public interface ICheckout
    {
        List<Checkout> GetAll();
        Checkout GetById(int checkoutId);
        void Add(Checkout newCheckout);
        void CheckOutItem(int assetId, int libraryCardId);
        void CheckInItem(int assertId, int libraryCardId);
        List<CheckoutHistory> GetCheckoutHistory(int id);
        void PlaceHold(int assetId, int libraryCardId);
        string GetCurrentHoldPatronName(int id);
        DateTime GetCurrentHoldPlaced(int id);
        List<Hold> GetCurrentHolds(int id);
        void MarkLost(int assetId);
        void MarkFound(int assetId);
        Checkout GetLatestCheckout(int assetId);
    }
}
