using System;
using System.Threading;
namespace HerancaDeClasses{
    class Program{
        static void Main(string[] args)
        {
            Aviao a1=new Aviao(3200,4,16,12,12);
            // a1.Voar(1000);
            Barco b1=new Barco(1200,2.5,4,12,800);
            b1.Navergar(200);
        }
    }
    class Veiculo
    {
        public double Peso { get; set; }
        public double Altura { get; set; }
        public double Largura { get; set; }
        public double Comprimento { get; set; }
        protected double Densidade{
            get{
                return this.Peso/(this.Altura*this.Largura*this.Comprimento);
            }
        }
        public Veiculo(double peso, double altura, double largura, double comprimento){
            this.Peso=peso;
            this.Altura=altura;
            this.Largura=largura;
            this.Comprimento=comprimento;
            Console.WriteLine("Um objeto do tipo Veiculo foi criado.");
        }
        ~Veiculo(){
            Console.WriteLine("Um objeto do tipo Veiculo foi destruído.");
        }
    }
    class Aviao : Veiculo
    {
        public int Passageiros { get; set; }
        public double Altitude { get; set; } 
        public Aviao(double peso, double altura, double largura, double comprimento, int passageiros) : base(peso,altura,largura,comprimento)
        {
            this.Passageiros=passageiros;
            this.Altitude=0;
            Console.WriteLine("Um objeto do tipo Aviao foi criado.");
        }
        ~Aviao(){
            Console.WriteLine("Um objeto do tipo Aviao foi destruido.");
        }
        public void Voar(double distancia){
            this.Decolar(1000);
            double percorrida=0;
            while(percorrida<distancia){
                Console.WriteLine("O avião está a {0:F2} metros de distância do destino.",distancia-percorrida);
                percorrida+=220;
                Thread.Sleep(1000);
            }
            this.Pousar();
        }
        private void Decolar(int altitude){
            while(this.Altitude<altitude){
                Console.WriteLine("O avião está a {0:F2} metros de altitude.",this.Altitude);
                this.Altitude+=60;
                Thread.Sleep(1000);
            }
            Console.WriteLine("Decolagem concluída.");
            Thread.Sleep(1000);
        }
        private void Pousar(){
            while(this.Altitude>0){
                Console.WriteLine("O avião está a {0:F2} metros de altitude.",this.Altitude);
                this.Altitude-=60;
                this.Altitude=this.Altitude<0?0:this.Altitude;
                Thread.Sleep(1000);
            }
            Console.WriteLine("Pouso concluída.");
            Thread.Sleep(1000);
        }
    }
    class Barco : Veiculo{
        public int PotenciaHp { get; set; }
        public double TamanhoEmPes 
        { 
            get{
                return this.Comprimento*3.28;
            } 
        }
        public Barco(double peso, double altura, double largura, double comprimento, int potenciaHp) : base(peso, altura,largura,comprimento)
        {
            this.PotenciaHp=potenciaHp;
            Console.WriteLine("Um objeto do tipo Barco foi criado.");
        }
        ~Barco(){
            Console.WriteLine("Um objeto do tipo Barco foi destruído.");
        }
        public void Navergar(double distancia){
            double percorrida=0;
            while(percorrida<distancia){
                Console.WriteLine("O barco está a {0:F2} metros de distância do destino.",distancia-percorrida);
                percorrida+=20;
                Thread.Sleep(1000);
            }
        }
    }
}