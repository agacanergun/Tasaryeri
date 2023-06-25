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
    public class EfMemberLoginDAL : IEfMemberLoginDAL
    {
        IRepository<Member> repoMember;
        public EfMemberLoginDAL(IRepository<Member> repoMember)
        {
            this.repoMember = repoMember;
        }
        public Member MemberLogin(Member Member)
        {
            try
            {
                var response = repoMember.GetBy(x => x.Username == Member.Username && x.Password == Member.Password);
                if (response == null)
                {
                    Member badResponse = new Member();
                    badResponse.Id = 0;
                    return badResponse;
                }
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool MemberRegister(Member Member)
        {
            try
            {
                var CheckMember = repoMember.GetBy(x => x.Username == Member.Username || x.Email == Member.Email);
                if (CheckMember != null)
                {
                    return false;
                }
                var response = repoMember.Add(Member);
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
