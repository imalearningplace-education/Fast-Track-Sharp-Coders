using System;
using System.Collections.Generic;
namespace SobrescritaPolimorfismo{
    class Program{
        static List<Veiculo> veiculos=new List<Veiculo>();
        static Random random=new Random();
        static void Main(string[] args)
        {
            //não é possível instanciar a classe Veiculo, pois é abstrata
            //Veiculo v1=new Veiculo(1000, new DateTime(25,10,2000));
            // Veiculo v2=new Carro(1100,DateTime.Now.AddDays(-600));
            // Veiculo v3=new Onibus(6000,DateTime.Now.AddDays(-5800));

            // v2.Abastecer(40);
            // v3.Abastecer(120);

            // v2.Mover(30);
            // v3.Mover(100);

            // v2.Frear();
            // v3.Frear();

            CriarVeiculosAleatorios();
            foreach(var v in veiculos){
                Console.WriteLine("-----------------------------");
                Console.WriteLine(v.Tipo);
                v.Abastecer(random.Next(10,60));
                v.Mover(random.Next(10,200));
                v.Frear();
            }
            Console.WriteLine("-----------------------------");
        }
        static void CriarVeiculosAleatorios(){
            for(int i=0; i<10; i++){
                if(random.Next()%2==0){
                    veiculos.Add(new Carro(random.Next(800,1400),DateTime.Now.Date.AddDays(-random.Next(30,3600))));
                }
                else{
                    veiculos.Add(new Onibus(random.Next(3000,12000),DateTime.Now.Date.AddDays(-random.Next(30,3600))));
                }
            }
        }
    }
    public abstract class Veiculo{
        public int PesoKg { get; set; }
        public DateTime DataFabricacao { get; set; }
        public double QuantidadeCombustivel { get; set; }
        public string Tipo { get{ return this.GetType().Name; } }
        public abstract int Capacidade { get; set; }
        public abstract void Abastecer(double quantidadeLitros);
        public abstract void Mover(double distanciaKm);
        public virtual void Frear(){
            Console.WriteLine("Acionando os freios...Parou!");
        }
        public Veiculo(int pesoKg, DateTime dataFabricacao){
            this.PesoKg=pesoKg;
            this.DataFabricacao=dataFabricacao;
            Console.WriteLine("Um novo objeto do tipo Veiculo foi criado.");
        }
    }
    public class Carro : Veiculo{
        private int capacidade;
        public override int Capacidade 
        { 
            get{ return capacidade; } 
            set{
                if((value>=2) && (value<=7)){
                    capacidade=value;
                }
                else{
                    throw new Exception("O carro pode ter capacidade de 2 a 7 pessoas.");
                }
            } 
        }
        public int PotenciaCv { get; set; }
        public override void Abastecer(double quantidadeLitros)
        {
            this.QuantidadeCombustivel+=quantidadeLitros;
            Console.WriteLine("Carro abastecido com {0} litros de gasolina.",quantidadeLitros);
        }
        public override void Mover(double distanciaKm)
        {
            if(this.QuantidadeCombustivel>(distanciaKm/10)){
                this.QuantidadeCombustivel-=(distanciaKm/10);
                Console.WriteLine("O carro se moveu por {0} Km.",distanciaKm);
            }
            else{
                Console.WriteLine("Não há combustível para percorrer a distância informada.");
            }
        }
        public override void Frear()
        {
            Console.WriteLine("Acionando os freios ABS...Parou!");
        }
        public Carro(int pesoKg,DateTime dataFabricacao,int capacidade=5) : base(pesoKg,dataFabricacao)
        {
            this.Capacidade=capacidade;
        }
    }
    public class Onibus : Veiculo{
        private int capacidade;
        public override int Capacidade 
        { 
            get{ return capacidade; }
            set{
                if((value>=18) && (value<=60)){
                    capacidade=value;
                }
                else{
                    throw new Exception("O ônibus pode ter capacidade de 18 a 60 pessoas.");
                }
            }
        }
        public override void Abastecer(double quantidadeLitros)
        {
            this.QuantidadeCombustivel+=quantidadeLitros;
            Console.WriteLine("Ônibus abastecido com {0} litros de diesel.",quantidadeLitros);
        }
        public override void Mover(double distanciaKm)
        {
            if(this.QuantidadeCombustivel>(distanciaKm/5)){
                this.QuantidadeCombustivel-=(distanciaKm/5);
                Console.WriteLine("O ônibus se moveu por {0} Km.",distanciaKm);
            }
            else{
                Console.WriteLine("Não há combustível para percorrer a distância informada.");
            }
        }
        public new void Frear(){
            Console.WriteLine("Acionando os freios a ar...Parou!");
        }
        public Onibus(int pesoKg,DateTime dataFabricacao,int capacidade=44) : base(pesoKg,dataFabricacao)
        {
            this.Capacidade=capacidade;
        }
    }
}