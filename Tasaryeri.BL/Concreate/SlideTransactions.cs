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
    public class SlideTransactions : ISlideTransactions
    {
        IEfSlideDAL efSlideDAL;
        public SlideTransactions(IEfSlideDAL efSlideDAL)
        {
            this.efSlideDAL = efSlideDAL;
        }

        public bool Add(SlideDTO slideDTO)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SlideDTO> GetAll()
        {
            IEnumerable<Slide> Slides = efSlideDAL.GetAll();
            List<SlideDTO> slideDTOs = new List<SlideDTO>();

            foreach (var item in Slides)
            {
                SlideDTO slideDTO = new SlideDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Title = item.Title,
                    ShortDescription = item.ShortDescription,
                    LongDescription = item.LongDescription,
                    DisplayIndex = item.DisplayIndex,
                    Picture = item.Picture,
                    Link = item.Link
                };
                slideDTOs.Add(slideDTO);
            }
            return slideDTOs;
        }

        public bool Update(SlideDTO slideDTO)
        {
            throw new NotImplementedException();
        }
    }
}
