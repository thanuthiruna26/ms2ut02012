using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Database;
using WebApplication1.DTO.Members;
using WebApplication1.DTO.Reports;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberReportController : ControllerBase
    {
        private readonly IMemberReportRepo _memberReportRepo;

        public MemberReportController(IMemberReportRepo memberReportRepo)
        {
            _memberReportRepo = memberReportRepo;
        }

        [HttpGet]

        public IActionResult Getall()
        {
            var memberReport = _memberReportRepo.GetAll();
            return Ok(memberReport);
        }

        [HttpGet("{MemberId}")]
        public IActionResult GetById(int MemberId)
        {
            var memberReport = _memberReportRepo.GetById(MemberId);
            if (memberReport == null)
                return NotFound();
            return Ok(memberReport);
        }

        [HttpPost]
        public IActionResult Create(MemberReportResponse MemberReportResponse)
        {
            var memberReport = new MemberReport
            {
                Name = MemberReportResponse.Name,

            };
            _memberReportRepo.Add(memberReport);
            return CreatedAtAction(nameof(GetById), new { MemberId = memberReport.MemberId }, memberReport);
        }

        [HttpPut("{MemberId}")]
        public IActionResult Update(int MemberId, MemberReportResponse MembersReporyResponse)
        {
            var memberReport = _memberReportRepo.GetById(MemberId);
            if (memberReport == null)
                return NotFound();

            memberReport.Name = memberReport.Name;

            _memberReportRepo.Update(memberReport);

            return NoContent();
        }

        [HttpDelete("{MemberId}")]
        public IActionResult Delete(int MemberId)
        {
            var members = _memberReportRepo.GetById(MemberId);
            if (members == null)
                return NotFound();

            _memberReportRepo.Delete(MemberId);
            return NoContent();
        }
    }
}
