using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelDesk.Models;
using TravelDesk.Repositories;

namespace TravelDesk.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TravelRequestController : ControllerBase
    {
        private readonly ITravelRequestRepository _travelRequestRepository;

        public TravelRequestController(ITravelRequestRepository travelRequestRepository)
        {
            _travelRequestRepository = travelRequestRepository;
        }

        [HttpGet]
        public ActionResult<List<TravelRequest>> GetAll()
        {
            var travelRequests = _travelRequestRepository.GetAll();
            return Ok(travelRequests);
        }

        [HttpGet("{id}")]
        public ActionResult<TravelRequest> GetById(int id)
        {
            var travelRequest = _travelRequestRepository.GetTravelRequestById(id);
            if (travelRequest == null)
            {
                return NotFound();
            }
            return Ok(travelRequest);
        }

        [HttpPost]
        public ActionResult<TravelRequest> Create([FromBody] TravelRequest travelRequest)
        {
            if (travelRequest == null)
            {
                return BadRequest("Travel request cannot be null.");
            }

            var createdTravelRequest = _travelRequestRepository.AddTravelRequest(travelRequest);
            return CreatedAtAction(nameof(GetById), new { id = createdTravelRequest.Id }, createdTravelRequest);
        }

        [HttpPut("{id}")]
        public ActionResult<TravelRequest> Update(int id, [FromBody] TravelRequest travelRequest)
        {
            if (travelRequest == null)
            {
                return BadRequest("Travel request cannot be null.");
            }

            var updatedTravelRequest = _travelRequestRepository.UpdateTravelRequest(id, travelRequest);
            if (updatedTravelRequest == null)
            {
                return NotFound();
            }

            return Ok(updatedTravelRequest);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var isDeleted = _travelRequestRepository.DeleteTravelRequest(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
