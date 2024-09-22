using Application.Services;
using Domain.Models;
using Domain.Parameters;
using Microsoft.AspNetCore.Mvc;
using WebApp.Requests;
using WebApp.Responses;

namespace WebApp.Controllers;

public class UserController(IUserService userService, ISchoolService schoolService) : Controller
{
    [HttpGet]
    [Route("api/v1/user_get-list")]
    public async Task<ActionResult<GetUserListResponse>> GetList(
        [FromQuery] int pageSize = 10,
        [FromQuery] int pageNumber = 1,
        [FromQuery] bool onlyUsersWithoutSchool = false,
        CancellationToken cancellationToken = default)
    {
        if (pageSize == 0 || pageNumber == 0)
        {
            return BadRequest();
        }
        
        var @params = new GetUserListParameters
        {
            PageSize = pageSize,
            PageNumber = pageNumber,
            OnlyUsersWithoutSchool = onlyUsersWithoutSchool
        };
        var getListResult = await userService.GetList(@params, cancellationToken);
        
        var response = new GetUserListResponse
        {
            Users = getListResult.Items,
            MetaInfo = new()
            {
                Total = getListResult.TotalCount,
                From = (pageNumber - 1) * pageSize,
                Count = getListResult.Items.Length
            }
        };
        
        return Ok(response);
    }

    [HttpGet]
    [Route("api/v1/user_get")]
    public async Task<ActionResult<User>> Get([FromQuery] int id, CancellationToken cancellationToken = default)
    {
        var user = await userService.Find(id, cancellationToken);
        if (user == default)
        {
            return NotFound(nameof(user));
        }

        return Ok(user);
    }
    
    [HttpPost]
    [Route("api/v1/user_set-school-id")]
    public async Task<ActionResult> SetUserSchoolId(
        [FromBody] SetUserSchoolIdRequest request,
        CancellationToken cancellationToken = default)
    {
        var user = await userService.Find(request.UserId, cancellationToken);
        if (user == default)
        {
            return NotFound(nameof(user));
        }

        var school = await schoolService.Find(request.SchoolId, cancellationToken);
        if (school == default)
        {
            return NotFound(nameof(school));
        }
        
        await userService.SetSchoolId(request.UserId, request.SchoolId, cancellationToken);
        return Ok();
    }
}