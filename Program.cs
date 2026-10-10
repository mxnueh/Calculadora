// Manejo de errores con try, catch y finally

bool bucleState = true;

try
{
    while (bucleState)
    {
        // La lista se crea en cada ronda para que no acumule numeros de rondas anteriores
        List<int> number = new();

        // Bienvenida
        Console.WriteLine("\n===== BIENVENIDO A SU CALCULADORA =====");
        Console.WriteLine("""
        PODRAS ELEGIR ENTRE:
        - Operar dos numeros (Suma, Resta, Multiplicacion, Division)
        - Evaluar si un estudiante aprobo o no
        """);

        // Menu principal: elegir que se desea hacer
        int choiceMenu = 0;
        bool validateMenu = true;
        while (validateMenu)
        {
            try
            {
                Console.Write("""

                1. CALCULADORA
                2. EVALUAR ESTUDIANTE
                ELIJE EL NUMERO DE LO QUE DESEAS HACER (eg. 1 PARA CALCULADORA):
                """);
                choiceMenu = int.Parse(Console.ReadLine() ?? "");

                if (choiceMenu < 1 || choiceMenu > 2)
                {
                    Console.WriteLine("ERROR! Debes elegir una opcion entre 1 y 2");
                }
                else
                {
                    validateMenu = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR! Usted ha ingresado informacion invalida");
            }
        }

        if (choiceMenu == 1)
        {
            // ===================== CALCULADORA =====================
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
        }
        else
        {
            // ===================== EVALUAR ESTUDIANTE =====================
            Console.WriteLine("\n=== EVALUACION DE ESTUDIANTE ===");

            // Promedio minimo para aprobar
            int passingGrade = 70;

            // Nombre del estudiante (no puede quedar vacio)
            string? studentName = "";
            while (studentName == null || studentName == "")
            {
                Console.Write("Ingresa el nombre del estudiante: ");
                studentName = Console.ReadLine();

                if (studentName == null || studentName == "")
                {
                    Console.WriteLine("ERROR! Debes ingresar un nombre");
                }
            }

            // Cantidad de notas a ingresar (entre 1 y 6)
            int quantityGrades = 0;
            bool validateQuantity = true;
            while (validateQuantity)
            {
                try
                {
                    Console.Write("Cuantas notas deseas ingresar? (maximo 6): ");
                    quantityGrades = int.Parse(Console.ReadLine() ?? "");

                    if (quantityGrades < 1 || quantityGrades > 6)
                    {
                        Console.WriteLine("ERROR! Debes ingresar entre 1 y 6 notas");
                    }
                    else
                    {
                        validateQuantity = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR! Usted ha ingresado informacion invalida");
                }
            }

            // Cada nota debe estar entre 0 y 100
            while (number.Count < quantityGrades)
            {
                try
                {
                    Console.Write($"Ingresa la nota {number.Count + 1} de {quantityGrades} (0 a 100): ");
                    int recordGrade = int.Parse(Console.ReadLine() ?? "");

                    if (recordGrade < 0 || recordGrade > 100)
                    {
                        Console.WriteLine("ERROR! La nota debe estar entre 0 y 100");
                    }
                    else
                    {
                        number.Add(recordGrade);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR! Usted ha ingresado informacion invalida");
                }
            }

            // Se suman todas las notas para sacar el promedio
            double sumGrades = 0;
            int indexGrade = 0;
            while (indexGrade < number.Count)
            {
                sumGrades = sumGrades + number[indexGrade];
                indexGrade = indexGrade + 1;
            }
            double averageGrades = sumGrades / number.Count;

            Console.WriteLine($"ESTUDIANTE: {studentName}");
            Console.WriteLine($"NOTAS INGRESADAS: {number.Count}");
            Console.WriteLine($"PROMEDIO: {averageGrades:F2}");

            if (averageGrades >= passingGrade)
            {
                Console.WriteLine("RESULTADO: APROBADO");
            }
            else
            {
                Console.WriteLine("RESULTADO: REPROBADO");
                Console.WriteLine($"Le faltaron {passingGrade - averageGrades:F2} puntos de promedio para aprobar (minimo {passingGrade})");
            }
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
