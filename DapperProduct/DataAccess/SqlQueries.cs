using System;
using System.Collections.Generic;
using System.Text;

namespace DapperProduct.DataAccess
{
    public static class SqlQueries
    {
        public const string GetAll = "SELECT * FROM Products";
        public const string GetById = "SELECT * FROM Products WHERE Id=@pId";
        public const string GetByName = "SELECT * FROM Products WHERE Name=@pName";
        public const string Insert = "INSERT INTO Products([Name],[Price],[Quantity],[Description]) VALUES (@pName,@pPrice,@pQuantity,@pDescription)";
        public const string Update = "UPDATE Products SET Name=@pName,Price=@pPrice,Quantity=@pQuantity,Description=@pDescription WHERE Id=@pId";
        public const string Delete = "DELETE From Products WHERE Id=@pId";
    }
}
