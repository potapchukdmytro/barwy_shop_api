﻿using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Classes
{
    public class ProductRepository : GenericRepository<Product, Guid>,
        IProductRepository
    {
        private readonly AppEFContext _dbContext;

        public ProductRepository(AppEFContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Product> Products => GetAll().Where(p => p.IsDelete == false).Include(p => p.CategoryProduct);

        public async Task AddToCategoryAsync(Product product, string categoryName)
        {
            var category = await _dbContext.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.NormalizedName == categoryName.ToUpper());
            var categoryProduct = new CategoryProduct
            {
                CategoryId = category.Id,
                ProductId = product.Id
            };
            await _dbContext.CategoryProduct.AddAsync(categoryProduct);
            await _dbContext.SaveChangesAsync();
        }
    }
}
