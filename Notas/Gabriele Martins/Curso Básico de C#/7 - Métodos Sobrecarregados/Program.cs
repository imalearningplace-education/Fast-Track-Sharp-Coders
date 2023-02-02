using System;
using System.Threading;
namespace MetodosSobrecarregados{
    class Program{
        static void Main(string[] args){
            Veiculo v1 = new Veiculo("Fusca",CorVeiculo.Branco,2);
            v1.MostrarDados(1);
            Veiculo v2 = new Veiculo("Opala",CorVeiculo.Preto,4);
            v2.MostrarDados(2);
            v2.Acelerar(5,10);
        }
    }
    enum CorVeiculo{
        Branco,
        Preto,
        Vermelho,
        Prata,
        Grafite
    }
    class Veiculo{
        public string Modelo { get; set; }
        public int Peso { get; set; }
        public double Velocidade { get; set; }
        public int Portas { get; set; }
        public CorVeiculo Cor { get; set; }
        public Veiculo(string modelo)
        {
            this.Velocidade=0;
            this.Modelo=modelo;
        }
        public Veiculo(string modelo, CorVeiculo cor) : this(modelo)
        {
            this.Cor=cor;
        }
        public Veiculo(string modelo, CorVeiculo cor, int portas = 4) : this(modelo,cor)
        {
            this.Portas=portas;
        }
        public void MostrarDados(){
            Console.WriteLine("Veiculo {0} :: Cor {1} :: {2} Portas",this.Modelo,this.Cor,this.Portas);
        }
        public void MostrarDados(int nRoll){
            Console.WriteLine("{0}. Veiculo {1} :: Cor {2} :: {3} Portas",nRoll,this.Modelo,this.Cor,this.Portas);
        }
        public void Acelerar(){
            this.Velocidade += 10;
        }
        public void Acelerar(int acrescimo){
            this.Velocidade += acrescimo;
        }
        public void Acelerar(int acrescimoPorSegundo, double tempoSeg){
            DateTime inicio = DateTime.Now;
            DateTime fim = inicio.AddSeconds(tempoSeg);
            while(inicio<fim){
                this.Velocidade += acrescimoPorSegundo;
                Thread.Sleep(1000);
                Console.WriteLine("Velocidade Atual: {0:F2}",this.Velocidade);
                inicio=inicio.AddSeconds(1);
            }
        }
    }
}