using Crud.Models;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;

namespace Crud.Services;

public class ProductsAppService : ProductsService.ProductsServiceBase
{
    public LearnContext _context;

    public ProductsAppService(LearnContext context) => _context = context;

    #region GetAll
    public override async Task<Products> GetAll(Empty request, ServerCallContext context)
    {
        var response = new Products();
        var products = await _context.Products.Select(prd => new Product()
        {
            ProductId = prd.ProductId,
            ProductName = prd.ProductName,
            CategoryName = prd.CategoryName,
            Manufacturer = prd.Manufacturer,
            Price = prd.Price
        }).ToListAsync();


        response.Items.AddRange(products);
        return response;
    }

    #endregion

    #region GetById
    public override Task<Product> GetById(ProductRowIdFilter request, ServerCallContext context)
    {
        var product = _context.Products.Find(request.ProductId);
        var searchedProduct = new Product()
        {
            ProductId = product.ProductId,
            ProductName = product.ProductName,
            CategoryName = product.CategoryName,
            Manufacturer = product.Manufacturer,
            Price = product.Price
        };
        return Task.FromResult(searchedProduct);
    }
    #endregion

    #region PostInsert
    public override async Task<Product> Post(Product request, ServerCallContext context)
    {
        var product = new Models.Product()
        {
            ProductName = request.ProductName,
            CategoryName = request.CategoryName,
            Manufacturer = request.Manufacturer,
            Price = request.Price
        };

        var res = _context.Products.Add(product);
        await _context.SaveChangesAsync();

        var response = new Product()
        {
            ProductId = res.Entity.ProductId,
            ProductName = res.Entity.ProductName,
            CategoryName = res.Entity.CategoryName,
            Manufacturer = res.Entity.Manufacturer,
            Price = res.Entity.Price
        };

        return response;
    }
    #endregion

    #region PUTUPDATE
    public override async Task<Product> Put(Product request, ServerCallContext context)
    {
        Models.Product prd = _context.Products.Find(request.ProductId);

        if (prd == null)
        {
            return await Task.FromResult<Product>(null);
        }

        prd.ProductName = request.ProductName;
        prd.CategoryName = request.CategoryName;
        prd.Manufacturer = request.Manufacturer;
        prd.Price = request.Price;

        _context.Products.Update(prd);
        await _context.SaveChangesAsync();

        return await Task.FromResult(new Product()
        {
            ProductId = prd.ProductId,
            ProductName = prd.ProductName,
            CategoryName = prd.CategoryName,
            Manufacturer = prd.Manufacturer,
            Price = prd.Price
        });
    }
    #endregion

    #region DELETE
    public override async Task<Empty> Delete(ProductRowIdFilter request, ServerCallContext context)
    {
        Models.Product prd = _context.Products.Find(request.ProductId);
        if (prd == null)
        {
            return await Task.FromResult<Empty>(null);
        }

        _context.Products.Remove(prd);
        await _context.SaveChangesAsync();
        return await Task.FromResult<Empty>(new Empty());
    }
    #endregion
}

