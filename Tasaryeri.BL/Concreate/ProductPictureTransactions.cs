using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.BL.Abstract;
using Tasaryeri.BL.Dtos;
using Tasaryeri.DAL.Entities;
using Tasaryeri.DAL.EntityFramework;
using Tasaryeri.DAL.EntityFramework.Abstract;

namespace Tasaryeri.BL.Concreate
{
    public class ProductPictureTransactions : IProductPictureTransactions
    {
        IEfProductPictureDAL efProductPictureDAL;
        IWebHostEnvironment hostingEnvironment;
        public ProductPictureTransactions(IEfProductPictureDAL efProductPictureDAL, IWebHostEnvironment hostingEnvironment)
        {
            this.efProductPictureDAL = efProductPictureDAL;
            this.hostingEnvironment = hostingEnvironment;
        }
        public bool Add(ProductPictureDTO productPictureDTO)
        {
            try
            {
                if (productPictureDTO.PictureFile != null && productPictureDTO.PictureFile.Length > 0)
                {
                    string fileName = DateTime.Now.Minute + DateTime.Now.Millisecond + productPictureDTO.PictureFile.FileName;
                    productPictureDTO.Picture = "uploads/imgs/" + fileName;

                    ProductPicture productPicture = new ProductPicture
                    {
                        DisplayIndex = productPictureDTO.DisplayIndex,
                        ProductID = productPictureDTO.ProductID,
                        Picture = productPictureDTO.Picture,
                        Name = productPictureDTO.Name,
                    };

                    if (efProductPictureDAL.Add(productPicture))
                    {
                        using (FileStream stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "imgs", fileName), FileMode.Create))
                        {
                            productPictureDTO.PictureFile.CopyTo(stream);
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
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var response = efProductPictureDAL.GetById(id);
                string deleteFotoPath = response.Picture;
                if (efProductPictureDAL.Delete(response))
                {

                    string deleteFilePath = Path.Combine(hostingEnvironment.WebRootPath, response.Picture);

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
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<ProductPictureDTO> GetAll(int id)
        {
            try
            {
                var response = efProductPictureDAL.GetAll(id);
                List<ProductPictureDTO> productDTOs = new List<ProductPictureDTO>();
                foreach (var item in response)
                {
                    ProductPictureDTO productPictureDTO = new ProductPictureDTO
                    {
                        Id = item.Id,
                        DisplayIndex = item.DisplayIndex,
                        Name = item.Name,
                        Picture = item.Picture,
                        ProductID = item.ProductID,
                        Product = item.Product,
                    };
                    productDTOs.Add(productPictureDTO);
                }

                return productDTOs;
            }
            catch (Exception) { throw; }
        }

        public ProductPictureDTO GetById(int id)
        {
            try
            {
                var response = efProductPictureDAL.GetById(id);
                ProductPictureDTO productPictureDTO = new ProductPictureDTO
                {
                    Id = response.Id,
                    DisplayIndex = response.DisplayIndex,
                    Name = response.Name,
                    Picture = response.Picture,
                    Product = response.Product,
                    ProductID = response.ProductID,
                };
                return productPictureDTO;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(ProductPictureDTO productPictureDTO)
        {
            try
            {
                ProductPicture productPicture = new ProductPicture
                {
                    ProductID = productPictureDTO.ProductID,
                    Id = productPictureDTO.Id,
                    DisplayIndex = productPictureDTO.DisplayIndex,
                    Name = productPictureDTO.Name,
                    Picture = productPictureDTO.Picture,
                };
                return efProductPictureDAL.Update(productPicture);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
