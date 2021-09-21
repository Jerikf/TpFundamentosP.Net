using ConsoleHelper;
using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace Ejercicio5
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Realizar el algoritmo que permita ingresar el nombre de un estudiante, la edad
            (validar) , el sexo (validar) y la nota del final (validar) hasta que el usuario quiera e
            informar al terminar el ingreso por consola:
            a. La cantidad de varones aprobados
            b. El promedio de notas de los menores de edad
            c. El promedio de notas de los adolescentes
            d. El promedio de la notas de los mayores
            e. El promedio de notas por sexo           
            */

            /*
             Como no precisan la consiga de la edad de un adolescente, tomaremos que un adolescente  es de 10 a 17 años(ambos incluidos)
            Como piden validar la edad de un estudiante, asumiremos que un estudiante como mínimo tiene una edad de 6años
            (que es cuando pueden entrar al primer año de primaria) y la edad final de un estudiante
            es 50 años.
            Además se considera la nota mínima para aprobar es de 5.
            Un mayor de edad se considera a partir de los 18 años.
             * 
             */
            const int APROBADO = 5;
            const int MAYOR_DE_EDAD = 18;
            const int MIN_EDAD_ADOLESCENTE = 10;
            const int MAX_EDAD_ADOLESCENTE = 17;

            string name = "";
            string sex = "";
            int age = 0;
            float finalNota = 0;

            int countTotalStudent = 0;
            int countMaleApproved = 0;

            int countMinor = 0;
            int countAdolescent = 0;
            int countOlder = 0;
            int countMale = 0;
            int countFemale = 0;

            
            float sumTotalNotaMinor = 0;
            float sumTotalNotaAdolescent = 0;
            float sumTotalNotaOlder = 0;
            float sumTotalNotaMale = 0;
            float sumTotalNotaFemale = 0;



            bool exit = false;
            string readlineExit = "";

            while (!exit)
            {
                name = getName();
                sex = getSexStudent();
                age = getAgeStudent();
                finalNota = getNotaFinal();

                countTotalStudent++;

                if(sex == "M")
                {
                    //para calcular cuando es solo hombre
                    countMale++;
                    sumTotalNotaMale += finalNota;

                    //para contar cuantos hombres aprobaron
                    if (finalNota >= APROBADO)
                        countMaleApproved++;
                }
                else
                {//Si el sexo es mujer
                    countFemale++;
                    sumTotalNotaFemale += finalNota;
                }


                if(age < MAYOR_DE_EDAD)
                {
                    countMinor++;
                    sumTotalNotaMinor += finalNota;
                }
                else
                {//En caso sea mayor de edad!
                    countOlder++;
                    sumTotalNotaOlder += finalNota;
                }

                if(age >= MIN_EDAD_ADOLESCENTE && age <= MAX_EDAD_ADOLESCENTE)
                {
                    countAdolescent++;
                    sumTotalNotaAdolescent += finalNota;
                }

                readlineExit = getExit();
                if (readlineExit == "SI")
                    exit = true;

                Console.Clear();
                


            }

            ConsoleHelpers.WrileYellow($"Se ingresaron {countTotalStudent} estudiantes de los cuales : \n" +
                                       $"{countMale} son HOMBRES y {countFemale} son MUJERES \n" +
                                       $"La cantidad de Hombres aprobados son {countMaleApproved} \n" +
                                       $"El Promedio de notas de los menores de edad es : {averageCalculate(sumTotalNotaMinor, countMinor)} \n" +
                                       $"El promedio de notas de los adolescentes es : {averageCalculate(sumTotalNotaAdolescent, countAdolescent)} \n" +
                                       $"El promedio de la notas de los mayores es : {averageCalculate(sumTotalNotaOlder, countOlder)} \n" +
                                       $"El promedio de notas de los Hombres es : {averageCalculate(sumTotalNotaMale, countMale)} \n" +
                                       $"El promedio de notas de las Mujeres es : {averageCalculate(sumTotalNotaFemale, countFemale)} \n");

        }

        static bool exitValidation(string exit) => (exit == "SI" || exit == "NO");
        static bool notaFinalValidation(float nota) => (nota >= 0 && nota <= 10);
        static bool ageStudentValidation(int age) => (age > 5 && age < 51);
        static bool sexValidation(string sex) => (sex == "M" || sex == "F");
        //Si el nombre ingresado contiene algún número o algún caracter especial, me devolverá false.
        //Solo nombre, no permite espacios, por ende no se le puede poner apellido o 2do nombre.
        static bool nameValidation(string name) => (!Regex.IsMatch(name, @"[0-9]|\W"));

        //Devuelve el promedio si la cantidad es distinto de 0, sino devuelve 0
        //esto lo hago porque si solo se ingresa un dato de un estudiante y es varon o mujer , luego uno de los dos géneros o 
        // si es adolescente o mayor se quedará con dato vació entonces al mandar dividir la sumaTotal(en este caso no tendrían y sería 09 
        // y mandar la cantidad que también sería cero entonces devolveria NaN para esto lo soluciono de esta manera.
        static float averageCalculate(float sumTotal, int count)
        {
            float result = 0;
            if (count == 0)
                result = 0;
            else
                result = sumTotal / count;
            return result;
        }

        static string getName()
        {
            string name = "";
            bool isValidation = false;
            while (!isValidation)
            {
                ConsoleHelpers.WrileYellow("Ingrese el Nombre");
                name = Console.ReadLine();
                if (nameValidation(name))
                    isValidation = true;
                else
                {
                    ConsoleHelpers.WrileRed("Error!! --> Ingreso un dato no válido");
                    clearConsole();
                }
            }
            return name;
        }
        static int getAgeStudent()
        {
            string readline = "";
            int age = 0;
            bool isValidation = false;

            while (!isValidation)
            {
                ConsoleHelpers.WrileYellow("Ingrese la edad del estudiante");
                readline = Console.ReadLine();
                if(int.TryParse(readline, out age))
                {
                    if (ageStudentValidation(age))
                        isValidation = true;
                    else
                    {
                        ConsoleHelpers.WrileRed("ERROR!! --> INGRESÓ LA EDAD DEL ESTUDIANTE INCORRECTO");
                        clearConsole();
                    }
                }
                else
                {
                    ConsoleHelpers.WrileRed("ERROR!! --> NO INGRESÓ UN FORMATO DE EDAD VÁLIDO");
                    clearConsole();
                }
            }
            return age;
        }
        static string getSexStudent()
        {
            string sex = "";
            bool isValidation = false;
            while (!isValidation)
            {

                ConsoleHelpers.WrileYellow("Ingrese el sexo del estudiante : M-F");
                sex = Console.ReadLine();
                if (sexValidation(sex.ToUpper()))
                    isValidation = true;
                else
                {
                    ConsoleHelpers.WrileRed("ERRO! --> NO INGRESÓ UN SEXO CORRECTO");
                    clearConsole();
                }
            }
            return sex.ToUpper();
        } 
        static float getNotaFinal()
        {
            string readline = "";
            float notaFinal = 0;
            bool isValidation = false;
            while (!isValidation)
            {
                ConsoleHelpers.WrileYellow("Ingrese la nota Final del estudiante: 0-10");
                readline = Console.ReadLine();
                if(float.TryParse(readline, out notaFinal))
                {
                    if (notaFinalValidation(notaFinal))
                        isValidation = true;
                    else
                    {
                        ConsoleHelpers.WrileRed("ERROR! --> INGRESÓ UNA NOTA FUERA DEL RANGO [0-10]");
                        clearConsole();
                    }
                }
                else
                {
                    ConsoleHelpers.WrileRed("ERROR! --> INGRESÓ UN FORMATO DE NOTA NO VÁLIDA");
                    clearConsole();
                }
            }
            return notaFinal;
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
                    ConsoleHelpers.WrileRed("ERROR! --> INGRESÓ UNA RESPUESTA INCORRECTA.");
                    clearConsole();
                    
                }
            }
            return exit.ToUpper();
        }

        static void clearConsole()
        {
            Thread.Sleep(1500);
            Console.Clear();
        }

        //----------------------- ^^; ------------චᆽච---------------------------
    }
}

    