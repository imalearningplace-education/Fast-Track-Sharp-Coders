# Nullable
É um recurso de C# para que dados de tipo valor possam receber o valor null.

Uso comum:
- Campos de banco de dados que podem valer nulo (data de nascimento, por exemplo).
- Dados e parâmetros opcionais.

```cs
double x = null; // dá erro

// 2 jeitos de fazer corretamente:
Nullable<double> x = null;
double? x = null;
```
O tipo nullable tem os seguintes métodos:
- GetValueOrDefault
- HasValue
- Value (lança uma exceção se não houver valor)

```cs
double? x = null;
double? y = 10.0;

Console.WriteLine(x.GetValueOrDefault());
Console.WriteLine(y.GetValueOrDefault());
Console.WriteLine(x.HasValue);
Console.WriteLine(y.HasValue);

if (x.HasValue) 
    Console.WriteLine(x.Value);
else
    Console.WriteLine("X is null");

if (y.HasValue)
    Console.WriteLine(y.Value);
else
    Console.WriteLine("Y is null");
```
Saída:
```
0
10.0
False
True
X is null
10.0
```

## Operador de coalescência nula
```cs
double? x = null;
double y = x ?? 0.0;
```
Usamos o sinal '??' para indicar que caso o valor de **x** ser nulo, então o valor de y na verdade vai ser o valor seguinte (no caso 0.0).