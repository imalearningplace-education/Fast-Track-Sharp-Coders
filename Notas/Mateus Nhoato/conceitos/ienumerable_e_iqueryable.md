### IEnumerable

- Enquanto consulta informações no banco de dados, IEnumerable executa uma consulta **Select** no lado do servidor, carrega os dados na memória do cliente e então filtra os dados (mais trabalhoso e mais lento)

- Os métodos de extensão suportados por IEnumerable usam *objetos funcionais*

==**Uso**: Para consultar dados a partir de coleções em memória como List, Array, etc.==

### IQueryable

- Enquanto consulta informações no banco de dados, IQueryable executa uma consulta **Select** no lado do servidor com todos os filtros (menos trabalho, mais rápido)

- Os métodos de extensão suportados por IQueryable usam objetos *Expression* (representa uma expressão lambda fortemente tipada)

==**Uso**: Para consultar dados a partir de coleções que não estão na memória, como banco de dados remotos, serviços, paginação, etc.==
