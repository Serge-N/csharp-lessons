using Crud.Models;
using Grpc.Core;

namespace Crud.Services;

public class ProductsAppService : ProductsService.ProductsServiceBase
{
    public LearnContext _context;

    public ProductsAppService(LearnContext context) => _context = context;

    #region GetAll
    public override Task<Products> GetAll(Empty request, ServerCallContext context)
    {
        Products response = new Products();
        var products = from prd in _context.Products
                       select new Product()
                       {
                           ProductId = prd.ProductId,
                           ProductName = prd.ProductName,
                           CategoryName = prd.CategoryName,
                           Manufacturer = prd.Manufacturer,
                           Price = prd.Price
                       };
        response.Items.AddRange(products.ToArray());
        return Task.FromResult(response);
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
    public override Task<Product> Post(Product request, ServerCallContext context)
    {
        var prdAdded = new Models.Product()
        {
            ProductId = request.ProductId,
            ProductName = request.ProductName,
            CategoryName = request.CategoryName,
            Manufacturer = request.Manufacturer,
            Price = request.Price
        };

        var res = _context.Products.Add(prdAdded);
        _context.SaveChanges();

        var response = new Product()
        {
            ProductId = res.Entity.ProductId,
            ProductName = res.Entity.ProductName,
            CategoryName = res.Entity.CategoryName,
            Manufacturer = res.Entity.Manufacturer,
            Price = res.Entity.Price
        };
        return Task.FromResult<Product>(response);
    }
    #endregion

    #region PUTUPDATE
    public override Task<Product> Put(Product request, ServerCallContext context)
    {
        Models.Product prd = _context.Products.Find(request.ProductId);
        if (prd == null)
        {
            return Task.FromResult<Product>(null);
        }

        prd.ProductId = request.ProductId;
        prd.ProductName = request.ProductName;
        prd.CategoryName = request.CategoryName;
        prd.Manufacturer = request.Manufacturer;
        prd.Price = request.Price;

        _context.Products.Update(prd);
        _context.SaveChanges();

        return Task.FromResult(new Product()
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
    public override Task<Empty> Delete(ProductRowIdFilter request, ServerCallContext context)
    {
        Models.Product prd = _context.Products.Find(request.ProductId);
        if (prd == null)
        {
            return Task.FromResult<Empty>(null);
        }
        _context.Products.Remove(prd);
        _context.SaveChanges();
        return Task.FromResult<Empty>(new Empty());
    }
    #endregion
}

