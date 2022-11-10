using LibraryService.Models;
using System.Collections.Generic;

namespace LibraryService.Services.Abstraction
{
    public interface ILibraryDatabaseContextService
    {
        IList<Book> Books { get; }
    }
}