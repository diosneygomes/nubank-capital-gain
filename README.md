# Code Challenge: Ganho de Capital

## Contexto
O objetivo deste desafio é implementar um programa de linha de comando (CLI) que calcula o imposto a ser pago sobre lucros ou prejuízos de operações no mercado financeiro de ações.

## Como o programa deve funcionar?

### Entrada
O programa deve receber listas de operações do mercado financeiro de ações em formato JSON através da entrada padrão (stdin). Cada operação contém os seguintes campos:

| Nome       | Significado |
|------------|------------|
| operation  | Tipo da operação: compra (`buy`) ou venda (`sell`) |
| unit-cost  | Preço unitário da ação (duas casas decimais) |
| quantity   | Quantidade de ações negociadas |

#### Exemplo de entrada:
```json
[{"operation":"buy", "unit-cost":10.00, "quantity": 10000},
 {"operation":"sell", "unit-cost":20.00, "quantity": 5000}]
[{"operation":"buy", "unit-cost":20.00, "quantity": 10000},
 {"operation":"sell", "unit-cost":10.00, "quantity": 5000}]
```

Cada linha é uma simulação independente.

### Saída
Para cada linha de entrada, o programa deve retornar uma lista contendo o imposto pago para cada operação, no formato JSON, através da saída padrão (stdout).

| Nome | Significado |
|------|------------|
| tax  | Valor do imposto pago |

#### Exemplo de saída:
```json
[{"tax":0.00}, {"tax":10000.00}]
[{"tax":0.00}, {"tax":0.00}]
```

A lista retornada deve ter o mesmo tamanho da lista de operações processadas na entrada.

## Regras do Ganho de Capital

- O imposto pago é de **20% sobre o lucro** obtido na operação.
- O preço médio ponderado deve ser recalculado após cada compra.
- O prejuízo deve ser deduzido dos lucros futuros até ser totalmente compensado.
- Nenhum imposto é pago se o valor total da operação for **≤ R$ 20000,00**.
- Nenhum imposto é pago em operações de compra.

## Exemplos

### Caso #1

| Operação | Custo Unitário | Quantidade | Imposto Pago | Explicação |
|----------|---------------|------------|--------------|------------|
| buy  | 10.00 | 100  | 0 | Comprar ações não paga imposto |
| sell | 15.00 | 50   | 0 | Valor total menor do que R$ 20000 |
| sell | 15.00 | 50   | 0 | Valor total menor do que R$ 20000 |


#### Entrada:
```json
[{"operation":"buy", "unit-cost":10.00, "quantity": 100},
 {"operation":"sell", "unit-cost":15.00, "quantity": 50},
 {"operation":"sell", "unit-cost":15.00, "quantity": 50}]
```
#### Saída:
```json
[{"tax": 0.00},{"tax": 0.00},{"tax": 0.00}]
```

### Caso #2

| Operação | Custo Unitário | Quantidade | Imposto Pago | Explicação |
|----------|---------------|------------|--------------|------------|
| buy  | 10.00 | 10000 | 0 | Comprar ações não paga imposto |
| sell | 20.00 | 5000  | 10000 | Lucro de R$ 50000, paga 20% de imposto |
| sell | 5.00  | 5000  | 0 | Prejuízo de R$ 25000, não paga imposto |


#### Entrada:
```json
[{"operation":"buy", "unit-cost":10.00, "quantity": 10000},
 {"operation":"sell", "unit-cost":20.00, "quantity": 5000},
 {"operation":"sell", "unit-cost":5.00, "quantity": 5000}]
```
#### Saída:
```json
[{"tax": 0.00},{"tax": 10000.00},{"tax": 0.00}]
```

### Case #1 + Case #2

Quando a aplicação recebe duas linhas, elas devem ser lidadas como duas simulações independentes. O
programa não deve carregar o estado obtido do processamento da primeira entrada para as outras
execuções.

#### Entrada:
```json
[{"operation":"buy", "unit-cost":10.00, "quantity": 100},
 {"operation":"sell", "unit-cost":15.00, "quantity": 50},
 {"operation":"sell", "unit-cost":15.00, "quantity": 50}]
[{"operation":"buy", "unit-cost":10.00, "quantity": 10000},
 {"operation":"sell", "unit-cost":20.00, "quantity": 5000},
 {"operation":"sell", "unit-cost":5.00, "quantity": 5000}]
```

#### Saída:
```json
[{"tax": 0.00}, {"tax": 0.00}, {"tax": 0.00}]
[{"tax": 0.00}, {"tax": 10000.00}, {"tax": 0.00}]
```

