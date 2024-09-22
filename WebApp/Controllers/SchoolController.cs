using Application.Services;
using Domain.Models;
using Domain.Parameters;
using Microsoft.AspNetCore.Mvc;
using WebApp.Requests;
using WebApp.Responses;

namespace WebApp.Controllers;

public class SchoolController(ISchoolService schoolService) : Controller
{
    [HttpGet]
    [Route("api/v1/school_get")]
    public async Task<ActionResult<School>> Get([FromQuery] int id, CancellationToken cancellationToken)
    {
        var school = await schoolService.Find(id, cancellationToken);
        if (school == default)
        {
            return NotFound(nameof(school));
        }

        return Ok(school);
    }
}