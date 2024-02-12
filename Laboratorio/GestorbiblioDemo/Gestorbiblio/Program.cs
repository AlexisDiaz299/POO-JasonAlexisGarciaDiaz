using System;
using System.Collections.Generic;

// Clase base 
public abstract class ObraLiteraria
{
    public string Titulo { get; set; }
    public string Autor { get; set; }

    // Constructor 
    public ObraLiteraria(string titulo, string autor)
    {
        Titulo = titulo;
        Autor = autor;
    }

    // Método abstracto 
    public abstract void MostrarInfo();
}

// Clase derivada 
public class Libro : ObraLiteraria
{
    public int Paginas { get; set; }

    // Constructor 
    public Libro(string titulo, string autor, int paginas) : base(titulo, autor)
    {
        Paginas = paginas;
    }

    // Método 
    public override void MostrarInfo()
    {
        Console.WriteLine($"Libro: {Titulo}, Autor: {Autor}, Paginas: {Paginas}");
    }
}

// Clase Prestamo
public class Prestamo
{
    public Libro LibroPrestado { get; set; }
    public DateTime FechaPrestamo { get; set; }

    // Constructor 
    public Prestamo(Libro libro, DateTime fechaPrestamo)
    {
        LibroPrestado = libro;
        FechaPrestamo = fechaPrestamo;
    }

    // Método estático 
    public static void RenovarPrestamo(Prestamo prestamo, int dias)
    {
        prestamo.FechaPrestamo = prestamo.FechaPrestamo.AddDays(dias);
        Console.WriteLine($"Prestamo renovado. Nueva fecha de devolucion: {prestamo.FechaPrestamo}");
    }
}

class Program
{
    static void Main(string[] args)
    {

        Libro libro1 = new Libro("Cuentos de barro", "Salvador Salazar Arrue", 122);
        libro1.MostrarInfo();

        Prestamo prestamo1 = new Prestamo(libro1, DateTime.Now);
        Console.WriteLine($"Fecha de prestamo: {prestamo1.FechaPrestamo}");

        Prestamo.RenovarPrestamo(prestamo1, 7);

    }
}
