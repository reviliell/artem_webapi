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
    [HttpGet]
    [Route("api/v1/get_sale_Bus")]
    public ActionResult<int> GetSaleBus(int originalPrice, int discountPercentage)
    {

        //Это определит сумму скидки на основе процентного соотношения.
        int discountAmount = (discountPercentage / 100) * originalPrice;

        // Скидка будет вычтена из исходной цены, чтобы получить итоговую стоимость со скидкой.
        double discountedPrice = originalPrice - discountAmount;
        return Ok(discountedPrice);
    }
    [HttpGet]
    [Route("api/v1/get_sale_Truck")]
    public ActionResult<int> GetSaleTruck(int originalPrice, int discountPercentage)
    {

        //Это определит сумму скидки на основе процентного соотношения.
        int discountAmount = (discountPercentage / 100) * originalPrice;

        // Скидка будет вычтена из исходной цены, чтобы получить итоговую стоимость со скидкой.
        double discountedPrice = originalPrice - discountAmount;
        return Ok(discountedPrice);
    }
    //- дописать метод car_get. Объявить вторую переменную и в нее положить вторую машину со своими значениями полей. 
    //Добавить входной параметр int, если ввели четное число - ты возвращаешь машину первой переменной, если нечетное - то машину второй переменной

}