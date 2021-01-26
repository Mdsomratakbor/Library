using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Services.Interfaces
{
    public interface IPatronServices
    {
        Patron Get(int id);
        List<Patron> GetAll();
        void Add(Patron newPatron);
        List<CheckoutHistory> GetCheckoutHistories(int patronId);
        List<Hold> GetHolds(int patronId);
        List<Checkout> GetCheckouts(int patronId);
    }
}
