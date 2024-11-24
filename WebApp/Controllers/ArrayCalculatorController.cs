using Application.Services;
using Domain.Models;
using Domain.Parameters;
using Microsoft.AspNetCore.Mvc;
using WebApp.Requests;
using WebApp.Responses;

namespace WebApp.Controllers;

public class ArrayCalculatorController() : Controller
{
    //Вывод всех элементов массива в одну строку
    // Метод с названием GetArrayAsString  который принимает на вход массив и отдает на выход данные типа ActionResult<string>.
    // К методу можно обратится по api/v1/array_get-as-string
    
    [HttpPost]
    [Route("api/v1/array_get-as-string")]
        public ActionResult<string> GetArrayAsString([FromBody]int[] array)
    {
        return Ok("result");
    }

}

   
