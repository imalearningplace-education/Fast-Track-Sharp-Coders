# Modificador de parâmetros

## Params
Para receber múltiplos parâmetros, usamos vetores.
Mas, para não precisar necessariamente pedir um vetor na chamada da função, podemos usar o params:

```cs
  public static double Sum(params double[] array) 
        {
            double sum = 0;
            foreach(var item in array) 
            {
                sum+= item;
            }
            return sum;
        }
// abaixo só colocamos os termos separando com vírgulas, não precisamos fazer uma array em si
Console.WriteLine(Calculadora.Sum(2,3,4,5,6));
```
Saída
```cs
20
```

## Ref

 **ref** é utilizado para se referenciar à própria variável que está no parâmetro da chamada de uma função. Pois normalmente quando recebemos algum valor como parâmetro, simplesmente fazemos uma cópia desse valor para dentro da função (para seu escopo local). Com ref podemos alterar a variável original:

```cs
class Calculator{
    public static void Triplicar(ref int x)
    {
        x *= 3;
    }
}

int a = 10;
Calculator.Triplicar(ref a);
Console.WriteLine(a);
```
Saída
```cs
30
```

## Out

O modificador **out** é similar ao ref (faz o parâmetro ser uma referência para a variável original), mas não exige que a variável original seja iniciada.

```cs
 public static void Dobrar(double x, out double dobro)
        {
            dobro = x * 2;
        }

    double a = 10;
    double dobro;

    Calculadora.Dobrar(a, out dobro);
    Console.WriteLine(dobro);
```
Saída
```
20
```

## Diferenças entre **ref** e **out**

A variável passada como parâmetro **ref** DEVE ter sido iniciada. A variável passada como parâmetro **out** não precisa ter sido iniciada.

Conclusão: ambos são muito similares, mas ref é uma forma do compilador obrigar o usuário a iniciar a variável.

==Nota: ambos são considerados "code smells" (design ruim) e devem ser evitados.==
