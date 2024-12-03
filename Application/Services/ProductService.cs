using Application.Interfaces;
using AutoMapper;
using Domain.Entities.Exceptions;
using Domain.Entities.Models;
using Domain.Interfaces;
using Shared.DTOs.Product;
using Shared.RequestFeatures;

namespace Application.Services;

internal sealed class ProductService : IProductService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public ProductService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<(IEnumerable<ProductDto> products, MetaData metaData)> GetAllProductsAsync(ProductParameters productParameters, bool trackChanges)
    {
        if (!productParameters.ValidPriceRange)
            throw new MaxPriceRangeBadRequestException();
        var productsWithMetaData = await _repository.Product.GetAllProductsAsync(productParameters, trackChanges);
        var productsDto = _mapper.Map<IEnumerable<ProductDto>>(productsWithMetaData);
        return (products: productsDto, metaData: productsWithMetaData.MetaData);
    }

    public async Task<ProductDto> GetProductAsync(Guid productId, bool trackChanges)
    {
        var product = await GetProductAndCheckIfExists(productId, trackChanges);
        var productDto = _mapper.Map<ProductDto>(product);
        return productDto;
    }

    public async Task<ProductDto> CreateProductAsync(ProductForCreationDto product)
    {
        var productEntity = _mapper.Map<Product>(product);
        _repository.Product.CreateProduct(productEntity);
        await _repository.SaveAsync();
        var productToReturn = _mapper.Map<ProductDto>(productEntity);
        return productToReturn;
    }

    public async Task DeleteProductAsync(Guid productId, bool trackChanges)
    {
        var product = await GetProductAndCheckIfExists(productId, trackChanges);
        _repository.Product.DeleteProduct(product);
        await _repository.SaveAsync();
    }

    public async Task UpdateProductAsync(Guid productId, ProductForUpdateDto productForUpdate, bool trackChanges)
    {
        var product = await GetProductAndCheckIfExists(productId, trackChanges);
        _mapper.Map(productForUpdate, product);
        await _repository.SaveAsync();
    }


    public async Task PartiallyUpdateProductAsync(Guid productId, ProductPatchDto productForUpdate, bool trackChanges)
    {
        var product = await GetProductAndCheckIfExists(productId, trackChanges);
        _mapper.Map(productForUpdate, product);
        await _repository.SaveAsync();
    }
    private async Task<Product> GetProductAndCheckIfExists(Guid productId, bool trackChanges)
    {
        var product = await _repository.Product.GetProductAsync(productId, trackChanges)
            ?? throw new ProductNotFoundException(productId);
        return product;
    }
}

