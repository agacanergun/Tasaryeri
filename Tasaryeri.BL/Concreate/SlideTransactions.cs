using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Tasaryeri.BL.Abstract;
using Tasaryeri.BL.Dtos;
using Tasaryeri.DAL.Entities;
using Tasaryeri.DAL.EntityFramework.Abstract;

namespace Tasaryeri.BL.Concreate
{
    public class SlideTransactions : ISlideTransactions
    {
        IEfSlideDAL efSlideDAL;
        IWebHostEnvironment hostingEnvironment;
        public SlideTransactions(IEfSlideDAL efSlideDAL, IWebHostEnvironment hostingEnvironment)
        {
            this.efSlideDAL = efSlideDAL;
            this.hostingEnvironment = hostingEnvironment;
        }

        //veritabanına veriyi ekler ve sonra fotoğrafı projeye ekler
        public bool Add(SlideDTO slideDTO)
        {
            if (slideDTO.PictureFile != null && slideDTO.PictureFile.Length > 0)
            {
                string fileName = DateTime.Now.Minute + DateTime.Now.Millisecond + slideDTO.PictureFile.FileName;
                slideDTO.Picture = "uploads/imgs/" + fileName;

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

        //veritabanından veriyi siler daha sonra fotoğrafı siler
        public bool Delete(SlideDTO slideDTO)
        {
            Slide slide = new Slide
            {
                Id = slideDTO.Id,
            };
            if (efSlideDAL.Delete(slide))
            {
                string deleteFilePath = Path.Combine(hostingEnvironment.WebRootPath, slideDTO.Picture);

                if (File.Exists(deleteFilePath))
                {
                    File.Delete(deleteFilePath);
                    return true;
                }
                else
                    return false;
            }
            return false;
        }

        //tüm verileri çeker
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

        //veritabanından verileri günceller ve daha sonra fotoğrafı projeden siler yeni fotoğrafı ekler.
        public bool Update(SlideDTO slideDTO)
        {
            if (slideDTO.PictureFile != null)
            {
                string deleteFilePath1 = slideDTO.Picture;
                string fileName = DateTime.Now.Minute + DateTime.Now.Millisecond + slideDTO.PictureFile.FileName;
                Slide slide = new Slide
                {
                    Id = slideDTO.Id,
                    DisplayIndex = slideDTO.DisplayIndex,
                    Link = slideDTO.Link,
                    LongDescription = slideDTO.LongDescription,
                    Name = slideDTO.Name,
                    Picture = "uploads/imgs/" + fileName,
                    ShortDescription = slideDTO.ShortDescription,
                    Title = slideDTO.Title,
                };
                if (efSlideDAL.Update(slide))
                {
                    string deleteFilePath = Path.Combine(hostingEnvironment.WebRootPath, deleteFilePath1);

                    //eski görseli sil
                    if (File.Exists(deleteFilePath))
                    {
                        File.Delete(deleteFilePath);
                    }

                    //yeni görseli ekle

                    using (FileStream stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "imgs", fileName), FileMode.Create))
                    {
                        slideDTO.PictureFile.CopyTo(stream);
                    }
                    return true;
                }
                return false;
            }
            else
            {
                Slide slide = new Slide
                {
                    Id = slideDTO.Id,
                    DisplayIndex = slideDTO.DisplayIndex,
                    Link = slideDTO.Link,
                    LongDescription = slideDTO.LongDescription,
                    Name = slideDTO.Name,
                    ShortDescription = slideDTO.ShortDescription,
                    Title = slideDTO.Title,
                    Picture=slideDTO.Picture,
                };
                if (efSlideDAL.Update(slide))
                    return true;
                return false;
            }
        }
    }
}
