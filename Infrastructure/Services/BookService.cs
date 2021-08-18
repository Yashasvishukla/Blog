using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly IMongoCollection<BsonDocument> _booksCollection;
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;
        private readonly IUnitOfWork _unitOfWork;
        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _client = (IMongoClient)_unitOfWork.GetMongoClient();
            _database = _client.GetDatabase("bookStore");
            _booksCollection = _database.GetCollection<BsonDocument>("BookCollection");
        }

        public async Task<IReadOnlyList<Book>> GetBooks()
        {
            var filter = Builders<BsonDocument>.Filter.Empty;
            var booksDocument = await _unitOfWork.FindAsync(_booksCollection, filter);
            var books = BsonSerializer.Deserialize<IReadOnlyList<Book>>(booksDocument.ToJson());
            return books;
        }

        public async Task<Book> UploadBook(Book book)
        {
            book._id = ObjectId.GenerateNewId();
            book.AddedOn = DateTime.UtcNow;
            var bookDocument = book.ToBsonDocument();
            if (await _unitOfWork.BookExists(_booksCollection, book.Name))
            {
                return null;
            }
            var result = await _unitOfWork.InsertOneAsync(_booksCollection, bookDocument);
            return result == true ? book : null;
        }

    }
}