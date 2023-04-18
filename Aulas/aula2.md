# Arquitetura e Principios

## Definições

- Módulos de Alto nível

  - mais próxima da linguagem humana
  - ex.: `gerarNotaFiscal()`

- Módulos de Baixo nível

  - mais perto de um algoritmo ou código bruto
  - ex.: `calculaSomaDosPedidos()`

- Detalhes
  - são os artefatos que não deveriam fazem parte da arquitetura de forma acoplada, mas que, no entanto, são necessários para um sistema funcionar
  - módulos mais básicos que o de baixo nível, sem valor lógico significativo
  - ex.: `obterProdutos()`

```js
gerarNotaFiscal()
  |-> calculaTotalDosPedidos()
    |-> obterProdutos()
```

```ts
function gerarNotaFiscal(id: number) {
  return notaFiscal {
    cliente: obtemDadosCliente(id),
    produtos: obterProdutos(id),
    total: calculaTotalDosPedidos(id)
  }
}
```

## Com POO

```js
class NotaFiscalService
  |-> gerarNotaFiscal()
```

```js
class Pedidos
  |-> calculaTotalDosPedidos()
```

```js
class Produtos
  |-> obterProdutos()
```

## Injeção de dependência

Quem deve cuidar da classe da especificação a ser iniciada é o momento da instanciação.

```ts
class NotaFiscal {
  gerarNota(ICalculoDosPedidos calculador) {

  }
}

interface ICalculoDosPedidos {
  calculaTotalDosPedidos() : number;
}

class CalculoPedidosBrasil implements ICalculoDosPedidos {

  constructor(private IProdutosRepository produtosRepository) {
    this._produtosRepository = produtosRepository
  }

  calculaTotalDosPedidos() {
    return this._produtosRepository.obterProdutos();
  }

  calculaTotalDosPedidos(IProdutosRepository produtosRepository) {
    return 10;
  }
}

interface IProdutosRepository {
  obterProdutos() : Produto[];
}
```

exemplo de instancia:

```ts
IBrasileiro felipe = new Paulista()
IProdutosRepository repository = new ProdutosRepository();
ICalculoDosPedidos calculador = new CalculoPedidosBrasil(repository);
NotaFiscal nota = new NotaFiscal();
nota.gerarNota(calculador);
```

```cs
public class UserService {

  private boolean _isLoggedIn;
  private IUserRepository _userRepository;

  public UserService(IUserRepository userRepository) {

  }

}
```

## Dependency Injection na prática

instalar a dependency injection no projeto.

### Criando classes injetáveis

> Genérico delimitado

```cs
public interface IRepository<T> where T : Entity {

  Task<IEnumerable<T>> GetAll();
  Task<T> GetById(int id);
  Task Save(T entity);
  Task Update(T entity);
  Task Delete(T entity);

}
```

```cs
public abstract class BaseRepository<T> : IRepository<T> where T : Entity {

  protected readonly ECommerceContext _dbContext;

  public BaseRepository(DbContext dbContext){
    _dbContext = dbContext;
  }

  public async Task<IEnumerable<T>> GetAll() {
    return await _dbContext.Set<T>().ToListAsync();
  }

  public async Task<T> GetById(int id) {
    return await _dbContext.Set<T>().FindAsync(id);
  }

  public async Task Add(T entity){
    await _dbContext.Set<T>().AddAsync(entity);
    await _dbContext.SaveChangesAsync();
  }

  public async Task Update(T entity){
    _dbContext.Set<T>().Update(entity);
    await _dbContext.SaveChangesAsync();
  }

  public async Task Delete(int id){
    var entity = await GetById(id);
    _dbContext.Set<T>().Remove(entity);
    await _dbContext.SaveChangesAsync();
  }
}
```

```cs
public interface IProductRepository : IRepository<Product> {

  Task<IEnumerable<Product>> GetByCategory(string category);

}
```

```cs
public class ProductRepository : BaseRepository<Product>, IProductRepository {
  public ProductRepository(DbContext context)
    : base(context) {
  }

  public async Task<T> GetByCategory(string category) {
    return await _dbContext
      .Set<Product>()
      .Where(p => p.Category.Equals(category))
      .FindAsync(category);
  }
}
```

```cs
public class PessoaRepository : BaseRepository<Pessoa> {
  public PessoaRepository(DbContext context)
    : base(context) {
  }
}
```

program.cs

```cs
builder.Services.AddScopped<IProductRepository, ProductRepository>();
```

### Tipos de configuração

1. Scoped: Uma única instância dentro de uma mesma requisição HTTP.

2. Transient: Todas as vezes que for injetado será fornecido uma nova instânicia.

3. Singleton: É uma mesma injeção de dependência durante toda a execução do aplicativo.

### Na prática

```cs
public class NotaFiscalController {

  private ICalculadorDeNotas _calculadorDeNotas;

  public NotaFiscalController(ICalculadorDeNotas calculatorDeNotas){
    _calculadorDeNotas = calculatorDeNotas;
  }
}
```

## Controller utilizando Repository Pattern

```cs
[ApiController]
[Route("products")]
public class ProductController : ControllerBase {

  public readonly IProductRepository _productRepository;

  public ProductController(IProductRepository productRepository) {
    _productRepository = productRepository;
  }

  [HttpGet]
  [ProducesResponseType]
  public async Task<IActionResult> GetAllProducts() {
    return Ok(_productRepository.GetAll());
  }

  [HttpPost]
  [ProducesResponseType]
  public async Task<IActionResult> RegisterProduct([FromBody] Product product) {
    _productRepository.Save(product);
    return Ok(_productRepository.GetAll());
  }
}
```

## Com serviços

```cs
public interface IUserService {
  Task<UserView> Login(LoginDto login);
}

public class UserService : IUserService {

  public readonly IUserRepository _userRepository;
  public readonly IMapper _mapper;

  public UserService(IUserRepository userRepository, IMapper mapper) {
    _userRepository = userRepository;
    _mapper = mapper;
  }

  public async Task<UserView> Login(LoginDto login) {
    var user = _userRepository.FindByUsername(login.Username);
    if(!user.Password.Equals(login.Password))
      throw NotAuthorizedUserException;

    return _mapper.map<UserView>(user);
  }

}
```

```cs
[ApiController]
[Route("/users")]
public class UserController : ControllerBase {

  public readonly IUserService _userService;

  public UserController(IUserService userService) {
    _userService = userService;
  }

  [HttpPost]
  [Route("/login")]
  public async Task<IActionResult> LoginUser(LoginDto login) {
    UserView user;

    try {
      user = _userService.Login(login);
    } catch (NotAuthorizedUserException) {
      return StatusCode(401);
    }

    return Ok(user);
  }
```
