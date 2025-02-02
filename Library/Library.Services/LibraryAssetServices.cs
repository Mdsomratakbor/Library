﻿using Library.Data.Models;
using Library.Entities;
using Library.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Services
{
    public class LibraryAssetServices : ILibraryServices
    {
        private LibraryContext _context;
        public LibraryAssetServices(LibraryContext context)
        {
            _context = context;
        }
        public void Add(LibraryAsset newAsset)
        {
            _context.Add(newAsset);
            _context.SaveChanges();
        }

        public List<LibraryAsset> GetAll()
        {
            return _context.LibraryAssets
                .Include(asset => asset.Status)
                .Include(asset => asset.Location).ToList();
        }



        public LibraryAsset GetById(int id)
        {
            return GetAll()
                .FirstOrDefault(x => x.Id == id);
        }

        public LibraryBranch GetCurrentLocation(int id)
        {
            return GetById(id).Location;
        }

        public string GetDeweyIndex(int id)
        {
            if (_context.Books.Any(book => book.Id == id))
            {
                return _context.Books
                    .FirstOrDefault(x => x.Id == id).DeweyIndex;
            }
            else return "";

        }

        public string GetIsbn(int id)
        {
            if (_context.Books.Any(book => book.Id == id))
            {
                return _context.Books
                    .FirstOrDefault(x => x.Id == id).Title;
            }
            else return "";
        }

        public string GetTitle(int id)
        {
            if (_context.Books.Any(book => book.Id == id))
            {
                return _context.Books
                    .FirstOrDefault(x => x.Id == id).DeweyIndex;
            }
            else return "";
        }

        public string GetType(int id)
        {
            var book = _context.LibraryAssets.OfType<Book>().Where(b => b.Id == id);
            return book.Any() ? "Book" : "Video";
        }
        public string GetAuthorOrDirectory(int id)
        {
            var isBook = _context.LibraryAssets.OfType<Book>()
                 .Where(x => x.Id == id).Any();

            var isVideo = _context.LibraryAssets.OfType<Video>().Where(x => x.Id == id).Any();
            return isBook ? _context.Books.FirstOrDefault(book => book.Id == id).Author : _context.Videos.FirstOrDefault(vedio => vedio.Id == id).Director ?? "Unknon";
        }
    }
}
