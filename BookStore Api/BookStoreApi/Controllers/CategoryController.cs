using BookStoreModels.Models;
using BookStoreModels.ViewModels;
using BookStoreRepository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookStoreApi.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        CategoryRepository _categoryRepository = new CategoryRepository();

        [HttpGet]
        [Route("list")]
        public IActionResult GetCategories(string? keyword, int pageIndex = 0, int pageSize = 10)
        {
        
            try 
            {
                var categories = _categoryRepository.GetCategories(pageIndex, pageSize, keyword);
                if (categories == null)
                    return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "Please provide correct information");

                ListResponse<CategoryModel> listResponse = new ListResponse<CategoryModel>()
                {
                    Records = categories.Records.Select(x => new CategoryModel(x)).ToList(),
                    TotalRecords = categories.TotalRecords
                };
                return StatusCode(HttpStatusCode.OK.GetHashCode(), listResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCategory(int id)
        {
            try
            {
                var response = _categoryRepository.GetCategory(id);
                if (response == null)
                    return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "Please provide correct information");
                var category = new CategoryModel(response);
                return StatusCode(HttpStatusCode.OK.GetHashCode(), category);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(typeof(CategoryModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult AddCategory(CategoryModel categoryModel)
        {
            /*
            try
            {
                Category category = new Category()
                {
                    Id = categoryModel.Id,
                    Name = categoryModel.Name,
                };
                var addedCategory = _categoryRepository.AddCategory(category);
                CategoryModel categoryModel1 = new CategoryModel(addedCategory);
                if (addedCategory == null)
                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Bad Request");
                //return Ok(user);
                return StatusCode(HttpStatusCode.OK.GetHashCode(), categoryModel1);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
*/
            if (categoryModel == null)
                return BadRequest("Model is null");
            Category category = new Category()
            {
                Id = categoryModel.Id,
                Name = categoryModel.Name,
            };
            var response = _categoryRepository.AddCategory(category);
            CategoryModel categoryModel1 = new CategoryModel(response);

            return Ok(categoryModel1);
        }

        [HttpPut]
        [Route("update")]
        [ProducesResponseType(typeof(CategoryModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult UpdateCategory(CategoryModel categoryModel)
        {
            /*
            try 
            {
                if(categoryModel != null)
                {
                    Category category = new Category()
                    {
                        Id = categoryModel.Id,
                        Name = categoryModel.Name,
                    };
                    var response = _categoryRepository.UpdateCategory(category);
                  
                    if(response != null)
                        return StatusCode(HttpStatusCode.OK.GetHashCode(), new CategoryModel(response));
                }
                return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Please provide correct information");
            }
            catch(Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
            */

            if (categoryModel == null)
                return BadRequest("Model is null");
            Category category = new Category()
            {
                Id = categoryModel.Id,
                Name = categoryModel.Name,
            };
            var response = _categoryRepository.UpdateCategory(category);
            CategoryModel categoryModel1 = new CategoryModel(response);

            return Ok(categoryModel1);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult DeleteCategory(int id)
        {
            /*
            if (id == 0)
                return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "id is null");
            try 
            {
                bool response = _categoryRepository.DeleteCategory(id);
                if (response == true)
                    return StatusCode(HttpStatusCode.OK.GetHashCode(),"Category Deleted Successfully");
                return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Please provide correct information");
            }
            catch(Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
            */
            if (id == 0)
                return BadRequest("Id is null");
            bool response = _categoryRepository.DeleteCategory(id);
            return Ok(response);
        }
    }
}
