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
        bool AddSocialMedia(Contact contact);
        bool DeleteSocialMedia(Contact contact);

        bool UpdateSocialMedia(Contact contact);
    }
}
