using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Services.Interfaces
{
    public interface IBranchServices
    {
        List<LibraryBranch> GetAll();
        List<Patron> GetPatrons(int branchId);
        List<LibraryAsset> GetAssets(int branchId);
        List<string> GetBranchHours(int branchId);
        LibraryBranch Get(int branchId);
        void Add(LibraryBranch model);
        bool IsBranchOpen(int branchId);
    }
}
