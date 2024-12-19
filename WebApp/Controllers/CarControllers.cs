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
    public ActionResult<int> GetSaleResult(int originalPrice,int  discountPercentage)
    {
       //Это определит сумму скидки на основе процентного соотношения.
        int discountAmount = (discountPercentage / 100) * originalPrice;

        // Скидка будет вычтена из исходной цены, чтобы получить итоговую стоимость со скидкой.
        double discountedPrice = originalPrice - discountAmount;
        return Ok(discountedPrice);
    }
    public ActionResult<int> GetSaleBus(int originalPrice, int discountPercentage)
    {

        //Это определит сумму скидки на основе процентного соотношения.
        int discountAmount = (discountPercentage / 100) * originalPrice;

        // Скидка будет вычтена из исходной цены, чтобы получить итоговую стоимость со скидкой.
        double discountedPrice = originalPrice - discountAmount;
        return Ok(discountedPrice);
    }
    public ActionResult<int> GetSaleTruck(int originalPrice, int discountPercentage)
    {

        //Это определит сумму скидки на основе процентного соотношения.
        int discountAmount = (discountPercentage / 100) * originalPrice;

        // Скидка будет вычтена из исходной цены, чтобы получить итоговую стоимость со скидкой.
        double discountedPrice = originalPrice - discountAmount;
        return Ok(discountedPrice);
    }
}