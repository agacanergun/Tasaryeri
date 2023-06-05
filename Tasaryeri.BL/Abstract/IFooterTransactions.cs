﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.BL.Dtos;

namespace Tasaryeri.BL.Abstract
{
    public interface IFooterTransactions
    {
        SocialMediaDTO GetSocialMedia();
        bool AddSocialMedia(SocialMediaDTO socialMediaDTO);
        bool DeleteSocialMedia(SocialMediaDTO socialMediaDTO);
        bool UpdateSocialMedia(SocialMediaDTO socialMediaDTO);

        IEnumerable<ContactDTO> GetContacts();
        bool AddContact(ContactDTO ContactDTO);
        bool DeleteContact(ContactDTO ContactDTO);
        bool UpdateContact(ContactDTO ContactDTO);
    }
}
