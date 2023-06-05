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
            throw new NotImplementedException();
        }

        public bool DeleteContact(ContactDTO ContactDTO)
        {
            throw new NotImplementedException();
        }

        public bool UpdateContact(ContactDTO ContactDTO)
        {
            throw new NotImplementedException();
        }
    }
}
