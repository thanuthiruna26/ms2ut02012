using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Database;
using WebApplication1.DTO.BookCategories;
using WebApplication1.DTO.Lending;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LendingController : ControllerBase
    {
        private readonly ILendingRepo _lendingRepo;

        public LendingController(ILendingRepo lendingRepo)
        {
            _lendingRepo = lendingRepo;
        }

        [HttpGet]

        public IActionResult Getall()
        {
            var lending = _lendingRepo.GetAll();
            return Ok(lending);
        }

        [HttpGet("{LendingId}")]
        public IActionResult GetById(int LendingId)
        {
            var lending = _lendingRepo.GetById(LendingId);
            if (lending == null)
                return NotFound();
            return Ok(lending);
        }

        [HttpPost]
        public IActionResult Create(LendingResponse lendingResponse)
        {
            var lending = new Lending
            {
                LendingId = lendingResponse.LendingId,

            };
            _lendingRepo.Add(lending);
            return CreatedAtAction(nameof(GetById), new { LendingId = lending.LendingId }, lending);
        }

        [HttpPut("{LendingId}")]
        public IActionResult Update(int LendingId, LendingResponse LendingResponse)
        {
            var lending = _lendingRepo.GetById(LendingId);
            if (lending == null)
                return NotFound();

            lending.LendingId = LendingResponse.LendingId;

            _lendingRepo.Update(lending);

            return NoContent();
        }

        [HttpDelete("{LendingId}")]
        public IActionResult Delete(int LendingId)
        {
            var lending = _lendingRepo.GetById(LendingId);
            if (lending == null)
                return NotFound();

            _lendingRepo.Delete(LendingId);
            return NoContent();
        }
    }
}
