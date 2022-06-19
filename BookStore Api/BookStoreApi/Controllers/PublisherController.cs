using BookStoreModels.Models;
using BookStoreModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using BookStoreRepository;
using System.Net;

namespace BookStoreApi.Controllers
{
    [ApiController]
    [Route("api/publisher")]
    public class PublisherController : Controller
    {
        PublisherRepository _publisherRepository = new PublisherRepository();

        [HttpGet]
        [Route("list")]
        public IActionResult GetPublishers(string? keyword, int pageIndex = 1, int pageSize = 10)
        {
            try
            {
                var publishers = _publisherRepository.GetPublishers(pageIndex, pageSize, keyword);
                if (publishers == null)
                    return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "Please provide correct information");

                ListResponse<PublisherModel> listResponse = new ListResponse<PublisherModel>()
                {
                    Records = publishers.Records.Select(x => new PublisherModel(x)).ToList(),
                    TotalRecords = publishers.TotalRecords
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
        [ProducesResponseType(typeof(PublisherModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NotFoundResult), (int)HttpStatusCode.NotFound)]
        public IActionResult GetPublisher(int id)
        {
            /*
            try
            {
                var response = _publisherRepository.GetPublisher(id);
                if (response == null)
                    return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "Please provide correct information");
                var publisher = new PublisherModel(response);
                return StatusCode(HttpStatusCode.OK.GetHashCode(), publisher);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
            */

            var response = _publisherRepository.GetPublisher(id);
            if (response == null)
                return NotFound();
         //var publisher
            PublisherModel publisher = new PublisherModel(response);

            return Ok(publisher);
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(typeof(PublisherModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult AddPublisher(PublisherModel publisherModel)
        {
            /*
            try
            {
                Publisher publisher = new Publisher()
                {
                    Id = publisherModel.Id,
                    Name = publisherModel.Name,
                };
                var addedPublisher = _publisherRepository.AddPublisher(publisher);
                PublisherModel publisherModel1 = new PublisherModel(addedPublisher);
                if (addedPublisher == null)
                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Bad Request");
                //return Ok(user);
                return StatusCode(HttpStatusCode.OK.GetHashCode(), publisherModel1);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
            */
            if (publisherModel == null)
                return BadRequest("PublisherModel is null");
            Publisher publisher = new Publisher()
            {
                Id = publisherModel.Id,
                Name = publisherModel.Name,

            };
            var addedPublisher = _publisherRepository.AddPublisher(publisher);
            PublisherModel publisherModel1 = new PublisherModel(addedPublisher);

            return Ok(publisherModel1);
        }

        [HttpPut]
        [Route("update")]
        [ProducesResponseType(typeof(PublisherModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult UpdatePublisher(PublisherModel publisherModel)
        {
            /*
            try
            {
                if (publisherModel != null)
                {
                    Publisher publisher = new Publisher()
                    {
                        Id = publisherModel.Id,
                        Name = publisherModel.Name,
                        Address = publisherModel.Address,
                        Contact = publisherModel.Contact,
                    };
                    var response = _publisherRepository.UpdatePublisher(publisher);

                    if (response != null)
                        return StatusCode(HttpStatusCode.OK.GetHashCode(), new PublisherModel(response));
                }
                return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Please provide correct information");
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
            */
            if (publisherModel == null)
                return BadRequest("PublisherModel is null");
            Publisher publisher = new Publisher()
            {
                Id = publisherModel.Id,
                Name = publisherModel.Name,
                Address = publisherModel.Address,
                Contact = publisherModel.Contact,
            };
            var response = _publisherRepository.UpdatePublisher(publisher);
            PublisherModel publisherModel1 = new PublisherModel(response);

            return Ok(publisherModel1);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult DeletePublisher(int id)
        {/*
            if (id == 0)
                return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "id is null");
            try
            {
                bool response = _publisherRepository.DeletePublisher(id);
                if (response == true)
                    return StatusCode(HttpStatusCode.OK.GetHashCode(), "Publisher Deleted Successfully");
                return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Please provide correct information");
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
            */

            if (id == 0)
                return BadRequest("Id is null");
            var response = _publisherRepository.DeletePublisher(id);
            return Ok(response);
        }
    }
}
