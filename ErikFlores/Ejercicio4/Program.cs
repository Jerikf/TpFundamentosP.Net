using ConsoleHelper;
using System;
using System.Threading;

namespace Ejercicio4
{
    class Program
    {
        static void Main(string[] args)
        {
            /*                  -----------------ENUNCIADO------------------------
                Realizar el algoritmo que permita iterar el ingreso de dos datos de un vehiculo, un
                color (rojo verde o amarillo) y un valor entre 0 y 10000 hasta que el usuario quiera e
                informar al terminar el ingreso por consola:
                a. La cantidad de rojos
                b. La cantidad de rojos con precio mayor a 5000
                c. La cantidad de vehículos con precio inferior a 5000
                d. El promedio de todos los vehículos ingresados.
                e. El más caro y su color. 
             */

            string color = "";
            int valor = 0;
            bool exit = false;
            string readlineExit = "";

            int amountRed = 0;
            int amountRedPriceMaxA = 0;
            int amountVehiclePriceMinA = 0;

            double sumParcialVehicle = 0;
            int amountVehicleInput = 0;

            double maxPriceVehicle = 0;
            string colorMaxPriceVehicle = "";

            while (!exit)
            {
                color = getColor();
                valor = getValor();

                amountVehicleInput++;
                sumParcialVehicle += valor;

                if (valor < 5000)
                    amountVehiclePriceMinA++;

                if(color == "ROJO")
                {
                    amountRed++;
                    if (valor > 5000)
                        amountRedPriceMaxA++;
                }

                if( valor > maxPriceVehicle)
                {
                    maxPriceVehicle = valor;
                    colorMaxPriceVehicle = color;
                }

                readlineExit = getExit();
                if (readlineExit == "SI")
                    exit = true;
                clearConsole();
            }

            ConsoleHelpers.WrileYellow($"La cantidad de Vehiculos Rojos es : {amountRed} \n" +
                                       $"La cantidad de Vehiculos Rojos con Precio mayor a 5000 es : {amountRedPriceMaxA} \n" +
                                       $"La cantidad de Vehiculos con Precios menor a 5000 es : {amountVehiclePriceMinA} \n" +
                                       $"El promedio de todos los Vehiculos es : {average(sumParcialVehicle, amountVehicleInput)} \n" +
                                       $"El Vehiculo mas caro  es de ${maxPriceVehicle} y su color es {colorMaxPriceVehicle} \n ");



        }
        static bool exitValidation(string exit) => (exit == "SI" || exit == "NO");
        static bool colorValidation(string color) => (color == "ROJO" || color == "VERDE" || color == "AMARILLO");
        static bool valorValidation(int number) => (number > 0 && number < 10000);
        static double average(double sumParcial, int cantTotal) => sumParcial / cantTotal;

        static string getColor()
        {
            string color = "";
            bool isValidation = false;
            while (!isValidation)
            {
                ConsoleHelpers.WrileYellow("Ingrese el Color : ROJO-VERDE-AMARILLO");
                color = Console.ReadLine();
                if (colorValidation(color.ToUpper()))
                    isValidation = true;
                else
                {
                    clearConsole();
                    ConsoleHelpers.WrileRed("ERROR!! --> INGRESE UN COLOR CORRECTO");
                }
            }
            return color.ToUpper();
        }
        static int getValor()
        {
            string readline = "";
            int valor = 0;
            bool isValidation = false;
            while (!isValidation)
            {
                ConsoleHelpers.WrileYellow("Ingrese un valor entre 0-10000");
                readline = Console.ReadLine();
                if(int.TryParse(readline, out valor))
                {
                    if (valorValidation(valor))
                        isValidation = true;
                    else
                    {
                        clearConsole();
                        ConsoleHelpers.WrileRed("ERROR!! --> INGRESO UN VALOR FUER DE RANGO");
                    }
                }
                else
                {
                    clearConsole();
                    ConsoleHelpers.WrileRed("ERROR!! --> INGRESO UN FORMATO INVÁLIDO");
                }
            }
            return valor;
        }

        static string getExit()
        {
            string exit = "";
            bool isValidation = false;

            while (!isValidation)
            {
                ConsoleHelpers.WrileYellow("Desea Salir?, marque SI-NO");
                exit = Console.ReadLine();
                if (exitValidation(exit.ToUpper()))
                    isValidation = true;
                else
                {
                    clearConsole();
                    ConsoleHelpers.WrileRed("ERROR! --> INGRESÓ UNA RESPUESTA INCORRECTA.");
                }
            }
            return exit.ToUpper();
        }

        static void clearConsole()
        {
            Thread.Sleep(200);
            Console.Clear();
        }
    }
}