Cada linha da entrada representa uma simulação separada e não deve compartilhar estado entre elas.

### Caso #3

| Operação | Custo Unitário | Quantidade | Imposto Pago | Explicação |
|----------|---------------|------------|--------------|------------|
| buy  | 10.00 | 10000 | 0 | Comprar ações não paga imposto |
| sell | 5.00  | 5000  | 0 | Prejuízo de R$ 25000, não paga imposto |
| sell | 20.00 | 3000  | 1000 | Lucro de R$ 30000, deduzindo prejuízo |


#### Entrada:
```json
[{"operation":"buy", "unit-cost":10.00, "quantity": 10000},
 {"operation":"sell", "unit-cost":5.00, "quantity": 5000},
 {"operation":"sell", "unit-cost":20.00, "quantity": 3000}]
```
#### Saída:
```json
[{"tax": 0.00},{"tax": 0.00},{"tax": 1000.00}]
```

### Caso #4

| Operação | Custo Unitário | Quantidade | Imposto Pago | Explicação |
|----------|---------------|------------|--------------|------------|
| buy  | 10.00 | 10000 | 0 | Comprar ações não paga imposto |
| buy  | 25.00 | 5000  | 0 | Comprar ações não paga imposto |
| sell | 15.00 | 10000 | 0 | Considerando o preço médio ponderado, não houve lucro |


#### Entrada:
```json
[{"operation":"buy", "unit-cost":10.00, "quantity": 10000},
 {"operation":"buy", "unit-cost":25.00, "quantity": 5000},
 {"operation":"sell", "unit-cost":15.00, "quantity": 10000}]
```
#### Saída:
```json
[{"tax": 0.00},{"tax": 0.00},{"tax": 0.00}]
```

### Caso #5

| Operação | Custo Unitário | Quantidade | Imposto Pago | Explicação |
|----------|---------------|------------|--------------|------------|
| buy  | 10.00 | 10000 | 0 | Comprar ações não paga imposto |
| buy  | 25.00 | 5000  | 0 | Comprar ações não paga imposto |
| sell | 15.00 | 10000 | 0 | Considerando preço médio ponderado, não houve lucro |
| sell | 25.00 | 5000  | 10000 | Lucro de R$ 50000, paga 20% de imposto |


#### Entrada:
```json
[{"operation":"buy", "unit-cost":10.00, "quantity": 10000},
 {"operation":"buy", "unit-cost":25.00, "quantity": 5000},
 {"operation":"sell", "unit-cost":15.00, "quantity": 10000},
 {"operation":"sell", "unit-cost":25.00, "quantity": 5000}]
```
#### Saída:
```json
[{"tax": 0.00},{"tax": 0.00},{"tax": 0.00},{"tax": 10000.00}]
```

### Caso #6

| Operação | Custo Unitário | Quantidade | Imposto Pago | Explicação |
|----------|---------------|------------|--------------|------------|
| buy  | 10.00 | 10000 | 0 | Comprar ações não paga imposto |
| sell | 2.00  | 5000  | 0 | Perda de R$ 40000, valor total menor que R$ 20000 |
| sell | 20.00 | 2000  | 0 | Lucro de R$ 20000, deduzindo prejuízo |
| sell | 20.00 | 2000  | 0 | Lucro de R$ 20000, prejuízo zerado |
| sell | 25.00 | 1000  | 3000 | Lucro de R$ 15000 sem prejuízos, paga 20% de imposto |


#### Entrada:
```json
[{"operation":"buy", "unit-cost":10.00, "quantity": 10000},
 {"operation":"sell", "unit-cost":2.00, "quantity": 5000},
 {"operation":"sell", "unit-cost":20.00, "quantity": 2000},
 {"operation":"sell", "unit-cost":20.00, "quantity": 2000},
 {"operation":"sell", "unit-cost":25.00, "quantity": 1000}]
```
#### Saída:
```json
[{"tax": 0.00},{"tax": 0.00},{"tax": 0.00},{"tax": 0.00},{"tax": 3000.00}]
```

### Caso #7

