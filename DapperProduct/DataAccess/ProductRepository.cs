using Dapper;
using DapperProduct.Domain.Abstract;
using DapperProduct.Domain.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperProduct.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Product product)
        {
            using var connection = new SqlConnection(_connectionString);
            var rowAffected = connection.Execute(SqlQueries.Insert, new
            {
                pName = product.Name,
                pPrice = product.Price,
                pQuantity = product.Quantity,
                pDescription = product.Description
            });
            if (rowAffected > 0)
            {
                Console.WriteLine("Successfully added...");
            }
        }

        public void Delete(Product product)
        {
            using var connection = new SqlConnection(_connectionString);
            var rowAffected = connection.Execute(SqlQueries.Delete, new { pId = product.Id });
            if (rowAffected > 0)
            {
                Console.WriteLine("Successfully deleted...");
            }
        }

        public IEnumerable<Product> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<Product>(SqlQueries.GetAll);
        }

        public Product? GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<Product>(SqlQueries.GetById, new { pId = id });
        }

        public Product? GetByName(string name)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<Product>(SqlQueries.GetByName, new { pName = name });
        }

        public void Update(Product product)
        {
            using var connection = new SqlConnection(_connectionString);
            var rowAffected = connection.Execute(SqlQueries.Update, new
            {
                pId = product.Id,
                pName = product.Name,
                pPrice = product.Price,
                pQuantity = product.Quantity,
                pDescription = product.Description
            });
            if (rowAffected > 0)
            {
                Console.WriteLine("Successfully updated...");
            }
        }
    }
}
