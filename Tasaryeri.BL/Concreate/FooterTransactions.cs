using System;
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
            try
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
            catch (Exception)
            {

                throw;
            }
        }

        public bool AddSocialMedia(SocialMediaDTO socialMediaDTO)
        {
            try
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
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteSocialMedia(SocialMediaDTO socialMediaDTO)
        {
            try
            {
                SocialMedia socialMedia = new SocialMedia
                {
                    Id = socialMediaDTO.Id,
                };
                return efFooterDAL.DeleteSocialMedia(socialMedia);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateSocialMedia(SocialMediaDTO socialMediaDTO)
        {
            try
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
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<ContactDTO> GetContacts()
        {
            try
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
            catch (Exception)
            {

                throw;
            }
        }

        public bool AddContact(ContactDTO ContactDTO)
        {
            try
            {
                Contact contact = new Contact
                {
                    ContactInfo = ContactDTO.ContactInfo,
                    ContactType = ContactDTO.ContactType,
                    DisplayIndex = ContactDTO.DisplayIndex,
                };
                return efFooterDAL.AddContact(contact);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteContact(ContactDTO ContactDTO)
        {
            try
            {
                Contact contact = new Contact
                {
                    Id = ContactDTO.Id,
                };
                return efFooterDAL.DeleteContact(contact);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateContact(ContactDTO ContactDTO)
        {
            try
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
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<AboutUsDTO> GetAboutUs()
        {
            try
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
            catch (Exception)
            {

                throw;
            }
        }

        public bool AddAboutUs(AboutUsDTO aboutUsDTO)
        {
            try
            {
                AboutUs aboutUs = new AboutUs
                {
                    Name = aboutUsDTO.Name,
                    DisplayIndex = aboutUsDTO.DisplayIndex,
                    Description = aboutUsDTO.Description,
                };
                return efFooterDAL.AddAboutUs(aboutUs);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteAboutUs(AboutUsDTO aboutUsDTO)
        {
            try
            {
                AboutUs aboutUs = new AboutUs
                {
                    Id = aboutUsDTO.Id,
                };
                return efFooterDAL.DeleteAboutUs(aboutUs);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateAboutUs(AboutUsDTO aboutUsDTO)
        {
            try
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
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<InstitutionalDTO> GetInstitutionals()
        {
            try
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
            catch (Exception)
            {

                throw;
            }
        }

        public bool AddInstitutional(InstitutionalDTO institutionalDTO)
        {
            try
            {
                Institutional institutional = new Institutional
                {
                    Name = institutionalDTO.Name,
                    DisplayIndex = institutionalDTO.DisplayIndex,
                    Description = institutionalDTO.Description,
                };
                return efFooterDAL.AddInstitutional(institutional);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteInstitutional(InstitutionalDTO institutionalDTO)
        {
            try
            {
                Institutional institutional = new Institutional
                {
                    Id = institutionalDTO.Id,
                };
                return efFooterDAL.DeleteInstitutional(institutional);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateInstitutional(InstitutionalDTO institutionalDTO)
        {
            try
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
            catch (Exception)
            {

                throw;
            }
        }
    }
}
