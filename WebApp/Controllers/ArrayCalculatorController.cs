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

    // Вывод всех элементов массива в одну строку
    [HttpPost]
    [Route("api/v1/array_get-as-string-commas")]
    public ActionResult<string> GetArrayAsStringCommas([FromBody] int[] array)
    {
        return Ok(string.Join(", ", array));
    }

    // Вывести на экран только четные числа
    [HttpPost]
    [Route("api/v1/array_get-even-numbers")]
    public ActionResult<int[]> GetEvenNumbers([FromBody] int[] array)
    {
        var evenNumbers = array.Where(x => x % 2 == 0).ToArray();
        return Ok(evenNumbers);
    }

    // Вывести сумму всех чисел массива
    [HttpPost]
    [Route("api/v1/array_sum")]
    public ActionResult<int> GetArraySum([FromBody] int[] array)
    {
        var sum = array.Sum();
        return Ok(sum);
    }

    // Вывести введенные элементы "задом наперед"
    [HttpPost]
    [Route("api/v1/array_reverse")]
    public ActionResult<int[]> GetArrayReverse([FromBody] int[] array)
    {
        var reversedArray = array.Reverse().ToArray();
        return Ok(reversedArray);
    }

    // Отсортировать массив пузырьком
    [HttpPost]
    [Route("api/v1/array_bubble_sort")]
    public ActionResult<int[]> BubbleSort([FromBody] int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - 1 - i; j++)
                {
                if (array[j] > array[j + 1])
                {
                    var temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
        return Ok(array);
    }

    // Отсортировать массив методом выбора
    [HttpPost]
    [Route("api/v1/array_selection_sort")]
    public ActionResult<int[]> SelectionSort([FromBody] int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }
                var temp = array[minIndex];
                array[minIndex] = array[i];
                array[i] = temp;
        }
        return Ok(array);
    }       
}

   
