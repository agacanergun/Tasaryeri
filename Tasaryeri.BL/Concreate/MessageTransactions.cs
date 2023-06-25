using AutoMapper.Execution;
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
    public class MessageTransactions : IMessageTransactions
    {
        IEfMessageDAL efMessageDAL;
        public MessageTransactions(IEfMessageDAL efMessageDAL)
        {
            this.efMessageDAL = efMessageDAL;
        }

        public MemberDTO GetMember(int id)
        {
            try
            {
                var saler = efMessageDAL.GetMember(id);
                MemberDTO memberDTO = new MemberDTO
                {
                    Id = saler.Id,
                    Name = saler.Name,
                    Surname = saler.Surname,
                };
                return memberDTO;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<MessageDTO> GetMessages(int salerId, int memberId, int productId)
        {
            try
            {
                var response = efMessageDAL.GetMessages(salerId, memberId, productId);
                List<MessageDTO> messages = new List<MessageDTO>();
                foreach (var item in response)
                {
                    MessageDTO messageDTO = new MessageDTO
                    {
                        Content = item.Content,
                        Id = item.Id,
                        MemberId = memberId,
                        ProductId = productId,
                        SalerId = salerId,
                        Sender = item.Sender,
                        Timestamp = item.Timestamp,
                    };
                    messages.Add(messageDTO);
                }
                return messages;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<MessageDTO> GetOldMessagesForMember(int memberId)
        {
            try
            {
                var response = efMessageDAL.GetOldMessagesForMember(memberId);
                List<MessageDTO> messageDTOs = new List<MessageDTO>();
                foreach (var item in response)
                {
                    SalerDTO salerDTO = new SalerDTO
                    {
                        Id = item.Saler.Id,
                        Name = item.Saler.Name,
                        Surname = item.Saler.Surname,
                    };
                    MessageDTO messageDTO = new MessageDTO
                    {
                        Timestamp = item.Timestamp,
                        Content = item.Content,
                        Id = item.Id,
                        MemberId = memberId,
                        Product = item.Product,
                        Sender = item.Sender,
                        ProductId = (int)item.ProductId,
                        SalerId = (int)item.SalerId,
                        SalerDTO = salerDTO,
                    };
                    messageDTOs.Add(messageDTO);
                }
                return messageDTOs;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<MessageDTO> GetOldMessagesForSaler(int salerId)
        {
            try
            {
                var response = efMessageDAL.GetOldMessagesForSaler(salerId);
                List<MessageDTO> messageDTOs = new List<MessageDTO>();
                foreach (var item in response)
                {
                    MemberDTO memberDTO = new MemberDTO
                    {
                        Id = item.Member.Id,
                        Name = item.Member.Name,
                        Surname = item.Member.Surname,
                    };
                    MessageDTO messageDTO = new MessageDTO
                    {
                        Timestamp = item.Timestamp,
                        Content = item.Content,
                        Id = item.Id,
                        MemberId = salerId,
                        Product = item.Product,
                        Sender = item.Sender,
                        ProductId = (int)item.ProductId,
                        SalerId = (int)item.SalerId,
                        MemberDTO = memberDTO,
                    };
                    messageDTOs.Add(messageDTO);
                }
                return messageDTOs;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ProductDTO GetProduct(int id)
        {
            try
            {
                var response = efMessageDAL.GetProduct(id);
                ProductDTO productDTO = new ProductDTO
                {
                    Id = response.Id,
                    Name = response.Name,
                    Price = response.Price,
                    Stock = response.Stock,
                    SalerId = response.SalerId,
                };
                return productDTO;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public SalerDTO GetSaler(int id)
        {
            try
            {
                var saler = efMessageDAL.GetSaler(id);
                SalerDTO salerDTO = new SalerDTO
                {
                    Id = saler.Id,
                    Name = saler.Name,
                    Surname = saler.Surname,
                };
                return salerDTO;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool SendMessage(MessageDTO messageDTO)
        {
            try
            {
                Message message = new Message
                {
                    Content = messageDTO.Content,
                    MemberId = messageDTO.MemberId,
                    ProductId = messageDTO.ProductId,
                    SalerId = messageDTO.SalerId,
                    Timestamp = messageDTO.Timestamp,
                    Sender = messageDTO.Sender,
                };
                return efMessageDAL.SendMessage(message);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
