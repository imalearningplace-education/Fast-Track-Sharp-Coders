using System;
namespace EstudoDeCasoPessoa
{
    class Program{
        static void Main(string[] args)
        {
            Pessoa p1=new Pessoa("Gabriele","Martins",new DateTime(1999,7,16),"47613215806");
            p1.Peso=65;
            p1.Altura=1.68;
            p1.MostrarDados();
            p1.Comer(2.5);
            p1.Comer(3800);
            p1.Correr(7,30);
            p1.MostrarDados();
        }
    }
    class Pessoa{
        private string cpf;
        public string CPF
        {
            get { return cpf; }
            set { 
                if ((value.Length==11) && value.HasOnlyDigits()) cpf=value;
                else throw new Exception("O CPF deve possuir 11 dígitos.");
            }
        }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public double Peso { get; set; }   
        public double Altura { get; set; }
        public double IMC{
            get{
                return (this.Peso/(this.Altura*this.Altura));
            }
        }
        public Pessoa(string nome, string sobrenome, DateTime dataNascimento, string cpf)
        {
            this.Nome=nome;
            this.Sobrenome=sobrenome;
            this.DataNascimento=dataNascimento;
            this.CPF=cpf;
        }
        public Pessoa(string nome, string sobrenome, DateTime dataNascimento, string cpf, double peso, double altura) : this(nome,sobrenome,dataNascimento,cpf)
        {
            this.Peso=peso;
            this.Altura=altura;
        }
        public void Comer(double pesoKg){
            this.Peso+=pesoKg*0.10;
            Console.WriteLine("{0} {1} comeu {2}Kg de comida.",this.Nome,this.Sobrenome,pesoKg);
        }
        public void Comer(int calorias){
            this.Peso+=calorias/30000;
            Console.WriteLine("{0} {1} ingeriu {2} calorias.",this.Nome,this.Sobrenome,calorias);
        }
        public void Correr(double distanciaKm,int dias=1){
            this.Peso-=(distanciaKm/40)*dias;
            Console.WriteLine("{0} {1} correu {2}Km diários por {3} dia(s).",this.Nome,this.Sobrenome,distanciaKm,dias);
        }
        public void MostrarDados(){
            Console.WriteLine("Nome Completo: {0} {1}",this.Nome,this.Sobrenome);
            Console.WriteLine("Idade: {0}",(int)((DateTime.Now-this.DataNascimento).TotalDays/365.25));
            Console.WriteLine("IMC: {0:F2}",this.IMC);
        }
    }
    static class Extensions{
        public static bool HasOnlyDigits(this string valor){
            const string digitos="0123456789";
            foreach(char c in valor){
                if(!digitos.Contains(c)){
                    return false;
                }
            }
            return true;
        }
    }
}