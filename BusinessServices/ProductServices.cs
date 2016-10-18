using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using BusinessEntities;
using DataModels;
using DataModels.unitofwork;

namespace BusinessServices
{
    public class ProductServices : IProductServices
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public ProductServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Fetches product details by id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public BusinessEntities.ProductEntity GetProductById(int productId)
        {
            var product = _unitOfWork.ProductRepository.GetByID(productId);
            if (product != null)
            {

                var productModel = Mapper.Map<ProductEntity>(product);
                return productModel;
            }
            return null;
        }

        /// <summary>
        /// Fetches all the products.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BusinessEntities.ProductEntity> GetAllProducts()
        {
            var products = _unitOfWork.ProductRepository.GetAll().ToList();
            if (!products.Any()) return null;
            var productsModel = Mapper.Map<List<ProductEntity>>(products);
            return productsModel;
        }

        /// <summary>
        /// Creates a product
        /// </summary>
        /// <param name="productEntity"></param>
        /// <returns></returns>
        public int CreateProduct(BusinessEntities.ProductEntity productEntity)
        {
            using (var scope = new TransactionScope())
            {
                var product = new Product
                {
                    ProductName = productEntity.ProductName
                };
                _unitOfWork.ProductRepository.Insert(product);
                _unitOfWork.Save();
                scope.Complete();
                return product.ProductId;
            }
        }

        /// <summary>
        /// Updates a product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="productEntity"></param>
        /// <returns></returns>
        public bool UpdateProduct(int productId, BusinessEntities.ProductEntity productEntity)
        {
            if (productEntity == null) return false;
            using (var scope = new TransactionScope())
            {
                var product = _unitOfWork.ProductRepository.GetByID(productId);
                if (product == null) return false;
                product.ProductName = productEntity.ProductName;
                _unitOfWork.ProductRepository.Update(product);
                _unitOfWork.Save();
                scope.Complete();
            }
            return true;
        }

        /// <summary>
        /// Deletes a particular product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public bool DeleteProduct(int productId)
        {
            if (productId <= 0) return false;
            using (var scope = new TransactionScope())
            {
                var product = _unitOfWork.ProductRepository.GetByID(productId);
                if (product == null) return false;
                _unitOfWork.ProductRepository.Delete(product);
                _unitOfWork.Save();
                scope.Complete();
            }
            return true;
        }
    }
}
