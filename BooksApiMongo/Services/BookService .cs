using BooksApiMongo.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApiMongo.Services
{
    public class BookService
    {
        private readonly IMongoCollection<Book> _books;
        private readonly IMongoCollection<Author> _authors;

        public BookService(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<Book>(settings.BooksCollectionName);
            _authors = database.GetCollection<Author>(settings.AuthorsCollectionName);
        }

        //public List<Book> Get() => _books.Find(book => true).ToList();
        public async Task<List<Book>> Get() => await _books.Find(book => true).ToListAsync();


        //public Book Get(string id) => _books.Find<Book>(book => book.Id == id).FirstOrDefault();

        public async Task<Book> GetBook(string id)
        {
            return await _books.Find(book => book.Id == id).FirstOrDefaultAsync();
        }
        

        public async Task<Book> Create(Book book)
        {
            await _books.InsertOneAsync(book);
            return book;
        }

        public void Update(string id, Book bookIn) => _books.ReplaceOne(book => book.Id == id, bookIn);

        public void Remove(Book bookIn) => _books.DeleteOne(book => book.Id == bookIn.Id);

        public void Remove(string id) => _books.DeleteOne(book => book.Id == id);


        //Authors
        public async Task<List<Author>> GetAuthors()
        {
            return await _authors.Find(author => true).ToListAsync();
        }

        public async Task<Author> GetAuthor(string id)
        {
            return await _authors.Find(author => author.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Author> CreateAuthor(Author author)
        {
            await _authors.InsertOneAsync(author);
            return author;
        }
    }
}
