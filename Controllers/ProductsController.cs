using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

[ApiController]
[Route("products")]
public class ProductsController : ControllerBase
{

    private ProductsSql productsSql;

    public ProductsController(IConfiguration configuration)
    {
        productsSql = new ProductsSql(configuration);
    }

    //get all productss
    [HttpGet]
    [Route("find/product/all")]
    public async Task<List<Products>> getAllproductss()
    {
        List<Products> products = new List<Products>();
        DbDataReader productsReaderData = null;
        try
        {
            productsReaderData = await productsSql.FindAll();
            while (await productsReaderData.ReadAsync())
            {
                products.Add(
                  new Products()
                  {
                      PName = productsReaderData.GetValue("PName").ToString(),
                      PPrice = Decimal.Parse(productsReaderData.GetValue("PPrice").ToString()),
                      PQuantity = Int16.Parse(productsReaderData.GetValue("PQuantity").ToString()),
                      PDescription = productsReaderData.GetValue("PDescription").ToString(),
                      PId = Int16.Parse(productsReaderData.GetValue("PId").ToString()),
                      PType = productsReaderData.GetValue("PType").ToString(),
                  }
                );
            }

        }
        catch (System.Exception)
        {

            throw;
        }
        return products;
    }

    //get products by Id
    [HttpGet]
    [Route("find/product/{id}")]
    public async Task<Products> getproducts(int id)
    {
        Products products = null;
        DbDataReader productsReaderData = null;
        try
        {
            productsReaderData = await productsSql.FindById(id);
            products = new Products
            {
                PName = productsReaderData.GetValue("PName").ToString(),
                PPrice = Decimal.Parse(productsReaderData.GetValue("PPrice").ToString()),
                PQuantity = Int16.Parse(productsReaderData.GetValue("PQuantity").ToString()),
                PDescription = productsReaderData.GetValue("PDescription").ToString(),
                PId = Int16.Parse(productsReaderData.GetValue("PId").ToString()),
                PType = productsReaderData.GetValue("PType").ToString(),
            };
        }
        catch (System.Exception)
        {

            throw;
        }
        return products;
    }

    //create products
    [HttpPost]
    [Route("create/product")]
    public async Task<HttpStatusCode> createproducts(Products products)
    {

        string PType = products.PType;
        string PName = products.PName;
        decimal PPrice = products.PPrice;
        int PQuantity = products.PQuantity;
        string PDescription = products.PDescription;
        HttpStatusCode statusCode = HttpStatusCode.Created;
        DbDataReader productsReaderData = null;
        try
        {
            productsReaderData = await productsSql.Create(PName, PPrice, PQuantity, PDescription, PType);
        }
        catch (System.Exception)
        {

            statusCode = HttpStatusCode.Forbidden;
        }

        return statusCode;
    }

    //update products
    [HttpPut]
    [Route("update/product/{id}")]
    public async Task<HttpStatusCode> updateproducts(int id, Products products)
    {
        string PType = products.PType;
        string PName = products.PName;
        decimal PPrice = products.PPrice;
        int PQuantity = products.PQuantity;
        string PDescription = products.PDescription;
        HttpStatusCode statusCode = HttpStatusCode.Created;
        DbDataReader productsReaderData = null;
        try
        {
            productsReaderData = await productsSql.Update(id, PName, PPrice, PQuantity, PDescription, PType);
        }
        catch (System.Exception)
        {

            statusCode = HttpStatusCode.Forbidden;
        }
        return statusCode;
    }


    //delete products
    [HttpDelete]
    [Route("delete/product/{id}")]
    public async Task deleteproducts(int id)
    {
        try
        {
            await productsSql.DeleteById(id);
        }
        catch (System.Exception)
        {

            throw;
        }
    }

}