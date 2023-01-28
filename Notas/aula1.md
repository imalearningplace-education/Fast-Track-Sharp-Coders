# Generics

## Problema motivador

Se eu tivesse uma classe utilitária para o Console e nela eu fosse acumular coisas para imprimir de uma única vez.

Exemplo para números double:

```cs
public class Console {

  private static List<double> Buffer = new List<double>();

  public static void Append(double number) {
    buffer.Add(number);
  }

  public static void Log(double number) {
    Console.WriteLine(number);
  }

  public static void LogBuffer() {
    // Buffer.ForEach(e => Console.Write(e));
    Buffer.ForEach(Console.Write);
  }

}
```

```cs
public interface IConsole {

  void Append(? ...); // problema

}
```

Problema: Estou preso ao tipo double.

## Passo adiante...

```cs
public class Console {

  private static List<object> Buffer = new List<object>();

  public static void Append(object? obj) {
    buffer.Add(obj);
  }

  public static void Log(object? obj) {
    Console.WriteLine(obj);
  }

  public static void LogBuffer() {
    // Buffer.ForEach(e => Console.Write(e));
    Buffer.ForEach(Console.Write);
  }

}
```

**Type Safety**: Esse console aceita tipos demais agora e não consegue restringir um tipo alvo.

## Operador Generics

- instrumentalização
- Wrapper (Empacotado)

Criando lista genérica, com regras:

- adiciono no meio
- removo de ambas as pontas

```cs
public class MinhaLista<T> {

  private List<T> lista = new List<T>();

  public void Add(T newElement) {
    int size = lista.Count;
    int position = size / 2;
    lista.Add(newElement, position);
  }

  public bool Remove(){
    int lasPosition = list.Count - 1;
    // pode conter verificações de tamanho da lista
    lista.Remove(0);
    lista.Remove(lastPosition);
    return;
  }

  public T get(){
    int size = lista.Count;
    int position = size / 2;
    return lista[position];
  }

}
```

uso:

```cs
MinhaLista<Pessoa> listaDePessoas = new();
```

## Aplicando em um projeto

Ideia de um CRUD:

```cs
public interface IRepository<T> {
  T Create(T obj);
  List<T> Read();
  T Update(T origObj,T destObj);
  bool Delete(T obj);
}
```

```cs
public class PessoaRepository : IRepository<Pessoa> {

  // ...

}
```
