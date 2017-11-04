﻿using System.ComponentModel.DataAnnotations;
using MimeKit;

namespace Automail.Api.Extensions
{
    public static class InternetAddressListExtensions
    {
        public static void AddAdresses(this InternetAddressList internetAddressList, string addresses)
        {
            var emailChecker = new EmailAddressAttribute();
            foreach (string adress in addresses.Split(';'))
            {
                if (!emailChecker.IsValid(adress))
                {
                    continue;
                }
                internetAddressList.Add(new MailboxAddress("", adress));
            }
        }
    }
}