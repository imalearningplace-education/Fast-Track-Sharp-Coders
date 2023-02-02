using System;
using System.Text;
class MainClass{
    public static void Main(string[] args){
        Console.WriteLine("Métodos Construtores e Métodos Comuns");
        Produto p1=new Produto();
        p1.Nome="Banana";
        p1.Preco=3.9;
        p1.Comprar(100);
        p1.Vender(17);
        Console.WriteLine(p1.ObterTexto());
        Produto p2=new Produto("Laranja",4.75);
        p2.Comprar(50);
        p2.Vender(29);
        Console.WriteLine(p2.ObterTexto());
    }
}
class Produto{
    public Produto(){
        this.Estoque=0;
    }
    public Produto(string nome, double preco){
        this.Nome=nome;
        this.Preco=preco;
    }
    public int Vender(int qtde){
        if(this.Estoque-qtde>=0)
            this.Estoque-=qtde;
        return this.Estoque;
    }
    public int Comprar(int qtde){
        this.Estoque+=qtde;
        return this.Estoque;
    }
    public string ObterTexto(){
        string sb="";
        sb+="\nNome: "+this.Nome+"\n";
        sb+="Preço: "+this.Preco+"\n";
        sb+="Estoque: "+this.Estoque+"\n";
        return sb.ToString();
    }
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
    public double Preco {get; set;}
    public int Estoque {get; private set;}
}