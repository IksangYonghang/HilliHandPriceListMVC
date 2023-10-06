﻿using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
	public class CategoryRepository : Repository<Category>,ICategoryRepository 
	{
		private readonly ApplicationDbContext _dbContext;

		public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext) 
        {
			_dbContext = dbContext;
		}
       

		public void Update(Category obj)
		{
			_dbContext.Categories.Update(obj);
		}
	}
}
