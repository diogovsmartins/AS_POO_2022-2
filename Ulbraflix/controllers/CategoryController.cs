using Microsoft.AspNetCore.Mvc;
using Ulbraflix.domain.DTOs_e_VOs;
using Ulbraflix.domain.entities;
using Ulbraflix.services.interfaces;

namespace Ulbraflix.controllers
{
[ApiController]
[Route("[controller]")]
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
          CategoryRecord categoryRecord = new CategoryRecord(category.Name);
          return Ok(categoryRecord);
        }


        [HttpGet("/async/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            Category category=await _categoryService.GetByIdAsync(id);
            CategoryRecord categoryRecord = new CategoryRecord(category.Name);
            return Ok(categoryRecord);
        }
        
        
        [HttpGet("/async/")]
        public async Task<IActionResult> GetAllAsync()
        {
            List<Category> categories = new List<Category>();
            categories.AddRange(await _categoryService.GetAllAsync());
            List<CategoryRecord> categoryRecords = new List<CategoryRecord>();
            categories.ForEach(category =>
            {
                CategoryRecord categoryRecord = new CategoryRecord(category.Name);
                categoryRecords.Add(categoryRecord);
            });
            return Ok(categoryRecords);
        }
        
        [HttpGet]
        public  IActionResult GetAll()
        {
            List<Category> categories = new List<Category>();
            categories.AddRange(_categoryService.GetAll());
            List<CategoryRecord> categoryRecords = new List<CategoryRecord>();
            categories.ForEach(category =>
            {
                CategoryRecord categoryRecord = new CategoryRecord(category.Name);
                categoryRecords.Add(categoryRecord);
            });
            return Ok(categoryRecords);
        }

        [HttpPost ("/insert")]
        public IActionResult InsertCategory([FromBody] CategoryRecord categoryRecord)
        {
            if (categoryRecord.Equals(null) ||
                categoryRecord.Name.Equals(""))
                return new BadRequestResult();
            
            Category category = new Category();
            category.Name = categoryRecord.Name;
            _categoryService.Insert(category);
            return Ok();
        }
        
        [HttpPut("/update/{id}")]
        public IActionResult UpdateCategory([FromBody] CategoryRecord categoryRecord)
        {
            if (categoryRecord.Equals(null) ||
                categoryRecord.Name.Equals(""))
                return new BadRequestResult();
            
            Category category = new Category();
            category.Name = categoryRecord.Name;
            _categoryService.Update(category);
            return Ok();
        }
        
        [HttpDelete("/delete/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.Delete(id);
            return Ok();
        }
    }
}