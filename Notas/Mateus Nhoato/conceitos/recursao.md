Recursão é autorreferência. Recursão ocorre quando algo é definido em termos de si mesmo ou de suas variações. Ou seja, recursão envolve estruturas **aninhadas**. ==Se uma coisa é definida unicamente em termos de si própria, existe uma circularidade inerente que não nos permite concluir nada sobre o que está sendo definido, logo precisamos de um **caso base** ou de uma  **condição de parada**==.

Definições recursivas (quando propriamente formuladas) nunca definem unicamente em termos de si mesmas, mas sempre em termos de versões mais simples de si mesmas, até que seja possível parar, ou seja, até chegarmos a um caso que seja possível resolvê-lo facilmente.

#### Exemplo:

O fatorial de um número n, denotado por *n!*, é calculado como a seguir:
- 0! = 1
- n! = n x (n-1)!

Com a primeira regra (0! = 1), conseguimos calcular o fatorial e podemos usar esse resultado no cálculo do fatorial dos demais números, até chegarmos ao fatorial do número desejado inicialmente. O procedimento não executará indefinitivamente. 

Aplicando a fórmula no fatorial de 5:

5! = 5 x 4! 
5! = 5 x (4 x 3!)
5! = 5 x (4 x (3 x 2!))
5! = 5 x (4 x (3 x (2 x 1!)))
5! = 5 x (4 x (3 x (2 x (1 x 0!))))
5! = 5 x (4 x (3 x (2 x (1 x 1))))
5! = 120

Como podemos ver acima, existe um ponto em que a recursão para de ser aplicada. No caso acima, quando chegamos ao 0!. Quando dizemos que o 0!=1, estamos impondo uma condição para que o procedimento recursivo termine. Este tipo de condição é chamada de **condição de parada** ou de **caso base** do procedimento recursivo. Quando o procedimento atinge a condição de parada, ele a resolve e usa o resultado dela para resolver as demais chamadas ainda não resolvidas, na ordem em que estão nas pilha de chamada, ou seja, da última para a primeira.

### Considerações Sobre Algoritmos recursivos

- A implementação da definição do conceito do algoritmo recursivo, em uma linguagem de programação, é relativamente simples.

- São fáceis de serem lidos. A correspondência entre a definição e a implementação é óbvia. 

- Porém, algoritmos recursivos não são eficientes em certos casos, pois pode ser que realizem grandes quantidades de trabalhos repetidos (chamadas iguais). Para este tipo de caso usamos **programação dinâmica**, guardamos os valores já resolvidos em uma array e checamos nesta array se o valor já foi computado antes de fazer a chamada recursiva.
