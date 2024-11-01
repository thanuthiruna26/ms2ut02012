using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Database;
using WebApplication1.DTO.BookCategories;
using WebApplication1.DTO.Members;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMembersRepo _membersRepo;

        public MembersController(IMembersRepo membersRepo)
        {
            _membersRepo = membersRepo;
        }

        [HttpGet]

        public IActionResult Getall()
        {
            var members = _membersRepo.GetAll();
            return Ok(members);
        }

        [HttpGet("{MemberId}")]
        public IActionResult GetById(int MemberId)
        {
            var members = _membersRepo.GetById(MemberId);
            if (members == null)
                return NotFound();
            return Ok(members);
        }

        [HttpPost]
        public IActionResult Create(MemberResponse MemberResponse)
        {
            var members = new Members
            {
                Name = MemberResponse.Name,

            };
            _membersRepo.Add(members);
            return CreatedAtAction(nameof(GetById), new { MemberId = members.MemberId }, members);
        }

        [HttpPut("{MembersId}")]
        public IActionResult Update(int MemberId, MemberResponse MembersResponse)
        {
            var members = _membersRepo.GetById(MemberId);
            if (members == null)
                return NotFound();

            members.Name = members.Name;

            _membersRepo.Update(members);

            return NoContent();
        }

        [HttpDelete("{MemberId}")]
        public IActionResult Delete(int MemberId)
        {
            var members = _membersRepo.GetById(MemberId);
            if (members == null)
                return NotFound();

            _membersRepo.Delete(MemberId);
            return NoContent();
        }
    }
}
            