| Operação | Custo Unitário | Quantidade | Imposto Pago | Explicação |
|----------|---------------|------------|--------------|------------|
| buy  | 10.00 | 10000 | 0 | Comprar ações não paga imposto |
| sell | 2.00  | 5000  | 0 | Prejuízo de R$ 40.000: valor total menor que R$ 20000 |
| sell | 20.00 | 2000  | 0 | Lucro de R$ 20000, mas ainda há prejuízo para deduzir |
| sell | 20.00 | 2000  | 0 | Lucro de R$ 20000, prejuízo zerado |
| sell | 25.00 | 1000  | 3000 | Lucro de R$ 15000 sem prejuízos: paga 20% de R$ 15000 |
| buy  | 20.00 | 10000 | 0 | Nova compra, média ponderada muda para R$ 20 |
| sell | 15.00 | 5000  | 0 | Prejuízo de R$ 25000 |
| sell | 30.00 | 4350  | 3700 | Lucro de R$ 43500, deduzindo prejuízo de R$ 25000 |
| sell | 30.00 | 650   | 0 | Lucro de R$ 6500, mas valor total menor que R$ 20000 |


#### Entrada:
```json
[{"operation":"buy", "unit-cost":10.00, "quantity": 10000},
 {"operation":"sell", "unit-cost":2.00, "quantity": 5000},
 {"operation":"sell", "unit-cost":20.00, "quantity": 2000},
 {"operation":"sell", "unit-cost":20.00, "quantity": 2000},
 {"operation":"sell", "unit-cost":25.00, "quantity": 1000},
 {"operation":"buy", "unit-cost":20.00, "quantity": 10000},
 {"operation":"sell", "unit-cost":15.00, "quantity": 5000},
 {"operation":"sell", "unit-cost":30.00, "quantity": 4350},
 {"operation":"sell", "unit-cost":30.00, "quantity": 650}]
```
#### Saída:
```json
[{"tax":0.00}, {"tax":0.00}, {"tax":0.00}, {"tax":0.00}, {"tax":3000.00}, {"tax":0.00}, {"tax":0.00}, {"tax":3700.00}, {"tax":0.00}]
```

### Caso #8

| Operação | Custo Unitário | Quantidade | Imposto Pago | Explicação |
|----------|---------------|------------|--------------|------------|
| buy  | 10.00 | 10000 | 0 | Comprar ações não paga imposto |
| sell | 50.00 | 10000 | 80000 | Lucro de R$ 400000: paga 20% de imposto |
| buy  | 20.00 | 10000 | 0 | Comprar ações não paga imposto |
| sell | 50.00 | 10000 | 60000 | Lucro de R$ 300000: paga 20% de imposto |


#### Entrada:
```json
[{"operation":"buy", "unit-cost":10.00, "quantity": 10000},
 {"operation":"sell", "unit-cost":50.00, "quantity": 10000},
 {"operation":"buy", "unit-cost":20.00, "quantity": 10000},
 {"operation":"sell", "unit-cost":50.00, "quantity": 10000}]
```
#### Saída:
```json
[{"tax":0.00}, {"tax":80000.00}, {"tax":0.00}, {"tax":60000.00}]
```
## Estado da aplicação
O programa não deve depender de nenhum banco de dados externo e o estado interno da aplicação deve ser gerenciado em memória explicitamente por alguma estrutura que achar adequada. O estado da aplicação deve estar vazio sempre que a aplicação for inicializada.

## Arredondando Decimais
Para números decimais, o programa deve arredondar os valores para a segunda casa decimal. Por exemplo:
- Se houver a compra de 10 ações por R$ 20,00 e 5 ações por R$ 10,00, o preço médio ponderado é:
  
  \[
  \frac{(10 \times 20,00) + (5 \times 10,00)}{15} = 16.67
  \]

## Lidando com Erros
Você pode assumir que não ocorrerão erros na conversão do JSON de entrada. Na avaliação da sua solução, nós não vamos utilizar entradas que contenham erros, estejam mal formatadas ou que quebrem o contrato.

## Nossas Expectativas
Nós no Nubank valorizamos as seguintes qualidades:
- **Simplicidade**: espera-se da solução um projeto pequeno e de fácil entendimento.
- **Elegância**: espera-se da solução facilidade de manutenção, uma separação clara das responsabilidades e uma estrutura de código bem organizada.
- **Operacional**: espera-se da solução a resolução do problema, seus casos de borda ou extremos e a capacidade de extensão para futuras decisões de design.

Desta forma, procuraremos avaliar:
- Uso adequado de transparência referencial quando aplicável.
- Testes de unidade e integração de qualidade.
- Documentação onde for necessário.
- Instruções sobre como executar o código.

