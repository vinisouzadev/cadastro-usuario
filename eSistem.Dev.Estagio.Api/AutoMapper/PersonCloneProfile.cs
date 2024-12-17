using AutoMapper;
using eSistem.Dev.Estagio.Core.Models;

namespace eSistem.Dev.Estagio.Api.AutoMapper
{
    public class PersonCloneProfile : Profile
    {
        public PersonCloneProfile()
        {
            CreateMap<Person, Person>();
        }
    }
}
