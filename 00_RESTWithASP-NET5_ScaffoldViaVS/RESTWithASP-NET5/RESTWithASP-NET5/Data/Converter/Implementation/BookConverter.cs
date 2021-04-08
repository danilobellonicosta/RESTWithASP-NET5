using RESTWithASP_NET5.Data.Converter.Contract;
using RESTWithASP_NET5.Data.VO;
using RESTWithASP_NET5.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RESTWithASP_NET5.Data.Converter.Implementation
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public Book Parse(BookVO Origin)
        {
            if (Origin == null)
                return null;

            return new Book
            {
                Id = Origin.Id,
                Author = Origin.Author,
                LaunchDate = Origin.LaunchDate,
                Title = Origin.Title,
                Price = Origin.Price
            };
        }

        public List<Book> Parse(List<BookVO> Origin)
        {
            if (Origin == null)
                return null;

            return Origin.Select(item => Parse(item)).ToList();
        }

        public BookVO Parse(Book Origin)
        {
            if (Origin == null)
                return null;

            return new BookVO
            {
                Id = Origin.Id,
                Author = Origin.Author,
                LaunchDate = Origin.LaunchDate,
                Title = Origin.Title,
                Price = Origin.Price
            };
        }

        public List<BookVO> Parse(List<Book> Origin)
        {
            if(Origin == null)
                return null;

            return Origin.Select(item => Parse(item)).ToList();
        }
    }
}
