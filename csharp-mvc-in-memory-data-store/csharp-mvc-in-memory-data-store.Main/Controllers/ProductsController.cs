using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using mvc_in_memory_data_store.Data;
using mvc_in_memory_data_store.Models;
using System;

namespace mvc_in_memory_data_store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("All")]
        public async Task<IResult> Get()
        {
            try
            {                
                return Results.Ok(_productRepository.findAll());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Route("Create")]
        public async Task<IResult> Post(Product product)
        {
            try
            {
                if (_productRepository.Add(product)) return Results.Created("boolean.com", product);
                return Results.NotFound();

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("One")]

        public async Task<IResult> One(int id)
        {

            try
            {
                return Results.Ok(_productRepository.find(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Route("Update/{id}")]
        public async Task<IResult> Update(int id, Product newProduct)
        {
            try
            {
                if (_productRepository.Update(id, newProduct))
                {
                    return Results.Created("boolean.com", newProduct);
                }
                return Results.NotFound();

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("Delete/{id}")]
        public async Task<IResult> Delete(int id)
        {
            try
            {
                if (_productRepository.Delete(id))
                {
                    return Results.Ok();
                }
                return Results.NotFound();

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }

        }
}
