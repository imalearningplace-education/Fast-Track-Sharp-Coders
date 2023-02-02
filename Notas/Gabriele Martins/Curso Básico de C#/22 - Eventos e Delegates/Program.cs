using System;
using System.Collections.Generic;
namespace AulaEventsAndDelegates{
    class Program{
        public delegate double OperacaoMatematicaBinaria(double x, double y);
        public delegate void OcorrenciaDeOperacao(double resultado);
        public static event OcorrenciaDeOperacao AoOcorrerOperacao;
        public static double Somar(double x, double y){
            double r = x + y;
            //Console.WriteLine("A soma de {0} e {1} é igual a {2}.",x,y,r);
            AoOcorrerOperacao.Invoke(r);
            return r;
        }
        public static double Multiplicar(double x, double y){
            double r = x * y;
            //Console.WriteLine("A multiplicação de {0} e {1} é igual a {2}.",x,y,r);
            AoOcorrerOperacao.Invoke(r);
            return r;
        }
        public static double Potenciar(double x, double y){
            double r = Math.Pow(x,y);
            //Console.WriteLine("A potência de {0} e {1} é igual a {2}.",x,y,r);
            AoOcorrerOperacao.Invoke(r);
            return r;
        }
        static void Main(string[] args)
        {
            // OperacaoMatematicaBinaria op = new OperacaoMatematicaBinaria(Multiplicar);
            // op(20,10);
            // List<OperacaoMatematicaBinaria> operacoes = new List<OperacaoMatematicaBinaria>();
            // operacoes.Add(new OperacaoMatematicaBinaria(Somar));
            // operacoes.Add(new OperacaoMatematicaBinaria(Multiplicar));
            // operacoes.Add(new OperacaoMatematicaBinaria(Potenciar));
            // foreach(var item in operacoes){
            //     item(10,2);
            //     item(20,3);
            //     item(30,4);
            //     Console.WriteLine();
            // }
            // operacoes.Add(delegate(double a, double b){
            //     double r = a / b;
            //     Console.WriteLine("A divisão de {0} e {1} é igual a {2}.",a,b,r);
            //     return r;
            // });
            // foreach(var item in operacoes){
            //     item(10,2);
            //     item(20,3);
            //     item(30,4);
            //     Console.WriteLine();
            // }

            AoOcorrerOperacao += MostrarResultadoNaTela;
            AoOcorrerOperacao += EnviarResultadoPorEmail;
            AoOcorrerOperacao += GravarResultadoEmArquivo;

            OperacaoMatematicaBinaria opMulticast = Somar;
            opMulticast += Multiplicar;
            opMulticast += Potenciar;
            opMulticast += delegate(double a, double b){
                double r = a / b;
                //Console.WriteLine("A divisão de {0} e {1} é igual a {2}.",a,b,r);
                AoOcorrerOperacao.Invoke(r);
                return r;
            };
            opMulticast(2,3);
        }
        public static void MostrarResultadoNaTela(double r){
            Console.WriteLine("Resultado: {0}",r);
        }
        public static void EnviarResultadoPorEmail(double r){
            Console.WriteLine("Enviando e-mail com resultado {0}.",r);
        }
        public static void GravarResultadoEmArquivo(double r){
            Console.WriteLine("Gravando arquivo com resultado {0}.",r);
        }
    }
}