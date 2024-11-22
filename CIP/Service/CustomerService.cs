using Azure.Core;
using CIP.DTO;
using CIP.Models;
using CIP.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CIP.Service
{
    public class CustomerService
    {
        private CustomerRepository repository;

        public CustomerService(CustomerRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<Customer>> GetAllCustomer()
        {
            return await repository.GetAllAsync();
        }

        public async Task<Customer> GetCustomerById(int Id)
        {
            return await repository.GetByIdAsync(Id);
        }

        public async Task<Customer> UpdateCustomer(CustomerRequestDTO request)
        {
            Customer customerExist =await repository.GetByIdAsync(request.Id);

            customerExist.FirstName = request.FirstName;
            customerExist.LastName = request.LastName;
            customerExist.DateOfBirth = request.DateOfBirth;
            customerExist.Gender = request.Gender;
            customerExist.Email = request.Email;
            customerExist.PhoneNumber = request.PhoneNumber;
            customerExist.Address = request.Address;
            await repository.UpdateAsync(customerExist);
            return customerExist;
        }

        public async Task<Customer> CreateCustomer(CustomerCreateDTO request)
        {
            Customer newCustomer = new Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address
            };

            await repository.CreateAsync(newCustomer);
            return newCustomer;
        }

        public async Task<Object?> DeleteCustomer(int id)
        {
            Customer customerExist = await repository.GetByIdAsync(id);
            if(customerExist != null)
            {
                repository.RemoveAsync(customerExist);
                return "Delete success";
            }
            return "Cusotmer not exist";
        }
    }
}
