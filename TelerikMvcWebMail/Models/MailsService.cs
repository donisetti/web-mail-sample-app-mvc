﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TelerikMvcWebMail.Models
{
    public class MailsService
    {
        private WebMailEntities1 entities;

        public MailsService(WebMailEntities1 entities)
        {
            this.entities = entities;
        }

        public IEnumerable<MailViewModel> Read()
        {
            var result = entities.Messages.Select(message => new MailViewModel
            {
                ID = message.MessageID,
                IsRead = message.IsRead,
                From = message.From,
                To = message.To,
                Subject = message.Subject,
                Date = message.Received,
                Text = message.Body,
                Folder = message.Folder
            });

            return result;
        }

        public void Create(MailViewModel mail)
        {
            var entity = new Message();

            entity.Body = mail.Text;
            entity.From = mail.From;
            entity.Subject = mail.Subject;
            entity.Received = mail.Date;
            entity.IsRead = mail.IsRead;
            entity.To = mail.To;
            entity.Folder = mail.Folder;
            entity.MessageID = mail.ID;

            entities.Messages.Add(entity);
            entities.SaveChanges();

            mail.ID = entity.MessageID;
        }

        public void Update(MailViewModel mail)
        {
            var entity = mail.ToEntity();
            entities.Messages.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }
    }
}