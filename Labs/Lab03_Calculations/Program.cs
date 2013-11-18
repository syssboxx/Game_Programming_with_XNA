
//convert a temperature from Fahrenheit to Celsius and back again

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab03_Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            float originalTemperatureFahrenheit;
            float temperatureCelsius;
            float calculatedTemperatureFahrenheit;

            Console.Write("Enter temperature in Fahrenheit:");
            originalTemperatureFahrenheit = float.Parse(Console.ReadLine());

            temperatureCelsius = ConvertFahrenheitToCelsius(originalTemperatureFahrenheit);
            Console.WriteLine("Temperature in Celsius :{0} F are {1:f1} C", originalTemperatureFahrenheit, temperatureCelsius);

            calculatedTemperatureFahrenheit = ConvertCelsiusToFahrenheit(temperatureCelsius);
            Console.WriteLine("Temperature in Fahrenheit :{0:f1} C are  {1} F", temperatureCelsius, calculatedTemperatureFahrenheit);


        }

        private static float ConvertCelsiusToFahrenheit(float celsius)
        {
            float hahrenheit=((celsius*9)/5)+32;
            return hahrenheit;
        }

        private static float ConvertFahrenheitToCelsius(float fahrenheit)
        {
            float celsius=((fahrenheit-32)/9)*5;
            return celsius;
        }
    }
}
