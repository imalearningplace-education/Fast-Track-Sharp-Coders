using System;
class MainClass{
    public static void Main(string[] args){
        Console.WriteLine("Classes, Objetos e Escopos de Visibilidade");
        Produto p1=new Produto();
        p1.Nome="Banana";
        Console.WriteLine(p1.Nome);
    }
}
class Produto{
    private string nome;
    public string Nome{
        get{
            return nome;
        }
        set{
            if(value.Length>1)
                nome=value;
            else
            throw new Exception("Nome do produto deve ter pelo menos 2 caracteres.");
        }
    }
}