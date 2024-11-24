using Application.Services;
using Domain.Models;
using Domain.Parameters;
using Microsoft.AspNetCore.Mvc;
using WebApp.Requests;
using WebApp.Responses;

namespace WebApp.Controllers;

public class CalculatorController() : Controller
{
    // Метод с названием  GetSummResult который принимает на вход два числа и отдает на выход данные типа ActionResult<int>.
    // К методу можно обратится по api/v1/summa_get
    [HttpGet]
    [Route("api/v1/summa_get-result")]
    public ActionResult<int> GetSummResult(int number_a,int  number_b)
    {
        int result = number_a + number_b;
        return Ok(result);
    }
  
    // Метод с нащванием GetDivisionResult принимает на вход два числа и отдает данные типа ActionResult<int>.
    // К методу можно обратится по api/v1/division_get       
    [HttpGet]
    [Route("api/v1/division_get-result")]
    public ActionResult<int> GetDivisionResult(int number_a,int number_b)
    {
         int result = number_a / number_b;
         if (number_b==0)
         {
            return BadRequest("Error");
         }
        return Ok(result);
    }

    // Метод с нащванием GetExponentiationResult принимает на вход два числа и отдает данные типа ActionResult<int>.
    // К методу можно обратится по api/v1/GetExponentiationResult
    [HttpGet]
    [Route("api/v1/exponentiation_get-result")]
    public ActionResult<int> GetExponentiationResult(int number_a,int number_b)
    {
         int result = number_a / number_b;
         if (number_b==0)
         {
            return BadRequest("Error");
         }
        return Ok(result);
    }



}

   
