using Microsoft.AspNetCore.Mvc;
using BookStoreRepository;
using BookStoreModels.Models;
using BookStoreModels.ViewModels;
using System.Net;

namespace BookStoreApi.Controllers
{
    [Route("api/public")]
    [ApiController]
    public class BookStoreController : ControllerBase
    {
        UserRepository _repository = new UserRepository();

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginModel model)
        {
            try
            {

                User user = _repository.Login(model);
                if (user == null)
                    return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "User Not Found"); ;
                UserModel userModel = new UserModel(user);
                //return Ok(user);
                return StatusCode(HttpStatusCode.OK.GetHashCode(),userModel);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(),ex.Message);
            }
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterModel model)
        {
            try
            {
                User user = _repository.Register(model);
                if (user == null)
                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(),"Bad Request");
                //return Ok(user);
                return StatusCode(HttpStatusCode.OK.GetHashCode(), user);
            }
            catch(Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
        }
    }
}
