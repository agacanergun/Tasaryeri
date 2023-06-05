﻿using Azure;
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
            return repoSocialMedia.GetAll().FirstOrDefault();
        }

        public bool AddSocialMedia(SocialMedia socialMedia)
        {
            var respone = repoSocialMedia.Add(socialMedia);
            if (respone == 1)
                return true;
            return false;
        }

        public bool DeleteSocialMedia(SocialMedia socialMedia)
        {
            var response = repoSocialMedia.Delete(socialMedia);
            if (response == 1)
                return true;
            return false;
        }

        public bool UpdateSocialMedia(SocialMedia socialMedia)
        {
            var response = repoSocialMedia.Update(socialMedia);
            if (response == 1)
                return true;
            return false;
        }

        public IEnumerable<Contact> GetContacts()
        {
            return repoContact.GetAll().OrderBy(x => x.DisplayIndex);

        }

        public bool AddContact(Contact contact)
        {
            var response = repoContact.Add(contact);
            if (response == 1)
                return true;
            return false;
        }

        public bool DeleteContact(Contact contact)
        {
            var response = repoContact.Delete(contact);
            if (response == 1)
                return true;
            return false;
        }

        public bool UpdateContact(Contact contact)
        {
            var response = repoContact.Update(contact);
            if (response == 1)
                return true;
            return false;
        }
    }
}
