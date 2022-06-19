using Microsoft.AspNetCore.Mvc;
using BookStoreRepository;
using BookStoreModels.Models;
using BookStoreModels.ViewModels;
using System.Net;

namespace BookStoreApi.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        UserRepository _repository = new UserRepository();

        [HttpGet]
        [Route("list")]
        public IActionResult GetUsers(string ?keyword, int pageIndex = 1, int pageSize = 10)
        {
            try
            {
                var users = _repository.GetUsers(pageIndex, pageSize, keyword);
                
                if(users == null)
                    return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "Please provide correct information");
                return StatusCode(HttpStatusCode.OK.GetHashCode(), users);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUser(int id)
        {
            try
            {
                var user = _repository.GetUser(id);
                if (user == null)
                    return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "Please provide correct information");

                return StatusCode(HttpStatusCode.OK.GetHashCode(), user);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateUser(UserModel model)
        {
            try
            {
                if(model != null)
                {
                    var user = _repository.GetUser(model.Id);
                    if (user == null)
                        return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "Please provide correct information");
                    user.Email = model.Email;
                    user.Firstname = model.Firstname;
                    user.Lastname = model.Lastname;

                    var isSaved = _repository.UpdateUser(user);
                    if (isSaved)
                        return StatusCode(HttpStatusCode.OK.GetHashCode(), "User details updated successfully");
                }
                return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "Please provide correct information");
            }
            catch(Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
        }


        [HttpDelete]
        [Route("delete")]
        public IActionResult DeleteUser(int Id)
        {
            try
            {
                if (User != null)
                {
                    var user = _repository.GetUser(Id);
                    if (user == null)
                        return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "User not found");
                
                    var isDeleted = _repository.DeleteUser(user);
                    if (isDeleted)
                        return StatusCode(HttpStatusCode.OK.GetHashCode(), "User deleted successfully");
                }
                return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "Please provide correct information");
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
        }

        [HttpGet]
        [Route("roles")]
        public IActionResult GetRoles()
        {
            try
            {
                var roles = _repository.GetRoles();
                ListResponse<RoleModel> RoleList = new ListResponse<RoleModel>()
                {
                    Records = roles.Records.Select(x => new RoleModel(x)).ToList(),
                    TotalRecords = roles.TotalRecords
                };
                return StatusCode(HttpStatusCode.OK.GetHashCode(), roles); ;
            }
            catch(Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
        }
    }
}
