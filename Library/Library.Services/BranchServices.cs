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
    public class BranchServices : IBranchServices
    {
        private LibraryContext _context;
        public BranchServices(LibraryContext context)
        {
            _context = context;
        }
        public void Add(LibraryBranch model)
        {
            _context.Add(model);
            _context.SaveChanges();
        }

        public List<LibraryBranch> GetAll()
        {
            return _context.LibraryBranches
                 .Include(a => a.Patrons)
                 .Include(a => a.LibraryAssets)
                 .ToList();
        }
        public LibraryBranch Get(int branchId)
        {
            return GetAll().FirstOrDefault(a => a.Id == branchId);
        }



        public List<LibraryAsset> GetAssets(int branchId)
        {
            return _context.LibraryBranches
                .Include(a => a.LibraryAssets)
                .FirstOrDefault(a => a.Id == branchId)
                .LibraryAssets.ToList();
        }

        public List<Patron> GetPatrons(int branchId)
        {
            return _context.LibraryBranches
                .Include(x => x.Patrons)
                .FirstOrDefault(x => x.Id == branchId)
                .Patrons.ToList();
        }

        public bool IsBranchOpen(int branchId)
        {
            var currentTimeHours = DateTime.Now.Hour;
            var currentTimeWeek = (int)DateTime.Now.DayOfWeek + 1;
            var hours = _context.BranchHours.Where(x => x.Branch.Id == branchId).ToList();
            var daysHours = hours.FirstOrDefault(x => x.DayOfWeek == currentTimeWeek);
            var isOpen = currentTimeHours < daysHours.CloseTime && currentTimeHours > daysHours.OpenTime;
            return isOpen;
        }

        public List<string> GetBranchHours(int branchId)
        {
            var hours = _context.BranchHours.Where(x => x.Branch.Id == branchId).ToList();
            return DataHelperServices.HumanizeBizHours(hours);
        }
    }
}
