# Capital Gains Calculator

## Descrição do Projeto
Este projeto é uma solução para o Code Challenge: Capital Gains

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