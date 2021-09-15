using ConsoleHelper;
using System;

namespace Ejercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*                       ENUNCIADO
             1. Pedir dos números por consola y mostrar el resultado:
                a. Si son iguales muestro el cuadrado del número.
                b. Si el primero es divisible por el segundo, los resto, de lo contrario muestro
                solo el resto.
                c. si el resto es mayor a 3(tres ) informar por consola.
            */

            int num, num2;

           
            num = getNumber();

            num2 = getNumber();

            if (num == num2)
                ConsoleHelpers.WrileYellow($"El cuadrado es {squareNum(num)}");
            if(num2 != 0)
            {
                if (isDivisible(num, num2))
                    ConsoleHelpers.WrileYellow($"la diferencia es {restar(num, num2)}");
                else
                    ConsoleHelpers.WrileYellow($"El resto es :  {getRest(num, num2)}");

                if (getRest(num, num2) > 3)
                    ConsoleHelpers.WrileYellow($"El resto de {num} divido {num2} es Mayor a 3 ");

            }
            else
            {
                ConsoleHelpers.WrileYellow("NO SE PUEDE DIVIDIR POR CERO");
            }
            

        }
        static void askNum()
        {
            ConsoleHelpers.WrileYellow("Ingrese un número");
        }

        static int squareNum(int num) => (num*num);

        static int restar(int num, int num2) => num - num2;


        static bool isDivisible(int num, int num2) => (getRest(num, num2) == 0);

        static int getRest(int num, int num2) => num % num2;

        //Devuelve el número validado
        static int getNumber()
        {
            string readline;
            int number;
            do
            {
                askNum();
                readline = Console.ReadLine();

            } while (!Int32.TryParse(readline, out number));
            return number;
        }

    }
}
