using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.BL.Abstract;
using Tasaryeri.BL.Dtos;
using Tasaryeri.Core.Abstract;
using Tasaryeri.DAL.Entities;
using Tasaryeri.DAL.EntityFramework.Abstract;

namespace Tasaryeri.BL.Concreate
{
    public class MemberLoginTransactions : IMemberLoginTransactions
    {
        IEfMemberLoginDAL efMemberLoginDal;
        ICryptoBase cryptoBase;
        public MemberLoginTransactions(IEfMemberLoginDAL efMemberLoginDal, ICryptoBase cryptoBase)
        {
            this.efMemberLoginDal = efMemberLoginDal;
            this.cryptoBase = cryptoBase;
        }
        public MemberLoginDTO Login(MemberLoginDTO MemberLoginDTO)
        {

            //satıcı paneline giriş yaparken md5 formatlama ve giriş için veritabanı kontrolü

            MemberLoginDTO.Password = cryptoBase.getMD5(MemberLoginDTO.Password);
            Member Member = new Member
            {
                Username = MemberLoginDTO.Username,
                Password = MemberLoginDTO.Password,
            };
            var response = efMemberLoginDal.MemberLogin(Member);
            if (response.Id != 0)
            {
                MemberLoginDTO.Id = response.Id;
                MemberLoginDTO.Age = response.Age;
                MemberLoginDTO.Email = response.Email;
                MemberLoginDTO.Gender = response.Gender;
                MemberLoginDTO.Name = response.Name;
                MemberLoginDTO.Password = response.Password;
                MemberLoginDTO.PhoneNumber = response.PhoneNumber;
                MemberLoginDTO.Surname = response.Surname;
                MemberLoginDTO.Username = response.Username;
                return MemberLoginDTO;
            }
            else
            {
                MemberLoginDTO.Id = response.Id;
                return MemberLoginDTO;
            }


        }

        public bool Register(MemberLoginDTO MemberLoginDTO)
        {
            MemberLoginDTO.Password = cryptoBase.getMD5(MemberLoginDTO.Password);
            Member Member = new Member
            {
                Name = MemberLoginDTO.Name,
                Age = MemberLoginDTO.Age,
                Email = MemberLoginDTO.Email,
                Gender = MemberLoginDTO.Gender,
                Password = MemberLoginDTO.Password,
                PhoneNumber = MemberLoginDTO.PhoneNumber,
                Surname = MemberLoginDTO.Surname,
                Username = MemberLoginDTO.Username,
            };


            return efMemberLoginDal.MemberRegister(Member);
        }
    }
}
