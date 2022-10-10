using Business.Abstract;
using Business.Constants;
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
            if (product.ProductName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productdal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
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
