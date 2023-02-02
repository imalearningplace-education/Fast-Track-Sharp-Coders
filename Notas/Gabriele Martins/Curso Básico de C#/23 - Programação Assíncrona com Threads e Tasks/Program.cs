using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
namespace ProgAssincrona{
    class Program{
        static void Main(string[] args)
        {
            Stopwatch sw=new Stopwatch();
            sw.Start();
            ExecutarComTasks();
            sw.Stop();
            Console.WriteLine("Operação gastou {0} milissegundos.",sw.ElapsedMilliseconds);
        }
        static void RealizarOperacao(int op, string nome, string sobrenome){
            Console.WriteLine("Iniciando operação {0}...",op);
            for(int i=0; i<1000000000; i++){
                var p = new Pessoa(nome, sobrenome, 35);
            }
            Console.WriteLine("Finalizando operação {0}...",op);
        }
        static void ExecutarSequencial(){
            RealizarOperacao(1,"Gabriele","Martins");
            RealizarOperacao(2,"Ellie","Williams");
            RealizarOperacao(3,"Joel","Miller");
        }
        static void ExecutarComThreads(){
            var t1=new Thread(()=>{
                RealizarOperacao(1,"Gabriele","Martins");
            });
            var t2=new Thread(()=>{
                RealizarOperacao(2,"Ellie","Williams");
            });
            var t3=new Thread(()=>{
                RealizarOperacao(3,"Joel","Miller");
            });
            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();
        }
        static void ExecutarComTasks(){
            var t1=Task<int>.Run(()=>{
                RealizarOperacao(1,"Gabriele","Martins");
                return 1;
            });
            var t2=Task<int>.Run(()=>{
                RealizarOperacao(2,"Ellie","Williams");
                return 2;
            });
            var t3=Task<int>.Run(()=>{
                RealizarOperacao(3,"Joel","Miller");
                return 3;
            });
            Console.WriteLine("Tarefa {0} finalizou.",t1.Result);
            Console.WriteLine("Tarefa {0} finalizou.",t2.Result);
            Console.WriteLine("Tarefa {0} finalizou.",t3.Result);
        }
    }
    internal class Pessoa{
        private string nome;
        private string sobrenome;
        private int v;
        public Pessoa(string nome, string sobrenome, int v){
            this.nome=nome;
            this.sobrenome=sobrenome;
            this.v=v;
        }
    }
}