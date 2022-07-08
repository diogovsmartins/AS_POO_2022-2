using Microsoft.AspNetCore.Mvc;
using Ulbraflix.domain.DTOs_e_VOs;
using Ulbraflix.domain.entities;
using Ulbraflix.services.interfaces;

namespace Ulbraflix.controllers
{
[ApiController]
[Route("category")]
    public class CategoryController: ControllerBase
    {
        private readonly ICategoryService _categoryService;
        
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
          Category category=_categoryService.GetById(id);
          CategoryRecordVO categoryRecord = new CategoryRecordVO(category.Name);
          return Ok(categoryRecord);
        }


        [HttpGet("async/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            Category category=await _categoryService.GetByIdAsync(id);
            CategoryRecordVO categoryRecord = new CategoryRecordVO(category.Name);
            return Ok(categoryRecord);
        }
        
        
        [HttpGet("async/")]
        public async Task<IActionResult> GetAllAsync()
        {
            List<Category> categories = new List<Category>();
            categories.AddRange(await _categoryService.GetAllAsync());
            List<CategoryRecordVO> categoryRecords = new List<CategoryRecordVO>();
            categories.ForEach(category =>
            {
                CategoryRecordVO categoryRecord = new CategoryRecordVO(category.Name);
                categoryRecords.Add(categoryRecord);
            });
            return Ok(categoryRecords);
        }
        
        [HttpGet]
        public  IActionResult GetAll()
        {
            List<Category> categories = new List<Category>();
            categories.AddRange(_categoryService.GetAll());
            List<CategoryRecordVO> categoryRecords = new List<CategoryRecordVO>();
            categories.ForEach(category =>
            {
                CategoryRecordVO categoryRecord = new CategoryRecordVO(category.Name);
                categoryRecords.Add(categoryRecord);
            });
            return Ok(categoryRecords);
        }

        [HttpPost ("insert")]
        public IActionResult InsertCategory([FromBody] CategoryRecord categoryRecord)
        {
            try
            {
                if (categoryRecord.Equals(null) ||
                    categoryRecord.Name.Equals(""))
                    return new BadRequestResult();

                Category category = new Category();
                category.Name = categoryRecord.Name;
                if (_categoryService.Insert(category))
                {
                    return Ok("Successfully inserted");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
            return BadRequest();
        }
        
        [HttpPut("update")]
        public IActionResult UpdateCategory([FromBody] CategoryRecord categoryRecord)
        {
            try
            {
                if (categoryRecord.Equals(null) ||
                    categoryRecord.Id.Equals(null) ||
                    categoryRecord.Name.Equals(""))
                    return new BadRequestResult();

                Category category = new Category();
                category.Id = categoryRecord.Id;
                category.Name = categoryRecord.Name;
                if (_categoryService.Update(category))
                {
                    return Ok("Successfully updated");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
            return BadRequest();
        }
        
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                if (_categoryService.Delete(id))
                {
                    return Ok("Successfully deleted");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
            return BadRequest();
        }
    }
}