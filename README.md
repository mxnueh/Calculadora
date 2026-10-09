# Calculadora

Calculadora de consola en C# que opera dos números enteros con suma, resta, multiplicación y división.

## 1. Descripción

Programa de consola escrito con *top-level statements*. Pide dos números, la operación a realizar y muestra el resultado; luego pregunta si se desea realizar otra operación. Todo el flujo está protegido con manejo de errores (`try`, `catch` y `finally`).

## 2. Características

- Operaciones: suma, resta, multiplicación y división.
- Validación de entrada: si el usuario escribe algo que no es un número, vuelve a pedirlo.
- Validación del menú: solo acepta opciones del 1 al 4.
- Control de la división entre cero.
- Bucle para repetir operaciones sin reiniciar el programa.

## 3. Tecnologías

- C#
- .NET (consola)

## 4. Requisitos

- [.NET SDK 7](https://dotnet.microsoft.com/download) o superior (el código usa literales de cadena sin formato `"""`).

## 5. Uso

El repositorio contiene solo `Program.cs`. Para ejecutarlo, crea un proyecto de consola y reemplaza su `Program.cs`:

```bash
dotnet new console -n Calculadora
cp Program.cs Calculadora/Program.cs
cd Calculadora
dotnet run
```

Ejemplo de flujo:

```
Ingresa el primer numero para comenzar la operacion: 8
Ingresa el segundo numero para comenzar la operacion: 2
1. SUMA  2. RESTA  3. MULTIPLICACION  4. DIVISION
ELIJE EL NUMERO DE LA OPERACION QUE DESEAS REALIZAR: 4
```

## 6. Limitaciones

- Solo trabaja con números enteros (`int`), por lo que la división es entera.

## 7. Estructura

```
Calculadora/
└── Program.cs
```
