using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _97NorAja_TestProject.Uppgift4
{
    public interface IWeatherClient
    {
        Task<string> GetCurrentWeatherAsync(string city);
    }
}
