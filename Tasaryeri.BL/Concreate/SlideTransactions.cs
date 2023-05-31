using Azure.Core;
using Microsoft.AspNetCore.Http;
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
            if (slideDTO.PictureFile != null && slideDTO.PictureFile.Length > 0)
            {
                string fileName = DateTime.Now.Minute + DateTime.Now.Millisecond + slideDTO.PictureFile.FileName;
                slideDTO.Picture = "/uploads/imgs/" + fileName;

                Slide slide = new Slide
                {
                    Name = slideDTO.Name,
                    Title = slideDTO.Title,
                    ShortDescription = slideDTO.ShortDescription,
                    LongDescription = slideDTO.LongDescription,
                    Picture = slideDTO.Picture,
                    Link = slideDTO.Link,
                    DisplayIndex = slideDTO.DisplayIndex,
                };

                if (efSlideDAL.Add(slide))
                {
                    using (FileStream stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "imgs", fileName), FileMode.Create))
                    {
                        slideDTO.PictureFile.CopyTo(stream);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
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
