using API_Business.IBusiness;
using API_Repository.Models;
using API_Repository.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Service.Controllers
{
    [Route("api/v{version:apiVersion}/Product")]
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    public class ProductController : ControllerBase
    {
        private readonly IBusiness<Product> _business;
        private readonly IMapper _mapper;
        public ProductController(IBusiness<Product> business, IMapper mapper)
        {
            _business = business;
            _mapper = mapper;
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProduct()
        {
            try
            {
                IEnumerable<Product> products = await _business.GetAll();
                return Ok(_mapper.Map<List<ProductDTO>>(products));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDTO>> GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("Id cannot be zero");
                }
                var product = await _business.GetById(x => x.Id == id);
                if (product == null)
                {
                    return NotFound("Prodcut not found with the id " + id.ToString());
                }
                return Ok(_mapper.Map<ProductDTO>(product));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CreateProduct([FromBody] ProductCreateDTO createDTO)
        {
            try
            {
                if (createDTO == null)
                {
                    return BadRequest("Product cannot be null");
                }
                var product = _mapper.Map<Product>(createDTO);
                int value = _business.Create(product);
                if (value != 0)
                {
                    return Ok("Successfully Created");
                }
                else
                {
                    return BadRequest("Not created");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("Id cannot be zero");
                }
                var product = await _business.GetById(x => x.Id == id);
                var value = _business.Delete(product);
                if (value != 0)
                {
                    return Ok("Deleted successfully");
                }
                else
                {
                    return BadRequest("Not deleted");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.ToString());
            }
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || updateDTO.Id != id)
                {
                    return BadRequest("Id mismatch");
                }
                var product = _mapper.Map<Product>(updateDTO);
                int value = _business.Update(product);
                if (value != 0)
                {
                    return Ok("Updated successfully");
                }
                else
                {
                    return BadRequest("Not Updated");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

    }
}