## Observações
- Você pode utilizar bibliotecas de código aberto (open source) que acredite serem adequadas para ajudar na solução do desafio, por exemplo, analisadores de JSON. Por favor, tente limitar o uso de frameworks e boilerplate code desnecessários.
- O desafio espera uma aplicação de linhas de comando independente. Por favor, evite adicionar infraestrutura desnecessária e/ou dependências externas. É esperado que você seja capaz de identificar as ferramentas necessárias para resolver o problema apresentado sem adicionar camadas extras de complexidade.

## Notas gerais
- Esse desafio poderá ser estendido por você e por outra pessoa engenheira do Nubank durante uma outra etapa do processo.
- O Ganho de Capital deve receber as operações através da entrada padrão (stdin) e retornar o resultado do processamento através da saída padrão (stdout), ao invés de uma API REST.

## Preparando seu desafio para envio
- Você deve entregar o código-fonte de sua solução para nós em um arquivo comprimido (zip) contendo o código e toda documentação possível. Favor não incluir arquivos desnecessários como binários compilados, bibliotecas, etc.
- Não faça o upload da sua solução em nenhum repositório público como GitHub, BitBucket, etc.
- Se estiver builds conteinerizados, não faça o upload da sua imagem em hubs públicos como DockerHub, Sloppy.io, etc.

## Remova informações pessoais
⚠️ **IMPORTANTE**: Por favor remova toda informação que possa lhe identificar nos arquivos do desafio antes de enviar a solução. Atenção especial para os seguintes pontos:
- Arquivos da solução como código, testes, namespaces, binários, comentários, e nomes dos arquivos.
- Comentários automáticos que seu editor de código pode ter adicionado aos arquivos.
- Documentação do código como annotations, metadata, e `README.md`.
- Informações de autoria do código e configuração do versionador de código.

Se você planeja utilizar git como sistema de controle de versões, execute o seguinte comando na raiz do repositório para exportar a solução anonimizada:

```bash
git archive --format=zip --output=./capital-gains.zip HEAD
````

## Implementação
## Decisões Técnicas e Arquiteturais
1. **Princípios do SOLID**:
   - A arquitetura foi desenhada para garantir responsabilidades bem definidas em cada componente. Handlers específicos (`BuyOperationHandler` e `SellOperationHandler`) tratam operações de compra e venda separadamente.
   - O padrão de contexto (`OperationContext`) mantém o estado de operações como preço médio, quantidade total e prejuízo acumulado.

2. **Factory Pattern**:
   - Implementado para determinar o handler correto com base no tipo de operação (`Buy` ou `Sell`), garantindo que a lógica de decisão esteja centralizada.

3. **Test-Driven Development (TDD)**:
   - Testes de unidade foram implementados com `xUnit` para cobrir todos os cenários relevantes, como cálculo de imposto, dedução de prejuízos e regras de isenção.

4. **Separação de Domínio e Infraestrutura**:
   - A lógica do cálculo está isolada em classes de domínio (`Handlers`, `Entities`), facilitando a manutenção e a extensibilidade.

---

## Justificativa para Uso de Frameworks ou Bibliotecas
1. **C# e .NET Core 8**:
   - O sistema foi desenvolvido em C# utilizando o .NET Core 8, garantindo alta performance, suporte a bibliotecas modernas e compatibilidade com práticas atuais de desenvolvimento.

2. **xUnit**:
   - Escolhido para testes de unidade devido à sua simplicidade e suporte nativo para o .NET.
   - Oferece uma abordagem clara e extensível para validação de cenários complexos.

---

## Instruções para Compilar e Executar o Projeto
1. **Pré-requisitos**:
   - Instale o .NET SDK (versão 8.0 ou superior).

2. **Compilar o Projeto**:
   - Navegue até o diretório raiz do projeto:
     ```bash
     cd CapitalGains/src/Nubank.CapitalGains.CLI
     ```
   - Compile o projeto:
     ```bash
     dotnet build
     ```

3. **Executar o Projeto**:
   - Para executar o programa com entrada direta via JSON:
     ```bash
     dotnet run
     ```
     Digite ou cole o JSON no console e aperte enter.
   - **Executar com um arquivo de entrada (`.json`)**:
     Crie um arquivo `input.json` contendo o JSON de entrada no formato esperado. Em seguida, execute:
     ```bash
     dotnet run < input.json
     ```

---

## Instruções para Executar os Testes
1. **Executar Todos os Testes**:
   - Navegue até o diretório de testes:
     ```bash
     cd CapitalGains/src/Nubank.CapitalGains.CLI.Tests
     ```
   - Execute os testes:
     ```bash
     dotnet test
     ```
