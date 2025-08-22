using Interest.Application.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Interest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InterestController : Controller
    {
        private readonly ICompoundInterest _compoundInterestService;
        private readonly ISimpleInterest _simpleInterestService;
        public InterestController(ICompoundInterest compoundInterestService, ISimpleInterest simpleInterestService)
        {
            _compoundInterestService = compoundInterestService;
            _simpleInterestService = simpleInterestService;
        }

        [HttpGet("compound")]
        public IActionResult CalculateCompoundInterest(decimal principal, decimal rate, int time, int frequency)
        {
            try
            {
                var result = _compoundInterestService.CalculateCompoundInterest(principal, rate, time, frequency);
                return Ok(new { CompoundInterest = result });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("simple")]
        public IActionResult CalculateSimpleInterest(decimal principal, decimal rate, int time)
        {
            try
            {
                var result = _simpleInterestService.CalculateSimpleInterest(principal, rate, time);
                return Ok(new { SimpleInterest = result });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
