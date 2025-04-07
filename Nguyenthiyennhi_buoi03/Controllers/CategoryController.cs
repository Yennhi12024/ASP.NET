﻿using Microsoft.AspNetCore.Mvc;
using Nguyenthiyennhi_buoi03.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nguyenthiyennhi_buoi03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        // Dữ liệu mẫu
        private static List<Category> _categories = new List<Category>
        {
            new Category { Id = 1, Name = "Electronics", Description = "Devices and gadgets", Image = "electronics.jpg" },
            new Category { Id = 2, Name = "Clothing", Description = "Men and Women fashion", Image = "clothing.jpg" }
        };

        // GET: api/category - Lấy danh sách tất cả category
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            return Ok(_categories);
        }

        // GET api/category/5 - Lấy thông tin một category theo Id
        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return NotFound(new { message = "Category not found" });
            return Ok(category);
        }

        // POST api/category - Thêm category mới
        [HttpPost]
        public ActionResult<Category> CreateCategory([FromBody] Category category)
        {
            if (category == null) return BadRequest(new { message = "Invalid category data" });
            if (string.IsNullOrWhiteSpace(category.Name)) return BadRequest(new { message = "Category name is required" });

            category.Id = _categories.Max(c => c.Id) + 1; // Tự động tăng ID
            _categories.Add(category);

            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        // PUT api/category/5 - Cập nhật category theo Id
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] Category updatedCategory)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return NotFound(new { message = "Category not found" });

            if (string.IsNullOrWhiteSpace(updatedCategory.Name)) return BadRequest(new { message = "Category name is required" });

            category.Name = updatedCategory.Name;
            category.Description = updatedCategory.Description;
            category.Image = updatedCategory.Image;

            return NoContent();
        }

        // DELETE api/category/5 - Xóa category theo Id
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return NotFound(new { message = "Category not found" });

            _categories.Remove(category);
            return NoContent();
        }
    }

}
