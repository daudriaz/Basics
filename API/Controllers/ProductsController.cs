using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Core.Specifications.SpecClasses;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<ProductType> _prodTypeRepo;
        private readonly IGenericRepository<ProductBrand> _prodBrandRepo;
        private readonly IGenericRepository<Product> _prodRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> prodRepo, IGenericRepository<ProductBrand> prodBrandRepo, IGenericRepository<ProductType> prodTypeRepo, IMapper mapper)
        {
            _mapper = mapper;
            _prodRepo = prodRepo;
            _prodBrandRepo = prodBrandRepo;
            _prodTypeRepo = prodTypeRepo;

        }

        [HttpGet]
        public async Task<ActionResult<List<ProductToReturnDTO>>> GetProducts()
        {
            var spec = new ProductWithBrandAndTypes();
            var products = await _prodRepo.ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDTO>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDTO>> GetProducts(int id)
        {
            var spec = new ProductWithBrandAndTypes(id);
            var product = await _prodRepo.GetEntityWithSpec(spec);
            return _mapper.Map<Product,ProductToReturnDTO>(product);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _prodBrandRepo.ListAllAsync());
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProductTypes()
        {
            return Ok(await _prodTypeRepo.ListAllAsync());
        }

    }
}