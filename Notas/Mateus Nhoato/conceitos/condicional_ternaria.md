# Expressão Condicional Ternária

Estrututra opcional ao if-else quando se deseja decidir um valor com base em uma condição.

Sintaxe:
```
(condição) ? valor_se_verdadeiro : valor_se_falso
```
Exemplo:
```cs
double preco = 34.5;
double desconto = (preco < 20.0) ? preco * 0.1 : preco * 0.05;

Console.WriteLine(desconto);
```
Saída
```cs
1.725
```
Porque 34.5 é maior que 20, o desconto foi de 0.05 (5%).