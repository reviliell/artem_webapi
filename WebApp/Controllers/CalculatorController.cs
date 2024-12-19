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
    
    [HttpGet]
    [Route("api/v1/multiplication_get-result")]
    public ActionResult<int> GetMultiplicationResult(int number_a, int number_b)
    {
        int result = number_a * number_b;
        return Ok(result);
    }

    [HttpGet]
    [Route("api/v1/exponentiation_get-result")]
    public ActionResult<double> GetExponentiationResult(int number_a, int number_b)
    {
        double result = Math.Pow(number_a, number_b);
        return Ok(result);
    }

    [HttpGet]
    [Route("api/v1/division_two_numbers_remainder_get-results")]
    public ActionResult<int> GetDivisionTwoNumbersRemainder(int number_a, int number_b)
    {
        if (number_b == 0)
        {
            return BadRequest("Error");
        }
        int result = number_a % number_b;
        return Ok(result);
    }

    [HttpGet]
    [Route("api/v1/factorial_get-result")]
    public ActionResult<int> GetFactorialResult(int number)
    {
        if (number < 0) return BadRequest("Error");
        int result = 1;
        for (int i = 1; i <= number; i++)
        {
            result *= i;
        }
        return Ok(result);
    }

    [HttpGet]
    [Route("api/v1/remainder_sorted_get-result")]
    public ActionResult<int> GetRemainderSorted(int B, int N)
    {
        int result = 0;
        for (int i = 0; i <= N; i++)
        {
            result += B % i;
        }
        return Ok(result);
    }

    [HttpGet]
    [Route("api/v1/addition_sorted_get-result")]
    public ActionResult<int> GetAdditionSorted(int N, int M, int P)
    {
        int result = N;
        for (int i = 0; i < P; i++)
        {
            result += M;
        }
        return Ok(result);
    }

    [HttpGet]
    [Route("api/v1/subtraction_sorted_get-result")]
    public ActionResult<int> GetSubtractionSorted(int N, int M, int P)
    {
        int result = N;
        for (int i = 0; i < P; i++)
        {
            result -= M;
        }
        return Ok(result);
    }
    [HttpGet]
    [Route("api/v1/sale_get")]
    public ActionResult<int> GetSale(int originalPrice, int discountPercentage)
    {

        //Это определит сумму скидки на основе процентного соотношения.
        int discountAmount = (discountPercentage / 100) * originalPrice;

        // Скидка будет вычтена из исходной цены, чтобы получить итоговую стоимость со скидкой.
        double discountedPrice = originalPrice - discountAmount;
        return Ok(discountedPrice);
    }
}

   
