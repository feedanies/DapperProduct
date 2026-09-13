using DapperProduct.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperProduct.Domain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product? GetById(int id);
        Product? GetByName(string name);
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
    }
}
