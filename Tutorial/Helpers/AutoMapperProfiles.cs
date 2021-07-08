using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial.Entities;
using Tutorial.ViewModel;
using Tutorial.ViewModel.Author;

namespace Tutorial.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() {

            //Map to get author information and books
            CreateMap<Author, AuthorViewModel>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.AuthorInfo.Email))
                .ForMember(dest => dest.Academic, opt => opt.MapFrom(src => src.AuthorInfo.Academic))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.AuthorInfo.Address))
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.AuthorInfo.PhotoUrl))
                .ForMember(dest => dest.Since, opt => opt.MapFrom(src => src.AuthorInfo.Since))
                .ForMember(dest => dest.TotalBook, opt => opt.MapFrom(src => src.Books.Count()))
                .ForMember(dest => dest.BookViewModel, opt => opt.MapFrom(src => src.Books));

            //Map CreateUpateViewModel to Author
            CreateMap<Author, CreateUpdateViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AuthorInfo.Id))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.AuthorInfo.Email))
                .ForMember(dest => dest.Academic, opt => opt.MapFrom(src => src.AuthorInfo.Academic))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.AuthorInfo.Address))
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.AuthorInfo.PhotoUrl))
                .ForMember(dest => dest.Since, opt => opt.MapFrom(src => src.AuthorInfo.Since)).ReverseMap();


            //Map to get book categories
            CreateMap<Book,BookViewModel>()
                 .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Categories.Select(x => x.Category.CategoryName)));

            //Map to get category name based on view model
            CreateMap<Category, CategoryViewModel>();
        }
    }
}

// Name of properties between entities and viewmodel should same for making mapping easier.
// If not same, should use individual map such as using formember
// Formember => bila dalam class ade child class
//           => Contoh, class Author dalam dia ade class AuthorInfo(as a object)
//           => Utk map antara satu sama lain kena gune formember, kalau tak akan return null
//Reversemap => bile kita nak map antara viewmodel dgn model
 //          => terutama bile kita nk update data