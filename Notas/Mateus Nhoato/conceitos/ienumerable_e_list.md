
## Diferenças

- **IEnumerable** descreve um comportamento e List implementa esse comportamento.

- ==IEnumerable é "read-only"==, ou seja, não conseguimos alterar a coleção, somente ler. Já o tipo List implementa uma variadade de métodos capazes de alterar a coleção.

- IEnumerable possui um método para retornar o *próximo item* nacoleção, assim ele não precisa que toda coleção esteja e mmemória e também não sabe quantos itens existem na coleção.

- Quando usamos IEnumerable, damos ao compilador a chance de **adiar a execução**, isso porque ==o IEnumerable não é executado enquanto não for processado em um loop ou enquanto um tipo de valor não for extraído da variável em que foi salvo.==

## Usos

- Usamos **IEnumerable** quando queremos apenas ler a coleção, ou quando estamos trabalhando com um volume muito grande de dados e não queremos copiar tudo na memória (pois causaria problemas de desempenho).

-  Usamos **List** quando precisamos alterar a coleção, ou se precisamos de resultados imediatamente.