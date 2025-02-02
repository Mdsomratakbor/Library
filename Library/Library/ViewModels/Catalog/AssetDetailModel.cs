﻿using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Web.ViewModels.Catalog
{
    public class AssetDetailModel
    {
        public int AssetId { get; set; }
        public string Title { get; set; }
        public string AuthorOrDirector { get; set; }
        public string Type { get; set; }
        public int Year { get; set; }
        public string ISBN { get; set; }
        public string Dewey { get; set; }
        public string Status { get; set; }
        public decimal Cost { get; set; }
        public string CurrentLocation { get; set; }
        public string ImageUrl { get; set; }
        public string PatronName { get; set; }
        public Checkout LatestCheckout { get; set; }
        public List<CheckoutHistory> CheckoutHistories { get; set; }
        public List<AssetHoldModel> CurrentHolds { get; set; }
    }
    public class AssetHoldModel
    {
        public string PatronName { get; set; }
        public DateTime HoldPlaced { get; set; }
    }
}
