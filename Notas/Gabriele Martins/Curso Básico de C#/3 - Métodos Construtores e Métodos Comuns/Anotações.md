# Métodos Construtores e Métodos Comuns
Na classe Produto possuímos um atributo privado e três propriedades.
## Método Construtor
A classe Produto por padrão possui um método construtor, ou seja, toda vez que fazemos ```Produto p1=new Produto()```, um objeto é criado utilizando o método construtor. Porém esse método nao foi criado por nós, e por padrão, toda classe tem um método construtor que é herdado de uma classe ancestral. Se quisermos um construtor personalizado temos que implementar, e fazemos da seguinte forma:
```cs
class Produto{
    public Produto(){
        this.Estoque=0;
    }
}
```
Todo método construtor tem o mesmo nome de sua classe, é sempre público e não possui um tipo de variável de retorno. Todo objeto da classe Produto que criarmos terá seu Estoque iniciado com o valor 0. 
```cs
class Produto{
    public Produto(){
        this.Estoque=0;
    }
    public Produto(string nome, double preco){
        this.Nome=nome;
        this.Preco=preco;
        this.Estoque=0;
    }
}
```
Se criamos um objeto Produto com argumentos, a segunda classe construtora acima entra em ação. A palavra **this** entra no lugar do nome do objeto criado.
## Método Comum
Métodos comuns podem ter qualquer nome, serem públicos ou privados e podem possuir um tipo de variável de retorno ou não.
```cs
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
```
Podemos chamar os métodos acima em uma classe externa da seguinte maneira:
```cs
p1.Comprar(100);
p1.Vender(17);
Console.WriteLine(p1.ObterTexto());

p2.Comprar(50);
p2.Vender(29);
Console.WriteLine(p2.ObterTexto());
```