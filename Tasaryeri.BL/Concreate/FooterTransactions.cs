﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.BL.Abstract;
using Tasaryeri.BL.Dtos;
using Tasaryeri.DAL.Entities;
using Tasaryeri.DAL.EntityFramework.Abstract;

namespace Tasaryeri.BL.Concreate
{
    public class FooterTransactions : IFooterTransactions
    {
        IEfFooterDAL efFooterDAL;
        public FooterTransactions(IEfFooterDAL efFooterDAL)
        {
            this.efFooterDAL = efFooterDAL;
        }

        public SocialMediaDTO GetSocialMedia()
        {
            var response = efFooterDAL.GetSocialMedia();

            if (response == null)
                return null;

            SocialMediaDTO socialMedia = new SocialMediaDTO
            {
                Id = response.Id,
                FacebookLink = response.FacebookLink,
                InstagramLink = response.InstagramLink,
                TwitterLink = response.TwitterLink,
                YoutubeLink = response.YoutubeLink,
            };
            return socialMedia;
        }

        public bool AddSocialMedia(SocialMediaDTO socialMediaDTO)
        {
            SocialMedia socialMedia = new SocialMedia
            {
                FacebookLink = socialMediaDTO.FacebookLink,
                InstagramLink = socialMediaDTO.InstagramLink,
                TwitterLink = socialMediaDTO.TwitterLink,
                YoutubeLink = socialMediaDTO.YoutubeLink,
            };
            return efFooterDAL.AddSocialMedia(socialMedia);
        }

        public bool DeleteSocialMedia(SocialMediaDTO socialMediaDTO)
        {
            SocialMedia socialMedia = new SocialMedia
            {
                Id = socialMediaDTO.Id,
            };
            return efFooterDAL.DeleteSocialMedia(socialMedia);
        }

        public bool UpdateSocialMedia(SocialMediaDTO socialMediaDTO)
        {
            SocialMedia socialMedia = new SocialMedia
            {
                Id = socialMediaDTO.Id,
                FacebookLink = socialMediaDTO.FacebookLink,
                InstagramLink = socialMediaDTO.InstagramLink,
                TwitterLink = socialMediaDTO.TwitterLink,
                YoutubeLink = socialMediaDTO.YoutubeLink,
            };
            return efFooterDAL.UpdateSocialMedia(socialMedia);
        }

        public IEnumerable<ContactDTO> GetContacts()
        {
            var response = efFooterDAL.GetContacts();
            List<ContactDTO> ContactDTOs = new List<ContactDTO>();

            foreach (var item in response)
            {
                ContactDTO contactDTO = new ContactDTO
                {
                    Id = item.Id,
                    ContactInfo = item.ContactInfo,
                    ContactType = item.ContactType,
                    DisplayIndex = item.DisplayIndex
                };
                ContactDTOs.Add(contactDTO);
            }
            return ContactDTOs;
        }

        public bool AddContact(ContactDTO ContactDTO)
        {
            Contact contact = new Contact
            {
                ContactInfo = ContactDTO.ContactInfo,
                ContactType = ContactDTO.ContactType,
                DisplayIndex = ContactDTO.DisplayIndex,
            };
            return efFooterDAL.AddContact(contact);
        }

        public bool DeleteContact(ContactDTO ContactDTO)
        {
            Contact contact = new Contact
            {
                Id = ContactDTO.Id,
            };
            return efFooterDAL.DeleteContact(contact);
        }

        public bool UpdateContact(ContactDTO ContactDTO)
        {
            Contact contact = new Contact
            {
                Id = ContactDTO.Id,
                ContactInfo = ContactDTO.ContactInfo,
                ContactType = ContactDTO.ContactType,
                DisplayIndex = ContactDTO.DisplayIndex,
            };
            return efFooterDAL.UpdateContact(contact);
        }

        public IEnumerable<AboutUsDTO> GetAboutUs()
        {
            var response = efFooterDAL.GetAboutUs();
            List<AboutUsDTO> aboutUsDTOs = new List<AboutUsDTO>();

            foreach (var item in response)
            {
                AboutUsDTO aboutUsDTO = new AboutUsDTO
                {
                    Id = item.Id,
                    Description = item.Description,
                    DisplayIndex = item.DisplayIndex,
                    Name = item.Name,
                };
                aboutUsDTOs.Add(aboutUsDTO);
            }
            return aboutUsDTOs;
        }

        public bool AddAboutUs(AboutUsDTO aboutUsDTO)
        {
            AboutUs aboutUs = new AboutUs
            {
                Name = aboutUsDTO.Name,
                DisplayIndex = aboutUsDTO.DisplayIndex,
                Description = aboutUsDTO.Description,
            };
            return efFooterDAL.AddAboutUs(aboutUs);
        }

        public bool DeleteAboutUs(AboutUsDTO aboutUsDTO)
        {
            AboutUs aboutUs = new AboutUs
            {
                Id = aboutUsDTO.Id,
            };
            return efFooterDAL.DeleteAboutUs(aboutUs);
        }

        public bool UpdateAboutUs(AboutUsDTO aboutUsDTO)
        {
            AboutUs aboutUs = new AboutUs
            {
                Id = aboutUsDTO.Id,
                Name = aboutUsDTO.Name,
                Description = aboutUsDTO.Description,
                DisplayIndex = aboutUsDTO.DisplayIndex,
            };
            return efFooterDAL.UpdateAboutUs(aboutUs);
        }

        public IEnumerable<InstitutionalDTO> GetInstitutionals()
        {
            var response = efFooterDAL.GetInstitutionals();
            List<InstitutionalDTO> InstitutionalDTOs = new List<InstitutionalDTO>();

            foreach (var item in response)
            {
                InstitutionalDTO InstitutionalDTO = new InstitutionalDTO
                {
                    Id = item.Id,
                    Description = item.Description,
                    DisplayIndex = item.DisplayIndex,
                    Name = item.Name,
                };
                InstitutionalDTOs.Add(InstitutionalDTO);
            }
            return InstitutionalDTOs;
        }

        public bool AddInstitutional(InstitutionalDTO institutionalDTO)
        {
            Institutional institutional = new Institutional
            {
                Name = institutionalDTO.Name,
                DisplayIndex = institutionalDTO.DisplayIndex,
                Description = institutionalDTO.Description,
            };
            return efFooterDAL.AddInstitutional(institutional);
        }

        public bool DeleteInstitutional(InstitutionalDTO institutionalDTO)
        {
            Institutional institutional = new Institutional
            {
                Id = institutionalDTO.Id,
            };
            return efFooterDAL.DeleteInstitutional(institutional);
        }

        public bool UpdateInstitutional(InstitutionalDTO institutionalDTO)
        {
            Institutional institutional = new Institutional
            {
                Id = institutionalDTO.Id,
                Name = institutionalDTO.Name,
                Description = institutionalDTO.Description,
                DisplayIndex = institutionalDTO.DisplayIndex,
            };
            return efFooterDAL.UpdateInstitutional(institutional);
        }
    }
}
