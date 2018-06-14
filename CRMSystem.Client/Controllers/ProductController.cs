﻿using System.Collections.Generic;
using System.Linq;
using CRMSystem.Client.DTOModels;
using CRMSystem.Data;
using CRMSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRMSystem.Client.Controllers
{
    //[Authorize(Roles = "Employees", Policy = "OnlyEmployees")]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly CRMDbContext db;

        public ProductsController(CRMDbContext db)
        {
            this.db = db;
        }

        public IActionResult Get()
        {
            var products = this.db
                .Products
                .ToList();

            return this.Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var products = db.Products
                .SelectMany(x => x.SalledProducts.Where(y => y.CustomerId == id))
                .Include(x => x.Customer)
                .Include(x => x.Product)
                .ToList();


            if (products == null)
            {
                return this.NotFound("There are no products with such ID!");
            }

            return this.Ok(products);
        }

        [HttpPost]
        public IActionResult Post([FromBody]ProductDTO model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            Product product = new Product
            {
                Name = model.Name,
                Info = model.Info,
                Price = model.Price,
                SalledProducts = model.SalledProducts
            };

            this.db.Products.Add(product);
            this.db.SaveChanges();

            return this.Created(this.Url.ToString(), product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]ProductDTO model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var productForUpdate = this.db.Products.Where(x => x.Id == id).FirstOrDefault();

            if (productForUpdate == null)
            {
                return BadRequest("There is no product with such ID!");
            }

            productForUpdate.Info = model.Info;
            productForUpdate.Name = model.Name;
            productForUpdate.Price = model.Price;
            productForUpdate.SalledProducts = model.SalledProducts;

            this.db.Products.Update(productForUpdate);
            this.db.SaveChanges();

            return this.Ok(productForUpdate);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var productForDelete = this.db.Products.Where(x => x.Id == id).FirstOrDefault();

            if (productForDelete == null)
            {
                return this.BadRequest();
            }

            this.db.Products.Remove(productForDelete);

            return this.Ok("Product was deleted!");
        }
    }
}