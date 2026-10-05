# Desafio Target

Implementação do desafio técnico para a vaga de Desenvolvedor.

O projeto consiste em uma aplicação de console desenvolvida em **C# / .NET**, contendo as três funcionalidades propostas no desafio.

## Tecnologias utilizadas

* C#
* .NET
* JSON
* Git

## Funcionalidades

### 1. Cálculo de comissão

Lê os dados de vendas a partir de um arquivo JSON e calcula a comissão de cada vendedor conforme as regras:

| Valor da venda                       | Comissão |
| ------------------------------------ | -------: |
| Abaixo de R$ 100,00                  |       0% |
| De R$ 100,00 até abaixo de R$ 500,00 |       1% |
| A partir de R$ 500,00                |       5% |

Os valores monetários são tratados utilizando `decimal`.

### 2. Movimentação de estoque

Permite realizar movimentações de entrada e saída de produtos a partir dos dados de estoque fornecidos em JSON.

A funcionalidade:

* Localiza o produto pelo código;
* Permite movimentações de entrada e saída;
* Valida o tipo de movimentação;
* Valida a quantidade informada;
* Impede saída superior ao estoque disponível;
* Gera um identificador único para cada movimentação;
* Exibe o estoque anterior e o estoque final;
* Permite realizar múltiplas movimentações antes de retornar ao menu principal.

As alterações de estoque são mantidas apenas durante a execução da aplicação, não havendo persistência em banco de dados, pois isso não foi solicitado no desafio.

### 3. Cálculo de juros

Calcula os juros de acordo com o valor informado e a quantidade de dias de atraso em relação à data atual.

Foi considerada uma taxa de **2,5% ao dia**.

Como o enunciado não especifica o regime de capitalização, foi adotado o cálculo de **juros simples**, aplicando a taxa sobre o valor original para cada dia de atraso.

Exemplo:

```text
Valor: R$ 100,00
Dias de atraso: 3
Taxa: 2,5% ao dia

Juros: R$ 7,50
Valor total: R$ 107,50
```

Datas são informadas no formato `dd/MM/yyyy`.

## Estrutura do projeto

```text
DesafioTarget/
├── Data/
│   ├── estoque.json
│   └── vendas.json
│
├── Models/
│   ├── EstoqueData.cs
│   ├── MovimentacaoEstoque.cs
│   ├── ProdutoEstoque.cs
│   ├── Venda.cs
│   └── VendasData.cs
│
├── Services/
│   ├── ComissaoService.cs
│   ├── EstoqueService.cs
│   └── JurosService.cs
│
├── Program.cs
└── README.md
```

## Como executar

É necessário ter o **.NET SDK** instalado.

Clone o repositório e acesse a pasta do projeto:

```bash
git clone https://github.com/pedrold10/desafio-vendas-target-system.git
cd DesafioTarget
```

Execute:

```bash
dotnet run
```

O programa apresentará um menu com as três funcionalidades:

```text
================================
         DESAFIO TARGET
================================

1 - Calcular comissões
2 - Movimentar estoque
3 - Calcular juros
0 - Sair
```

## Organização

As regras de negócio foram separadas em serviços específicos:

* `ComissaoService` — cálculo das comissões;
* `EstoqueService` — regras de movimentação de estoque;
* `JurosService` — cálculo dos juros.

Os arquivos JSON são utilizados como fonte dos dados fornecidos pelo desafio.

O projeto foi mantido propositalmente simples, sem adoção de camadas ou padrões arquiteturais desnecessários para o escopo proposto.
