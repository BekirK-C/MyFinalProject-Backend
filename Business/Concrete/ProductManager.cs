using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productdal;

        public ProductManager(IProductDal productdal)
        {
            _productdal = productdal;
        }

        public IResult Add(Product product)
        {
            _productdal.Add(product);
            return new Result(true,"Ürün Eklendi.");
        }

        public List<Product> GetAll()
        {
            return _productdal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productdal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetAllByUnitPrice(decimal min, decimal max)
        {
            return _productdal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public Product GetByProductId(int productId)
        {
            return _productdal.Get(p => p.ProductId == productId);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productdal.GetProductDetails();
        }
    }
}
