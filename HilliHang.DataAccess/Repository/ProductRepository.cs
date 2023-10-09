using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


        public void Update(Product obj)
        {
            var objFromDb = _dbContext.Products.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.ProductName = obj.ProductName;
                objFromDb.ProductDescription = obj.ProductDescription;
                objFromDb.Company = obj.Company;
                objFromDb.Size = obj.Size;
                objFromDb.Size = obj.Size;
                objFromDb.Mrp = obj.Mrp;
                objFromDb.WholeSale = obj.WholeSale;
                objFromDb.RetailPrice = obj.RetailPrice;
                objFromDb.CategoryId = obj.CategoryId;
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }

        public IEnumerable<Product> GetProductsByName(string productName)
        {
            productName = productName.ToLower(); // Convert the search string to lowercase.

            return _dbContext.Products.Include(p => p.Category).Where(p => p.ProductName.ToLower().Contains(productName)).ToList();
        }




    }
}
