﻿using LibraryService.Models;
using LibraryService.Services.Abstraction;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace LibraryService.Services.Implementation
{
    public class LibraryDatabaseContext : ILibraryDatabaseContextService
    {
        private IList<Book> _libraryDatabase;

        public IList<Book> Books => _libraryDatabase;

        public LibraryDatabaseContext()
        {
            Initialize();
        }

        private void Initialize()
        {

            _libraryDatabase = (List<Book>)JsonConvert.DeserializeObject(System.Text.Encoding.UTF8.GetString(Properties.Resources.books),
                typeof(List<Book>));
        }
    }
}