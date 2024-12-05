using Application.Services;
using Domain.Models;
using Domain.Parameters;
using Microsoft.AspNetCore.Mvc;
using WebApp.Requests;
using WebApp.Responses;

//метод GET, который на вход принимает цену машины и скидку, а на выход отдает стоимость с учтенной скидкой
namespace WebApp.Controllers;
public class CarController() : Controller
{
    // Метод с названием  GetSaleResult который принимает на вход два числа и отдает на выход данные типа ActionResult<int>.
    // К методу можно обратится по api/v1/sale_get-result
    [HttpGet]
    [Route("api/v1/sale_get-result")]
    public ActionResult<int> GetSaleResult(int price,int  discont)
    {
        int result = price - discont;
        return Ok(result);
    }
}