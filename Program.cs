// Manejo de errores con try, catch y finally
bool bucleState = true;

try
{
    while (bucleState)
    {
        // La lista se crea en cada ronda para que no acumule numeros de rondas anteriores
        List<int> number = new();

        // Entrada de datos del usuario y bienvenida
        Console.WriteLine("\n===== BIENVENIDO A SU CALCULADORA =====");
        Console.WriteLine("1. PODRAS INGRESAR DOS NUMEROS DE MANERA SEPARADA");
        Console.WriteLine("""
            2. ELEGIR LA OPCION PARA OPERAR TUS NUMEROS: 
                - Suma 
                - Resta
                - Multiplicacion
                - Division
            """);
        Console.WriteLine("3. OBTENER EL RESULTADO DE TU OPERACION");

        Console.WriteLine("\n=== COMENCEMOS CON LOS NUMEROS ===");

        bool validateFirstInput = true;
        while (validateFirstInput)
        {
            try
            {
                Console.Write("Ingresa el primer numero para comenzar la operacion: ");
                int recordFirstInput = int.Parse(Console.ReadLine() ?? "");

                number.Add(recordFirstInput);
                validateFirstInput = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR! Usted ha ingresado informacion invalida");
            }
        }

        bool validateSecondInput = true;
        while (validateSecondInput)
        {
            try
            {
                Console.Write("Ingresa el segundo numero para comenzar la operacion: ");
                int recordSecondInput = int.Parse(Console.ReadLine() ?? "");

                number.Add(recordSecondInput);
                validateSecondInput = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR! Usted ha ingresado informacion invalida");
            }
        }

        Console.WriteLine("==== BIEN! AHORA VAMOS CON LA OPERACION ====");

        int choiceOperation = 0;
        bool validateOperation = true;
        while (validateOperation)
        {
            try
            {
                Console.Write("""

                    1. SUMA
                    2. RESTA
                    3. MULTIPLICACION
                    4. DIVISION

                ELIJE EL NUMERO DE LA OPERACION QUE DESEAS REALIZAR (eg. 1 PARA SUMA): 
                """);
                choiceOperation = int.Parse(Console.ReadLine() ?? "");

                if (choiceOperation < 1 || choiceOperation > 4)
                {
                    Console.WriteLine("ERROR! Debes elegir una opcion entre 1 y 4");
                }
                else
                {
                    validateOperation = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR! Usted ha ingresado informacion invalida");
            }
        }

        int firstNumber = number[0];
        int secondNumber = number[1];
        double result = 0;

        try
        {
            switch (choiceOperation)
            {
                // SUMA
                case 1:
                    Console.WriteLine("OPERACION SELECCIONADA: SUMA");
                    result = firstNumber + secondNumber;
                    Console.WriteLine($"RESULTADO: {result}");
                    break;

                // RESTA
                case 2:
                    Console.WriteLine("OPERACION SELECCIONADA: RESTA");
                    result = firstNumber - secondNumber;
                    Console.WriteLine($"RESULTADO: {result}");
                    break;

                // MULTIPLICACION
                case 3:
                    Console.WriteLine("OPERACION SELECCIONADA: MULTIPLICACION");
                    result = firstNumber * secondNumber;
                    Console.WriteLine($"RESULTADO: {result}");
                    break;
                
                // DIVISION
                case 4:
                    Console.WriteLine("OPERACION SELECCIONADA: DIVISION");

                    if (secondNumber == 0)
                    {
                        throw new DivideByZeroException();
                    }

                    result = firstNumber / secondNumber;
                    Console.WriteLine($"RESULTADO: {result}");
                    break;

                default:
                    Console.WriteLine("ERROR! Operacion no valida");
                    break;
            }
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("ERROR! No se puede dividir entre cero");
        }

        string? choice = "";
        while (choice != "1" && choice != "2")
        {
            Console.Write("""

                Te gustaria hacer otra operacion?

                    1. Si
                    2. No

                Elije tu respuesta: 
                """);

            choice = Console.ReadLine();

            if (choice != "1" && choice != "2")
            {
                Console.WriteLine("ERROR! Debes elegir 1 o 2");
            }
        }

        if (choice == "2")
        {
            bucleState = false;
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"ERROR INESPERADO: {ex.Message}");
}
finally
{
    // Ahora se ejecuta una sola vez, cuando el programa realmente termina
    Console.WriteLine("Operacion Finalizada");
}