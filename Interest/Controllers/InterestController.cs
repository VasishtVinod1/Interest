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

        [HttpPost("compound")]
        public IActionResult CalculateCompoundInterest(int principal, int rate, int time, int frequency)
        {
            try
            {
                var result = _compoundInterestService.CalculateCompoundInterest(principal, rate, time, frequency);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("simple")]
        public IActionResult CalculateSimpleInterest(int principal, int rate, int time)
        {
            try
            {
                var result = _simpleInterestService.CalculateSimpleInterest(principal, rate, time);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
