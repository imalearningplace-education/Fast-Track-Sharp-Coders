using System;
class inputEOutputEMetodos{
    public static void Main(string[] args){
        Console.Write("Digite seu nome: ");
        string r1=Console.ReadLine();
        Console.WriteLine("Seu nome é {0} e possui {1} letras.",r1,ContarLetras(r1));
    }
    public static int ContarLetras(string palavra="Seu Nome"){//se o usuário nao informar algum valor para palavra, palavra receberá o valor default "Seu Nome". Os parâmetros com valor default devem vir por ultimo.
        return palavra.Length;
    }
}