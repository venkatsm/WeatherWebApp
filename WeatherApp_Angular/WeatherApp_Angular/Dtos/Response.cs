using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp_Angular.Dtos
{
    public class Response<T>
    {
        public bool Success { get; set; }

        public T Result { get; set; }
    }
}
