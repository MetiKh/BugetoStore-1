﻿using Microsoft.EntityFrameworkCore;
using MyStore.Application.Interfaces.Context;
using MyStore.Common;
using MyStore.Common.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Bugeto_Store.Application.Services.Products.Queries.GetProductForAdmin
{
    public interface IGetProductForAdminService
    {
        ResultDto<ProductForAdminDto> Execute(int Page = 1, int PageSize = 20);
    }

    public class GetProductForAdminService : IGetProductForAdminService
    {
        private readonly IDatabaseContext _context;
        public GetProductForAdminService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto<ProductForAdminDto> Execute(int Page = 1, int PageSize = 20)
        {
            int rowCount = 0;
            var products = _context.Products
                .Include(p => p.Category)
                .ToPaged(Page, PageSize, out rowCount)
                .Select(p => new ProductsFormAdminList_Dto
                {
                    Id = p.ID,
                    Brand = p.Brand,
                    Category = p.Category.CategoryName,
                    Description = p.Description,
                    Displayed = p.DisPlayed,
                    Inventory = p.Invertory,
                    Name = p.Name,
                    Price = p.Price,
                }).ToList();

            return new ResultDto<ProductForAdminDto>()
            {
                Data = new ProductForAdminDto()
                {
                    Products = products,
                    CurrentPage = Page,
                    PageSize = PageSize,
                    RowCount = rowCount
                },
                IsSuccess = true,
                Message = "",
            };
        }
    }

    public class ProductForAdminDto
    {
        public int RowCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        public List<ProductsFormAdminList_Dto> Products { get; set; }
    }

    public class ProductsFormAdminList_Dto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Inventory { get; set; }
        public bool Displayed { get; set; }
    }
}
