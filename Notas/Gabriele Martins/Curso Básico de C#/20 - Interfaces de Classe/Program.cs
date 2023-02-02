using System;
using System.Collections.Generic;
namespace EstudandoInterfaces{
    class Program{
        static void Main(string[] args){
            IAnimal oswaldo = new Cachoro();
            oswaldo.EmitirSom();
            if(oswaldo is Cachoro){
                (oswaldo as Cachoro).Farejar();
            }

            Cachoro bilu = new Cachoro();
            bilu.EmitirSom();
            bilu.Farejar();

            IAnimal bolinha = new Cachoro();
            if(bolinha is IQuadrupede){
                (bolinha as IQuadrupede).Andar();
            }
            if(bolinha is Cachoro){
                (bolinha as Cachoro).Farejar();
            }

            Random random = new Random();
            List<IAnimal> animais = new List<IAnimal>();
            for(int i=0; i<100; i++){
                int sorteio = random.Next();
                if(sorteio%2==0){
                    animais.Add(new Cachoro());
                }
                else{
                    animais.Add(new Macaco());
                }
            }
            foreach(var animal in animais){
                Console.WriteLine("---------------------------------");
                if(animal is IQuadrupede)
                    Console.WriteLine("Este animal é um quadrúpede.");
                if(animal is IBipede)
                    Console.WriteLine("Este animal é um bípede.");
                if(animal is Cachoro){
                    Console.WriteLine("Este animal é um cachorro.");
                    (animal as Cachoro).Farejar();
                }
                if(animal is Macaco){
                    Console.WriteLine("Este animal é um macaco.");
                    (animal as Macaco).Caminhar();
                }
            }
        }
    }
    interface IAnimal{
        void Comer();
        void Dormir();
        void EmitirSom();
    }
    interface IQuadrupede{
        void Andar();
        void Correr();
    }
    interface IBipede{
        void Caminhar();
    }
    class Cachoro : IAnimal, IQuadrupede{
        public void Comer(){
            Console.WriteLine("O cachorro está comendo ração.");
        }
        public void Dormir(){
            Console.WriteLine("O cachorro está dormindo no chão.");
        }
        public void EmitirSom(){
            Console.WriteLine("Au au au!");
        }
        public void Farejar(){
            Console.WriteLine("O cachorro está farejando.");
        }
        public void Andar(){
            Console.WriteLine("O cachorro está andando com as quatro patas.");
        }
        public void Correr(){
            Console.WriteLine("O cachorro está correndo com as quatro patas.");
        }
    }
    class Macaco : IAnimal, IBipede{
        public void Comer(){
            Console.WriteLine("O macaco está comendo banana.");
        }
        public void Dormir(){
            Console.WriteLine("O macaco está dormindo na árvore.");
        }
        public void EmitirSom(){
            Console.WriteLine("Uh uh ah ah ah!");
        }
        public void Caminhar(){
            Console.WriteLine("O macaco está caminhando com os dois pés.");
        }
    }
}