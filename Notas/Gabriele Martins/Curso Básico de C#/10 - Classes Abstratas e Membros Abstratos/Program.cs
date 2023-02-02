using System;
namespace MembrosClassesAbstratas{
    public class Program{
        static void Main(string[] args)
        {
            Carro c1=new Carro(1200);
            Aviao a1=new Aviao(3000);
            ViajarParaCalifornia(a1);
        }
        static void ViajarParaCalifornia(Veiculo v)
        {
            v.Mover(10000);
        }
    }
    public abstract class Veiculo{
        public double Peso { get; set; }
        public Veiculo(double peso){
            this.Peso=peso;
            Console.WriteLine("Um novo objeto Veiculo foi construído.");
        }
        ~Veiculo(){
            Console.WriteLine("Um objeto Veiculo foi destruído.");
        }
        public abstract void Mover(double distancia);
    }
    public sealed class Carro : Veiculo{
        public Carro(double peso) : base(peso)
        {
            Console.WriteLine("Um novo objeto Carro foi construído.");
        }
        public override void Mover(double distancia){
            Console.WriteLine("Um objeto Carro se moveu por {0} metros.",distancia);
        }
    }
    public sealed class Aviao : Veiculo{
        public Aviao(double peso) : base(peso)
        {
            Console.WriteLine("Um novo objeto Aviao foi construído.");
        }
        public override void Mover(double distancia){
            Console.WriteLine("Um objeto Aviao se moveu por {0} metros.",distancia);
        }
    }
}