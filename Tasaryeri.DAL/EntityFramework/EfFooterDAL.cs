using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.Core.Interfaces;
using Tasaryeri.DAL.Entities;
using Tasaryeri.DAL.EntityFramework.Abstract;

namespace Tasaryeri.DAL.EntityFramework
{
    public class EfFooterDAL : IEfFooterDAL
    {
        IRepository<SocialMedia> repoSocialMedia;
        IRepository<AboutUs> repoAboutUs;
        IRepository<Institutional> repoInstitutional;
        IRepository<Contact> repoContact;
        public EfFooterDAL(IRepository<SocialMedia> repoSocialMedia, IRepository<AboutUs> repoAboutUs, IRepository<Institutional> repoInstitutional, IRepository<Contact> repoContact)
        {

            this.repoSocialMedia = repoSocialMedia;
            this.repoAboutUs = repoAboutUs;
            this.repoInstitutional = repoInstitutional;
            this.repoContact = repoContact;
        }

        public SocialMedia GetSocialMedia()
        {
            try
            {
                return repoSocialMedia.GetAll().FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AddSocialMedia(SocialMedia socialMedia)
        {
            try
            {
                var respone = repoSocialMedia.Add(socialMedia);
                if (respone == 1)
                    return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteSocialMedia(SocialMedia socialMedia)
        {
            try
            {
                var response = repoSocialMedia.Delete(socialMedia);
                if (response == 1)
                    return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateSocialMedia(SocialMedia socialMedia)
        {
            try
            {
                var response = repoSocialMedia.Update(socialMedia);
                if (response == 1)
                    return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Contact> GetContacts()
        {
            try
            {
                return repoContact.GetAll().OrderBy(x => x.DisplayIndex);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool AddContact(Contact contact)
        {
            try
            {
                var response = repoContact.Add(contact);
                if (response == 1)
                    return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteContact(Contact contact)
        {
            try
            {
                var response = repoContact.Delete(contact);
                if (response == 1)
                    return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateContact(Contact contact)
        {
            try
            {
                var response = repoContact.Update(contact);
                if (response == 1)
                    return true;
                return false;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<AboutUs> GetAboutUs()
        {
            try
            {
                return repoAboutUs.GetAll().OrderBy(x => x.DisplayIndex);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AddAboutUs(AboutUs aboutUs)
        {
            try
            {
                var response = repoAboutUs.Add(aboutUs);
                if (response == 1)
                    return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteAboutUs(AboutUs aboutUs)
        {
            try
            {
                var response = repoAboutUs.Delete(aboutUs);
                if (response == 1)
                    return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateAboutUs(AboutUs aboutUs)
        {
            try
            {
                var response = repoAboutUs.Update(aboutUs);
                if (response == 1)
                    return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Institutional> GetInstitutionals()
        {
            try
            {
                return repoInstitutional.GetAll().OrderBy(x => x.DisplayIndex);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AddInstitutional(Institutional institutional)
        {
            try
            {
                var response = repoInstitutional.Add(institutional);
                if (response == 1)
                    return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteInstitutional(Institutional institutional)
        {
            try
            {
                var response = repoInstitutional.Delete(institutional);
                if (response == 1)
                    return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateInstitutional(Institutional institutional)
        {
            try
            {
                var response = repoInstitutional.Update(institutional);
                if (response == 1)
                    return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
