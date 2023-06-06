﻿using System;
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
    public class SalerLoginTransactions : ISalerLoginTransactions
    {
        IEfSalerLoginDAL efSalerLoginDal;
        ICryptoBase cryptoBase;
        public SalerLoginTransactions(IEfSalerLoginDAL efSalerLoginDal, ICryptoBase cryptoBase)
        {
            this.efSalerLoginDal = efSalerLoginDal;
            this.cryptoBase = cryptoBase;
        }
        public SalerLoginDTO Login(SalerLoginDTO salerLoginDTO)
        {

            //satıcı paneline giriş yaparken md5 formatlama ve giriş için veritabanı kontrolü

            salerLoginDTO.Password = cryptoBase.getMD5(salerLoginDTO.Password);
            Saler saler = new Saler
            {
                Username = salerLoginDTO.Username,
                Password = salerLoginDTO.Password,
            };
            var response = efSalerLoginDal.AdminLogin(saler);
            if (response.Id != 0)
            {
                salerLoginDTO.Id = response.Id;
                salerLoginDTO.Age = response.Age;
                salerLoginDTO.Email = response.Email;
                salerLoginDTO.Gender = response.Gender;
                salerLoginDTO.Name = response.Name;
                salerLoginDTO.Password = response.Password;
                salerLoginDTO.PhoneNumber = response.PhoneNumber;
                salerLoginDTO.Surname = response.Surname;
                salerLoginDTO.Username = response.Username;
                return salerLoginDTO;
            }
            else
            {
                salerLoginDTO.Id = response.Id;
                return salerLoginDTO;
            }


        }
    }
}
