# Modificadores de acesso


|  Modificador | Propriedades  |
|---|---|
|  `public` | Pode ser acessado pela própria classe, subclasses no assembly, classes do assembly, subclasses fora do assembly e classes fora do assembly.  |
|`protected internal`  |Pode ser acessado pela própria classe, subclasses no assembly, classes do assembly e subclasses fora do assembly.   |
| `internal`  |Pode ser acessado pela própria classe, subclasses no assembly, classes do assembly e subclasses fora do assembly. |
| `protected`  |Pode ser acessado pela própria classe, subclasses no assembly e sublcasses fora do assembly.  |
|`private protected`  |Pode ser acessado pela própria classe e subclasses no assembly.  |
| `private` |Pode ser acessado somente pela própria classe.  |



## Modificadores de Acesso em [Classes](classe.md)

Acesso por qualquer classe 
- `public` class Product

Acesso somento dentro do assembly
- `internal` class Product
- class Product

Acesso somente pela classe-mãe
- `private` class Product

**Nota**: Classe aninhada, por padrão, é private.