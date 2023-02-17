using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll(int? sortStrategy)
        {
            if(sortStrategy == 0)
            {
                return Ok(Summaries);
            }
            if (sortStrategy == 1)
            {
                var selectedList = Summaries.OrderByDescending(u => u);
                selectedList.Reverse();
                return Ok(selectedList);
            }
            if (sortStrategy == -1)
            {
                var selectedList = Summaries.OrderByDescending(u => u);
                return Ok(selectedList);
            }
            else 
            {
                return BadRequest("Некорректное значение параметра sortStrategy");
            }

        }
        [HttpGet("{index}")]
        public string GetIndexWord(int index)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return "Такой индекс неверный";
            }

            return Summaries[index];
        }
        [HttpPost]
        public IActionResult Add(string name)
        {
            if(name == null)
            {
                return BadRequest("Пустое поле");
            }

            Summaries.Add(name);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(int index, string name)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Такой индекс неверный");
            }

            if (name == null)
            {
                return BadRequest("Пустое поле");
            }

            Summaries[index] = name;
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Такой индекс неверный");
            }

            Summaries.RemoveAt(index);
            return Ok();
        }

        [HttpGet("find-by-name")]
        public string FindByName(string name)
        {
            int count = 0;
           for(int i = 0; i < Summaries.Count; i++)
            {
                if (Summaries[i] == name)
                {
                    count++;
                }
            }

            return Convert.ToString(count);
        }

    }
}
