﻿using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Services.Interfaces
{
    public interface ICheckoutServices
    {
        void Add(Checkout newCheckout);
        List<Checkout> GetAll();
        List<CheckoutHistory> GetCheckoutHistory(int id);
        List<Hold> GetCurrentHolds(int id);
        Checkout GetById(int checkoutId);
        Checkout GetLatestCheckout(int assetId);
        bool IsCheckedOut(int assetId);
        void CheckOutItem(int assetId, int libraryCardId);
        void CheckInItem(int assertId);
        void PlaceHold(int assetId, int libraryCardId);
        void MarkLost(int assetId);
        void MarkFound(int assetId);


        string GetCurrentHoldPatronName(int id);
        string GetCurrentCheckoutPatron(int assetId);

        DateTime GetCurrentHoldPlaced(int id);
  
   
     
    }
}
