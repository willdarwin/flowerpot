using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTA.BLL;
using TTA.Model;
using TTA.IService;

namespace TTA.Service
{
    public partial class TTAService : ITTAService
    {
        /// <summary>
        /// Gets the product by id.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public GetProductByIdResponse GetProductById(GetProductByIdRequest request)
        {
            GetProductByIdResponse response = new GetProductByIdResponse();
            ProductService service = new ProductService();

            try
            {
                response.Product = service.GetById(request.Id);
                if (response.Product == null)
                {
                    response.IsFailed = true;
                    response.Message = "We do not have Product";
                }
            }
            catch (Exception ex)
            {
                response.IsFailed = true;
                response.Message = ex.Message;
            }

            return response;
        }
        /// <summary>
        /// Inserts the product.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public InsertProductResponse InsertProduct(InsertProductRequest request)
        {
            InsertProductResponse response = new InsertProductResponse();
            ProductService service = new ProductService();

            try
            {
                bool result = service.Insert(request.Product);
                if (result == false)
                {
                    response.IsFailed = true; response.Message = "Insert Product failed.";
                }
            }
            catch (Exception ex)
            {
                response.IsFailed = true;
                response.Message = ex.Message;
            }

            return response;
        }
        /// <summary>
        /// Updates the product.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public UpdateProductResponse UpdateProduct(UpdateProductRequest request)
        {
            UpdateProductResponse response = new UpdateProductResponse();
            ProductService service = new ProductService();

            try
            {
                bool result = service.Update(request.product);
                if (result == false)
                {
                    response.IsFailed = true; response.Message = "Update Product failed.";
                }
            }
            catch (Exception ex)
            {
                response.IsFailed = true;
                response.Message = ex.Message;
            }

            return response;
        }
        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public DeleteProductResponse DeleteProduct(DeleteProductRequst request)
        {
            DeleteProductResponse response = new DeleteProductResponse();
            ProductService service = new ProductService();

            try
            {
                bool result = service.Delete(request.ProductId);
                if (result == false)
                {
                    response.IsFailed = true; response.Message = "Delete Product failed.";
                }
            }
            catch (Exception ex)
            {
                response.IsFailed = true;
                response.Message = ex.Message;
            }

            return response;
        }
        /// <summary>
        /// Selects all product.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public SelectAllProductResponse SelectAllProduct(SelectAllProductRequest request)
        {
            SelectAllProductResponse response = new SelectAllProductResponse();
            ProductService service = new ProductService();

            try
            {
                response.ProductList = service.SelectAll();
                if (response.ProductList == null)
                {
                    response.IsFailed = true; response.Message = "We don not have Product";
                }
            }
            catch (Exception ex)
            {
                response.IsFailed = true;
                response.Message = ex.Message;
            }

            return response;
        }
        /// <summary>
        /// Selects all category.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public SelectAllCategoryResponse SelectAllCategory(SelectAllCategoryRequest request)
        {
            SelectAllCategoryResponse response = new SelectAllCategoryResponse();
            ProductService service = new ProductService();

            try
            {
                response.CategoryList = service.SelectAllCategory();
                if (response.CategoryList == null)
                {
                    response.IsFailed = true; response.Message = "We don not have Category";
                }
            }
            catch (Exception ex)
            {
                response.IsFailed = true;
                response.Message = ex.Message;
            }

            return response;
        }
        /// <summary>
        /// Gets the order details by product id.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public CountOrderDetailsByProductIdResponse CountOrderDetailsByProductId(CountOrderDetailsByProductIdRequest request)
        {
            CountOrderDetailsByProductIdResponse response = new CountOrderDetailsByProductIdResponse();
            ProductService service = new ProductService();

            try
            {
                response.count = service.CountOrderDetailsByProductId(request.Id);
            }
            catch (Exception ex)
            {
                response.IsFailed = true;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
