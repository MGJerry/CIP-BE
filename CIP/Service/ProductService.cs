using CIP.DTO;
using CIP.Models;
using CIP.Repository;
using System.Diagnostics.Contracts;

namespace CIP.Service
{
    public class ProductService
    {
        private readonly CustomerRepository _customerRepository;
        private readonly ProductRepository repository;
        public ProductService(
            CustomerRepository customerRepository,
            ProductRepository productRepository)
        {
            _customerRepository = customerRepository;
            repository = productRepository;
        }



        public async Task<List<Product>> GetAllProduct()
        {
            return await repository.GetAllAsync();
        }

        public async Task<Product> GetProductById(int Id)
        {
            return await repository.GetByIdAsync(Id);
        }

        public async Task<Product> UpdateProduct(ProductRequestDTO request)
        {
            Product productExist = await repository.GetByIdAsync(request.Id);

            productExist.Name = request.Name;
            productExist.Price = request.Price;
            await repository.UpdateAsync(productExist);
            return productExist;
        }

        public async Task<Product> CreateProduct(ProductCreateDTO request)
        {
            Product newProduct = new Product
            {
                Name = request.Name,
                Price = request.Price
            };

            await repository.CreateAsync(newProduct);
            return newProduct;
        }

        public async Task<Object?> DeleteProduct(int id)
        {
            Product productExist = await repository.GetByIdAsync(id);
            if (productExist != null)
            {
                repository.RemoveAsync(productExist);
                return "Delete success";
            }
            return "Product not exist";
        }

    }
}
