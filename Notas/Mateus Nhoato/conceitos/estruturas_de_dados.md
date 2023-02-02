# Estrutura de Dados

Estruturas de dados (Data Structures) são estruturas que armazenam  dados ou [variáveis](variaveis.md) de tipos iguais. Podemos adicionar, remover ou alterar objetos dentro de uma estrutura de dados.

## Tipos de estruturas de dados:

### Vetores
Vetor é o nome dado a arranjos unidimensionais.

Arranjo é uma estrutura de dados:
- Homogênea (dados do mesmo tipo)
- Ordenada (elementos acessados por meio de posições)
- Alocada de uma vez só, em um bloco contíguo de memória

Vantagens:
- Acesso imediato aos elementos pela sua posição 

Desvantagens:
- Tamanho fixo
- Dificuldade para se realizar inserções e deleções

### Matrizes
"Matriz" é o nome dado a arranjos bidimensionais. Matrizes têm as mesmas características que Vetores, porém com uma dimensão a mais.

### Listas
Namespace: System.Collections.Generic

Lista é uma estrutura de dados:
- Homogênea (dados do mesmo tipo)
- Ordenada (elementos acessados por meio de posições)
- Inicia vazia, e seus elementos são alocados sob demanda
- Cada elemento ocupa um "nó" (ou nodo) da lista

Vantagens:
- Tamanho variável
- Facilidade para se realizar inserções e deleções

Desvantagens:
- Acesso sequencial aos elementos


### HashSet e SortedSet
Represeta um cojunto de elementos (similar ao da álgebra).

- Não admite repetições
- Elementos não possuem posição
- Acesso, inserção e remoção de elementos são rápidos
- Oferece operações eficientes de conjunto: interseção, união, diferença.

#### Diferenças entre HashSet e SortedSet

##### **Hashset**

- Armazenamento em *tabela hash*
- Extremamente rápido: inserção, remoção e busca O(1)
- Ordem dos elementos não é garantida

##### **SortedSet**

- Armazenamento em *árvore*
- Rápido, inserção, remoção e busca O(log(n))
- Os elementos são armazenados ordenadamente conforme implementação IComparer<>

##### Como as coleções Hash testam igualdade?

Se GetHashCode e Equals estiverem implementados:
- Primeiro é utilizado GetHashCode. Se der igual, usa o Equals para confirmar.

Se GetHashCode e Equals **NÃO** estiverem implementados:
    - Tipos referência: compara as referências dos objetos
    - Tipos valor: compara os valores dos atributos


### Dictionary< TKey,TValue > e SortedDictionary

É uma coleção de pares chave/ valor.

- Não admite repetições do objeto chave
- Os elementos são indexados pelo objeto chave (não possuem posição)
- Acesso, inserção e remoção de elementos são rápidos
- Uso comum: cookies, local storage, qualquer modelo chave-valor

#### Diferenças entre Dictionary e SortedDictionary

##### Dictionary

- Armazenamento em tabela hash
- Extremamente rápido: inserção, remoção e busca O(1)
- A ordem dos elementos não é garantida

##### SortedDictionary
 
 - Armazenamento em árvore
- Rápido: inserção, remoção e busca O(log(n))
- Os elementos são armazenados ordenadamente conforme implementação IComparer<.T>