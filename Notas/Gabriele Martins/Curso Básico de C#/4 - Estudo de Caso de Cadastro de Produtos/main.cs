using System;
using System.Collections.Generic;
using System.Linq;
class MainClass{
    private static List<Produto> produtos=new List<Produto>();
    public static void Main(string[] args){
        Console.WriteLine("Estudo de Caso de Cadastro de Produtos");

        string comandoEscolhido="";

        while(comandoEscolhido!="S"){
            //Exibição do menu:
            Console.Clear();
            Console.WriteLine("Escolha a opção: ");
            Console.WriteLine("1 - Cadastrar produto");
            Console.WriteLine("2 - Listar produtos");
            Console.WriteLine("S - Sair");

            //Leitura da opção desejada pelo usuário:
            Console.Write("Opção desejada: ");
            comandoEscolhido=Console.ReadKey().KeyChar.ToString().ToUpper();

            //Processamento do comando digitado pelo usuário:
            switch(comandoEscolhido){
                case "1":
                    Console.Write("\nNome do Produto: ");
                    string nome=Console.ReadLine();
                    Console.Write("Preço do Produto: ");
                    string preco=Console.ReadLine();
                    Produto novoProduto=new Produto(nome,Convert.ToDouble(preco));
                    produtos.Add(novoProduto);
                    Console.WriteLine("Produto adicionado com sucesso!");
                    Console.ReadKey();
                    break;
                case "2":
                    if(produtos.Count>0){
                        Console.WriteLine("\nListagem de Produtos");
                        foreach(Produto p in produtos){
                            Console.WriteLine(p.ObterTexto());
                        }
                        Console.Write("Pressione qualquer tecla para prosseguir...");
                        Console.ReadKey();
                    }
                    else{
                        Console.WriteLine("\nNão há produtos cadastrados.");
                        Console.ReadKey();
                    }
                    break;
                case "S":
                    Console.WriteLine("\nObrigado por usar o programa.");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("\nOpção invalida! Tente novamente.");
                    Console.ReadKey();
                    break;
            }
        }
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