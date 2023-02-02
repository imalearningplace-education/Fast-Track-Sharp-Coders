# Atributos, Propriedades e Escopos de Visibilidade em C#
## Atributos Privados ou Públicos
Primeiramente criamos a classe Produto com o atributo nome privado:
```cs
class Produto{
    private string nome;
}
```
Ao criarmos uma instância dessa classe e atribuirmos à variavel p1, não foi possível alterar seu nome:
```cs
Produto p1=new Produto();
p1.nome="Banana"; //error CS0122: 'Produto.nome' é inacessível devido ao seu nível de proteção
```
**Regra 1**: Todo atributo, método ou propriedade privados só é visível dentro da própria classe.

Para que esse elemento se torne visível para outras classes é preciso que seja declarado como público:
```cs
class Produto{
    public string nome;
}
```
## Propriedades
Normalmente escrevemos elementos públicos com primeira letra maiúscula e elementos privados com primeira letra minúscula. Além disso, é uma boa prática colocar o nome de uma propriedade igual ao do atributo referente.

Uma propriedade é uma ponte de acesso a um atributo privato em outras classes. O atributo armazena efetivamente valores na memória do computador, já propriedades não, sendo apenas um filtro de acesso para o atributo. Uma propriedade normalmente tem dois métodos: **get** e **set**. O método **get** retorna o valor do atributo. Já o método **set** atribui um valor (**value**) ao atributo:
```cs
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
```
E o acesso ao atributo privado é feito através de sua propriedade:
```cs
Produto p1=new Produto();
p1.Nome="Banana";
Console.WriteLine(p1.Nome);
```
Há como criar propriedades para um atributo sem condições nos métodos get e set, o que ficaria da seguinte forma:
```cs
private double preco;
public double Preco{
    get{return preco;}
    set{preco = value;}
}
```
Porém, outra forma bem mais compacta de escrever o código acima seria:
```cs
public double Preco {get; set;}
```
Podemos também criar um atributo e propriedade em que o método get seja público (é possível acessar o valor do atributo) e o método set seja privado (não é possível alterar o valor do atributo):
```cs
public int Estoque {get; private set;}
```