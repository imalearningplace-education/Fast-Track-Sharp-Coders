# Namespaces
Os namespaces são usados no C# para organizar e prover um 
nível de separação de código fonte. Podemos considerá-lo como 
um “container” que consiste de outros namespaces, classes, etc. 
Normalmente um namespace pode conter os seguintes membros:

* Classes
* Interfaces
* Estruturas
* Delegates

A principal funcionalidade do namespace é de fato organizar o 
projeto. A medida que ele vai ficando maior e com mais arquivos é 
extremamente importante que saibamos como segregar o projeto 
visando sobre a responsabilidade de cada componente e determinando suas ações de forma isolada.
```cs
using ProjetoExemplo;

namespace MeuExemplo
{
    public class ClasseExemplo1
    {
    }
} 
```
No exemplo acima, o namespace **"MeuExemplo"** está abrigando a classe **"ClasseExemplo1"**. Vale dizer que duas classe não podem ter o mesmo nome dentro do mesmo namespace, se tentássemos rodar um código com duas classes de nome igual teríamos um erro de compilação.

### Acessando os membros de um namespace

```cs
using ProjetoExemplo;
    namespace MeuExemplo
    {
        public class Classe1
        {
            // ponto de entrada do programa - entrypoint
            public static void Main()
            {
                ClasseDois ClasseDois = new ClasseDois();
            }
        }
    }
```

Adicionamos no topo do programa a palavra-chave using, indicando onde ir buscar a referência do objeto(no ProjetoExemplo em si).

Uma boa prática recomendada pela Microsoft e diversas pessoas programadoras profissionais é criar a estrutura do seu projeto 
seguindo a seguinte sintaxe:

*NomeDaEmpresa.NomeDoProjeto.CamadaDoProjeto.Funcionalidade*

**Exemplo:**

ImaLearningPlace.HubDeJogos.JogoDaVelha.Jogo