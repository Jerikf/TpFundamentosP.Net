using System;
using System.Text.RegularExpressions;
using System.Threading;
using ConsoleHelper;
namespace Ejercicio2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*               ----------- Enunciado------------
                Una empresa de viajes le solicita ingresar que continente le gustaría visitar y la
                cantidad de días , la oferta dice que por día se cobra $100 , que se puede pagar de
                todas las maneras:
                a.Crear un método que valide continentes: recibe un continente y retorna true
                si se trata de un continente válido(América, Asia, Europa, Africa, Oceanía).
                Crear un método que valide forma de pago: recibe la forma de pago y retorna
                true si se trata de una forma de pago válido(Débito, Crédito, Efectivo,
                Mercado Pago, Cheque, Leliq)
                b.Si es América tiene un 15 % de descuento y si además paga por débito se le
                agrega un 10 % más de descuento
                c.Si es África u Oceanía tiene un 30 % de descuento y si además paga por
                mercadoPago o efectivo se le agrega un 15 % más de descuento
                d.Si es Europa tiene un 20 % de descuento y si además paga por débito se le
                agrega un 15 % , por mercadoPago un 10 % y cualquier otro medio 5 %
                e.cualquier otro continente tiene un recargo del 20 %
                f.en cualquier continente, si paga con cheque, se recarga un 15 % de
                impuesto al cheque
            */

            const int PRICEDIA = 100;
            string continent = getContinent();
            string payment = getPayment();
            int cantDias = getCantDias();
            int discount = 0;
            int increase = 0;

            if (continent == "AMERICA")
            {
                if (payment == "DEBITO")
                    discount += 10;
                if (payment == "CHEQUE")
                    increase += 15;
                discount += 15;
            }
            else if (continent == "AFRICA" || continent == "OCEANIA")
            {
                if (payment == "MERCADO PAGO" || payment == "EFECTIVO")
                    discount += 15;
                if (payment == "CHEQUE")
                    increase += 15;
                discount += 30;
            }
            else if (continent == "EUROPA")
            {
                //item d con f se contradice, preguntar. ya que cualquier medio de pago execpto debito-MP del continente de europa hay un descuento del 5% mientra que cheque pertenece 
                //a otro medio de pago entonces sería un descuento del 5% pero el item f dice que caulquier pago con cheque es una recarga del 15%, tnedrías que poner la diferencia? 
                // resuelvo a base de mi interpretacion, donde cheque se respeta con el aumento del 15% mientras que cualquiera que no sea debido-mp-cheque hay descuento del 5%
                if (payment == "DEBITO")
                    discount += 15;
                else if (payment == "MERCADO PAGO")
                    discount += 10;
                else if (payment == "CHEQUE")
                    increase += 15;
                else
                    discount += 5;
                discount += 20;
            }
            else
            {
                if (payment == "CHEQUE")
                    increase += 15;
                increase += 20;
            }

            clearConsole();
            
            ConsoleHelpers.WrileYellow($"La cantidad de días seleccionado es de : {cantDias}\n" +
                              $"El Costo por días es de ${PRICEDIA} Pesos \n" +
                              $"El Precio es de $. {getPriceParcial(PRICEDIA, cantDias)} pesos \n" +
                              $"Tiene un {((discount - increase >= 0 )? "Descuento" : "Incremento")} del {Math.Abs(discount - increase)}% \n" +
                              $"El precio total a pagar es de : ${getPriceTotal(PRICEDIA, cantDias, discount, increase)} Pesos \n");
        }

        static bool continentValitadtion(string continent) => (continent == "ASIA" || continent == "EUROPA" || continent == "AFRICA" || continent == "OCEANIA" || continent == "AMERICA");

        static bool paymentValidation(string payment) => (payment == "DEBITO" || payment == "CREDITO" || payment == "EFECTIVO" || payment == "MERCADO PAGO" || payment == "CHEQUE" || payment == "LELIQ");

        static string getContinent()
        {
            string continent = "";
            bool isCorrect = false;
            while (!isCorrect)
            {
                ConsoleHelpers.WrileYellow("Ingrese el Continente (AMERICA-ASIA-EUROPA-AFRICA-OCEANIA");
                continent = Console.ReadLine();
                if (continentValitadtion(continent.ToUpper()))
                    isCorrect = true;
                else
                {
                    ConsoleHelpers.WrileRed("ERROR!, INGRESÓ UN CONTINENTE INCORRECTO");
                    clearConsole();
                }
            }


            return continent.ToUpper();
        }


        static string getPayment()
        {
            string payment = "";
            bool isCorrect = false;
            while (!isCorrect)
            {
                ConsoleHelpers.WrileYellow("Ingrese el Método de pago (DEBITO-CREDITO-EFECTIVO-MERCADO PAGO-CHEQUE-LELIQ)");
                payment = Console.ReadLine();
                if (paymentValidation(payment.ToUpper()))
                    isCorrect = true;
                else
                {
                    ConsoleHelpers.WrileRed("ERROR!, INGRESÓ UN MÉTODO DE PAGO INCORRECTO");
                    clearConsole();
                }

            }
            return payment.ToUpper();
        }


        static int getCantDias()
        {
            string readline;
            int cantDias = 0;
            bool numbCorrect = false;

            while (!numbCorrect)
            {
                ConsoleHelpers.WrileYellow("Ingrese la cantidad de días que quiere Viajar (Como mínimo 1 día para el viaje) ");
                readline = Console.ReadLine();
                if (Int32.TryParse(readline, out cantDias))
                {
                    if (cantDias > 0)
                        numbCorrect = true;
                    else
                    {
                        ConsoleHelpers.WrileRed("ERROR! --> DEBE INGRESAR UNA CANTIDAD DE DÍAS MAYOR A 0");
                        clearConsole();
                    }
                        
                }
                else
                {
                    ConsoleHelpers.WrileRed("ERROR! --> FORMATO INVÁLIDO , DEBE INGRESAR UN NÚMERO");
                    clearConsole();
                }
               
            }
            return cantDias;
        }

        static void clearConsole()
        {
            Thread.Sleep(1500);
            Console.Clear();
        }

        static double getPriceTotal(int priceDia, int cantDias, int discount, int increase)
        {
            double priceTotal = 0;
            double priceParcial = getPriceParcial(priceDia, cantDias);
            int cantPercentage = discount - increase;

            //Significa que tengo que descontar 
            if (cantPercentage > 0)
                priceTotal = priceParcial - ((cantPercentage * priceParcial) / 100);
            else if (cantPercentage < 0)
                priceTotal = priceParcial + ((Math.Abs(cantPercentage) * priceParcial) / 100);
            else
                priceTotal = priceParcial;
            return priceTotal;
        }

        static double getPriceParcial(int priceDia, int cantDias) => priceDia * cantDias;
    }
}
