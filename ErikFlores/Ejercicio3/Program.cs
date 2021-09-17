using ConsoleHelper;
using System;
using System.Threading;

namespace Ejercicio3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
               Realizar el algoritmo que permita el ingreso de 10 bolsas de alimento para
               mascotas, con los kilos (validar entre 0 y 500) , sabor validar (carne vegetales pollo) e informar por consola:
               a. El promedio de los kilos totales.
               b. La bolsa más liviana y su sabor
               c. La cantidad de bolsas sabor carne y el promedio de kilos de sabor carne
              
            */
            //Se facilitaria si se utiliza una clase comidaParaMascota para almacenar los kg y el sabor.

            int amountBagFood = 10;
            int amountBagMeat = 0;

            double kg = 0;
            double kgTotal = 0;
            double kgTotalFlavorMeat = 0;
            double kgBagMin = 500;

            string flavor = "";
            string flavorLight = "";
            

            for (int amount = 1; amount <= amountBagFood; amount++)
            {
                ConsoleHelpers.WrileYellow($"Compra Nro {amount}");
                flavor = getFlavor();
                kg = getKilogram();

                kgTotal += kg;

                if (kg < kgBagMin)
                {
                    kgBagMin = kg;
                    flavorLight = flavor;
                }
                    

                if (flavor == "CARNE")
                {
                    amountBagMeat++;
                    kgTotalFlavorMeat += kg;
                }
            }

            ConsoleHelpers.WrileYellow($"El promedio de todos los kilos totales es de : {calculateAverage(kgTotal, amountBagFood)} \n" +
                                       $"La bolsa mas liviana es : {kgBagMin} y su sabor es de : {flavorLight} \n" +
                                       $"La cantidad de bolsas sabor a carne es de : {amountBagMeat} y su promedio de kilos es : {calculateAverage(kgTotalFlavorMeat, amountBagMeat)} \n");



        }

        static bool kilogramValidation(double kg) => (kg > 0 && kg < 500);
        static bool flavorValidation(string flavor) => (flavor == "CARNE" || flavor == "VEGETAL" || flavor == "POLLO");
        static double getKilogram()
        {
            string readline;
            double kg = 0;
            bool isValidation = false;

            while (!isValidation)
            {
                ConsoleHelpers.WrileYellow("Ingrese la cantidad de Kilogramos que desea");
                readline = Console.ReadLine();
                if (double.TryParse(readline, out kg))
                {
                    if (kilogramValidation(kg))
                        isValidation = true;
                    else
                    {
                        ConsoleHelpers.WrileRed("ERRO!! --> INGRESÓ UN PESO FUERA DE RANGO");
                        clearConsole();
                    }
                        
                }
                else
                {
                    ConsoleHelpers.WrileRed("ERROR!! --> NO INGRESÓ UN NÚMERO");
                    
                }
            }

            return kg;
        }
        static string getFlavor()
        {
            string flavor = "";
            bool isValidation = false;
            while (!isValidation)
            {
                ConsoleHelpers.WrileYellow("Ingresee el sabor : CARNE-VEGETAL-POLLO");
                flavor = Console.ReadLine();
                if (flavorValidation(flavor.ToUpper()))
                    isValidation = true;
                else
                {
                    ConsoleHelpers.WrileRed("ERROR!! --> NO INGRESÓ UN SABOR CORRECTO");
                    clearConsole();
                }
            }

            return flavor.ToUpper();
        }

        static double calculateAverage(double kgTotal, int amountBag) => (kgTotal / amountBag);
        static void clearConsole()
        {
            Thread.Sleep(1500);
            Console.Clear();
        }

    }
}
