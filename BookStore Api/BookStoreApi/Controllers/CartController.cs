using BookStoreModels.Models;
using BookStoreModels.ViewModels;
using BookStoreRepository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookStoreApi.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : ControllerBase
    {
        CartRepository _cartRepository = new CartRepository();

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(typeof(CartModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult AddCartItem(CartModel cartModel)
        {
            /* try
             {
                 Cart cart = new Cart()
                 {
                     Id = cartModel.Id,
                     Userid = cartModel.UserId,
                     Bookid = cartModel.BookId,
                     Quantity = cartModel.Quantity,
                 };
                 var addedCategory = _cartRepository.AddItem(cart);
                 CartModel categoryModel1 = new CartModel(addedCategory);
                 if (addedCategory == null)
                     return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Bad Request");
                 //return Ok(user);
                 return StatusCode(HttpStatusCode.OK.GetHashCode(), categoryModel1);
             }
             catch (Exception ex)
             {
                 return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
             }*/

            if (cartModel == null)
                return BadRequest();
            Cart cart = new Cart()
            {
                Id = cartModel.Id,
                Userid = cartModel.UserId,
                Bookid = cartModel.BookId,
                Quantity = cartModel.Quantity,
            };
            var addedCategory = _cartRepository.AddItem(cart);
            CartModel cartModel1 = new CartModel(addedCategory);

            return Ok(cartModel1);
        }

        [HttpGet]
        [Route("list")]
        public IActionResult GetCart(int UserId)
        {
            try
            {
                var cart = _cartRepository.GetCart(UserId);
                if (cart == null)
                    return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "Please provide correct information");

                ListResponse<GetCartModel> listResponse = new ListResponse<GetCartModel>()
                {
                    Records = cart.Records.Select(c => new GetCartModel(c)).ToList(),
                    TotalRecords = cart.TotalRecords
                };
                return StatusCode(HttpStatusCode.OK.GetHashCode(), listResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
        }


        [HttpPut]
        [Route("update")]
        [ProducesResponseType(typeof(CartModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult UpdateCartItem(CartModel cartModel)
        {
            /* try
             {
                 if (cartModel != null)
                 {
                     Cart cart = new Cart()
                     {
                         Id = cartModel.Id,
                         Userid = cartModel.UserId,
                         Bookid = cartModel.BookId,
                         Quantity = cartModel.Quantity,
                     };
                     var response = _cartRepository.UpdateItem(cart);

                     if (response != null)
                         return StatusCode(HttpStatusCode.OK.GetHashCode(), new CartModel(response));
                 }
                 return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Please provide correct information");
             }
             catch (Exception ex)
             {
                 return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
             }*/

            if (cartModel == null)
                return BadRequest();
            Cart cart = new Cart()
            {
                Id = cartModel.Id,
                Userid = cartModel.UserId,
                Bookid = cartModel.BookId,
                Quantity = cartModel.Quantity,
            };
            var response = _cartRepository.UpdateItem(cart);

            return Ok(new CartModel(response));
        }

        [Route("delete/{id}")]
        [HttpDelete]
        [ProducesResponseType(typeof(CartModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult DeleteCart(int id)
        {
           /* if (id == 0)
                return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "id is null");
            try
            {
                Cart response = _cartRepository.DeleteItem(id);
                if (response != null)
                    return StatusCode(HttpStatusCode.OK.GetHashCode(), "Cart Deleted Successfully");
                return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), new CartModel(response));
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
           */
            if (id == 0)
                return BadRequest();

            Cart response = _cartRepository.DeleteItem(id);
            return Ok(response);
        }
    }
}
