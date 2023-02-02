using System;
class classeEObjetos{
    public static void Main(string[] args){
        Pessoa p1=new Pessoa();
        p1.Nome="Gabriele";
        p1.Idade=23;
        p1.Genero='F';
        // p1.Aprovado=false;
        p1.MostrarDados();
    }
}
public class Pessoa{
    public string Nome;
    public int Idade;
    public char Genero;
    private bool Aprovado;

    public void MostrarDados(){
        Console.WriteLine("Nome: {0}",Nome);
        Console.WriteLine("Idade: {0}",Idade);
        Console.WriteLine("Genero: {0}",Genero=='M'?"Masculino":"Feminino");
        Console.WriteLine("Aprovado: {0}",Aprovado);
    }
}