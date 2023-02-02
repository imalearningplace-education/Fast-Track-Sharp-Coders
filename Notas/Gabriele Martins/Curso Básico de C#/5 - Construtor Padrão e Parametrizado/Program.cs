using System;
namespace ConstrutoresDestrutores
{
    class Program
    {
        static void Main(string[] args)
        {
            Carro c1 = new Carro();
            c1.Modelo = "Fusca";
            c1.Portas = 4;
            c1.Preco = 29990;

            Carro c2 = new Carro();
            c2.Modelo = "Opala";
            c2.Portas = 4;
            c2.Preco = 49990;

            Carro c3 = new Carro("Chevete");
            c3.Portas = 2;
            c3.Preco = 32990;

            Carro c4 = new Carro("Monza",4,39990);
        }
    }
    class Carro
    {
        public int Portas { get; set; }
        public double Preco { get; set; }
        public string Modelo { get; set; }

        public Carro()
        {
            Console.WriteLine("Um novo objeto Carro foi criado.");
        }

        public Carro(string modelo) : this()
        {
            this.Modelo = modelo;
        }

        public Carro(string modelo, int portas, double preco) : this(modelo)
        {
            this.Portas=portas;
            this.Preco=preco;
        }
    }
}