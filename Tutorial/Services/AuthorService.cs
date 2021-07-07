using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial.Data;
using Tutorial.ViewModel;
using Tutorial.ViewModel.Author;

namespace Tutorial.Services
{
    public class AuthorService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AuthorService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<AuthorViewModel>> GetAuthors() {
            return await _context.Author
                .ProjectTo<AuthorViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<AuthorViewModel> GetAuthor(int id)
        {
            return await _context.Author.Where(x=>x.Id == id)
                .ProjectTo<AuthorViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<List<BookViewModel>> GetBooks(int id)
        {
            return await _context.Book.Where(x => x.AuthorId == id)
                .ProjectTo<BookViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
