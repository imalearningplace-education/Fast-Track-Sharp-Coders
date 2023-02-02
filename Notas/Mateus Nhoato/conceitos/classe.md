# Classe
 É um tipo estruturado que pode conter membros:
    
- Atributos(dados/campos)
- Métodos(funções/operações)

A classe também pode prover muitos outros recursos, tais como:

- Construtores
- Sobrecarga
- Encapsulamento
- [Herança](heranca.md)
- [Polimorfismo](polimorfismo.md)

Exemplos:
- *Entidades*: Produto, Cliente, Triangulo
- *Serviços*: ProdutoService, ClienteService, EmailService
- *Controladores*: ProdutoController, ClienteController
- *Utilitários*: Calculadora, Compactador

*Outros*: views, repositórios, gerenciadores, etc

**`Toda Classe em C# é uma subclasse da classe Object`**

Object possui os seguintes métodos:
- GetType - retorna o tipo do objeto
- Equals - compara se o objeto é igual a outro
- GetHashCode - retorna um código hash do objeto
- ToString - converte o objeto para string

## Membros
Membros são os atributos e métodos da classe.

## Membros estáticos
Também chamados membros de classe (em oposição a membros de instância).São membros que fazem sentido independentemente de objetos. Não precisam de objeto para serem chamados. São chamados a partir do próprio nome da classe.

Aplicações comuns:
- Classes utilitárias
- Declaração de constantes

Uma classe que possui somente membros estáticos pode ser uma classe estática também. Esta classe não poderá ser instanciada.

## Construtor
É uma operação especial da classe, que executa no momento da instanciação do objeto.

Usos comuns:
- Iniciar valores dos atributos
- Permitir ou obrigar que o objeto receba dados / dependências no momento de sua instanciação (injeção de depedência).

- Se um constutor customizado não for especificado, a classe disponibiliza o construtor padrão:
    
    ```cs
    Produto p = new Produto();
    ``` 
É possível especificar mais de um construtor na mesma classe (sobrecarga).

## Sobrecarga
É um recurso que uma classe possui de oferecer mais de uma operação com o mesmo nome, porém com diferentes listas de parâmetros.

## Palavra *this*
É uma referência para o próprio objeto.

Usos comuns:
- Diferenciar atributos de variáveis locais (Java)
- Referenciar outro construtor em um construtor
    ```cs
    public Produto(){
        Quantidade = 0;
    }
    
    public Produto(string nome, double preco) : this() {
        Nome = nome;
        Preco = preco;
    }

    public Produto(string nome, double preco, int quantidade) : this(nome, preco){
        Quantidade = quantidade;
    }

    ```
    Pode ser usado para passar o próprio objeto como argumento na chamada de um método ou construtor.

## Encapsulamento
 É um princípio que consiste em esconder detalhes de implementação de um componente, expondo apenas operações seguras e que o mantenha em um estado consistente.

- Regra de ouro: o objeto deve sempre estar em um estado consistente, e a própria classe deve garantir isso.

## Implementação manual de encapsulamento
- Todo atributo é definido como private
- Implementa-se métodos Get e Set

    ```cs
    public string GetNome()
        {
            return _nome;
        }

        public void SetNome(string nome) 
        {
            _nome = nome;
        }
    ```

## Propriedades

São definições de métodos encapsulados, porém expondo uma sintaxe similar à de atributos e não de métodos.

Uma propriedade é um membro que oferece um mecanismo flexível para ler, gravar ou calcular o valor de um campo particular. As propriedades podem ser usadas como se fossem atributos públicos, mas na verdade elas são métodos especiais chamados "acessadores". Isso permite que os dados sejam acessados facilmente e ainda ajuda a promover a segurança e flexibilidade dos métodos.

    ```cs
     public string Nome 
     {
            get { return _nome; }
            set {
                if(value != null && value.Length > 1)
                _nome = value; 
                }
     }

        public double Preco {
            get { return _preco; }
        }
    ```

## Propriedades autoimplementadas

É uma forma simplificada de se declarar propriedades que não necessitam de lógicas particulares para as operações get e set.

    ```cs
    public double Preco {get; private set;}
    ```

## `Ordem sugerida em uma classe`
É interessante seguir a seguinte ordem para uma boa organização de código:

    1. Atributos privados
    2. Propriedades autoimplementadas
    3. Construtores
    4. Propriedades customizadas
    5. Outros métodos da classe
