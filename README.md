
# Desafio Muralis - Desenvolvedor .NET Jr.

Este projeto foi desenvolvido como parte de um **desafio técnico para a vaga de Desenvolvedor .NET Júnior** na empresa **Muralis**. O objetivo foi aplicar boas práticas de desenvolvimento, com foco na arquitetura limpa e nos princípios do SOLID, criando uma base sólida para um sistema de cadastro e gerenciamento de clientes.

## 📌 Tecnologias Utilizadas

- **.NET 8**
- **Entity Framework Core**
- **PostgreSQL**
- **Swagger para documentação da API**
- **AutoMapper**
- **Arquitetura em camadas com Clean Architecture**

## 🧱 Estrutura do Projeto

O projeto está estruturado com base na **Clean Architecture**, separando responsabilidades em camadas distintas:

```
DesafioMuralis
├── Domain           -> Entidades e interfaces (core do domínio)
├── Application      -> Casos de uso (interactors)
├── Infrastructure   -> Repositórios, contexto EF e integrações externas (ex: busca de CEP)
├── API              -> Controladores e configurações da aplicação
```

---

## 🧠 Aplicação dos Princípios SOLID

Durante o desenvolvimento, busquei aplicar os princípios do **SOLID** da seguinte forma:

### ✅ S - Single Responsibility Principle (Responsabilidade Única)
- Cada classe tem uma responsabilidade bem definida. Por exemplo, o `Cliente` é responsável por representar a entidade e validar seu estado, enquanto os casos de uso lidam com regras específicas de aplicação.

### ✅ O - Open/Closed Principle (Aberto/Fechado)
- Os serviços e repositórios são extensíveis sem a necessidade de alterar a lógica central, permitindo adicionar novos comportamentos com baixo impacto.

### ✅ L - Liskov Substitution Principle (Substituição de Liskov)
- As abstrações são respeitadas, permitindo que qualquer implementação de `IClienteRepository`, por exemplo, possa ser usada sem comprometer a aplicação.

### ✅ I - Interface Segregation Principle (Segregação de Interfaces)
- Interfaces foram criadas de forma a não forçar implementações desnecessárias. Os repositórios implementam apenas os métodos que realmente utilizam.

### ✅ D - Dependency Inversion Principle (Inversão de Dependência)
- A camada de aplicação depende de **interfaces** e não de implementações concretas, permitindo maior flexibilidade e testabilidade.

---

## ⚙️ Funcionalidades Implementadas

- Cadastro de cliente com validação de CEP via serviço externo
- Atualização de dados do cliente
- Estrutura pronta para consulta e remoção
- Mapeamento entre ViewModel e entidade usando AutoMapper
- Documentação da API com Swagger

---

## 📄 Como Executar

1. Clone o repositório:
   ```bash
   git clone https://github.com/RobertoSantos98/DesafioMuralis.git
   ```
2. Configure o banco de dados PostgreSQL local
3. Atualize a string de conexão em `ConnectionContext.cs`
4. Execute as migrações com o EF Core:
   ```bash
   dotnet ef database update
   ```
   ou
   ```bash
   database-update
   ```
5. Inicie o projeto:
   ```bash
   dotnet run --project DesafioMuralis.API
   ```
6. Acesse a documentação Swagger em `http://localhost:5000/swagger`

---

## 🤝 Considerações

Este projeto foi uma excelente oportunidade para praticar conceitos fundamentais do desenvolvimento backend com .NET, com foco em **boas práticas, organização de código e separação de responsabilidades**. Agradeço pela oportunidade de participar do processo seletivo.

---

**Desenvolvido por:** Roberto Santos  
🔗 [LinkedIn](https://www.linkedin.com/in/robertosantos98)

```
