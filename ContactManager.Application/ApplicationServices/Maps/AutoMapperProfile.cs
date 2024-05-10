using AutoMapper;
using ContactManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Application.ApplicationServices.Maps
{
    /// <summary>
    /// A custom AutoMapper profile for mapping between Contact and ContactDto.
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoMapperProfile"/> class.
        /// </summary>
        public AutoMapperProfile()
        {
            MapForContact();
        }

        /// <summary>
        /// Configures mappings for the Contact and ContactDto classes.
        /// </summary>
        public void MapForContact()
        {
            // Map ContactDto to Contact
            CreateMap<ContactDto, Contact>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            // Map Contact to ContactDto
            CreateMap<Contact, ContactDto>()
                .ForMember(dst => dst.OwnerId, src => src.MapFrom(a => a.Owner.Id.ToString()));
        }
    }
}