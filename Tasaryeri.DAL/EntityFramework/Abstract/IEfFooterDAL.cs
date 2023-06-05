using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.DAL.Entities;

namespace Tasaryeri.DAL.EntityFramework.Abstract
{
    public interface IEfFooterDAL
    {
        SocialMedia GetSocialMedia();
        bool AddSocialMedia(SocialMedia socialMedia);
        bool DeleteSocialMedia(SocialMedia socialMedia);
        bool UpdateSocialMedia(SocialMedia socialMedia);

        IEnumerable<Contact> GetContacts();
        bool AddContact(Contact contact);
        bool DeleteContact(Contact contact);
        bool UpdateContact(Contact contact);

        IEnumerable<AboutUs> GetAboutUs();
        bool AddAboutUs(AboutUs aboutUs);
        bool DeleteAboutUs(AboutUs aboutUs);
        bool UpdateAboutUs(AboutUs aboutUs);

        IEnumerable<Institutional> GetInstitutionals();
        bool AddInstitutional(Institutional institutional);
        bool DeleteInstitutional(Institutional institutional);
        bool UpdateInstitutional(Institutional institutional);
    }
}
