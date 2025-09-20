# Projeto Toolkit Sigma — AV1
Disciplina: Computação Científica  
Professor: Prof. Dr. André Campos  
Alunos:
| Gabriel Guedes da Silva - 06004672
| Mauricio Grass de Bronstein - 06001816

# ProjetoToolkit — Aplicativo Console em C# (.NET 9)

## Descrição
Aplicativo console desenvolvido em **C# (.NET 9)** com um **menu de módulos** para estudo e prática de linguagens formais e lógica proposicional.  
O programa recebe entradas via console e apresenta saídas textuais, com exemplos documentados na pasta `prints/`.

---

## Funcionalidades implementadas

### 1. Verificador de alfabeto e cadeia (Σ = {a, b})
- **Entrada**: símbolo e cadeia  
- **Saída**: `PERTENCE`/`NÃO PERTENCE` para símbolos e `VÁLIDA`/`INVÁLIDA` para cadeias  
- **Exemplos**:  
  - Válido → `prints/item1_valido.png`  
  - Inválido → `prints/item1_invalido.png`

---

### 2. Classificador T/I/N por JSON
- Lista de problemas embutida em JSON  
- Usuário responde `T` (tratável), `I` (intratável) ou `N` (não computável)  
- Mostra **acertos e erros** com percentual final  
- **Exemplos**:  
  - Respostas → `prints/item2_resposta.png`  
  - Resumo final → `prints/item2_resumo.png`

---

### 3. Programa de decisão — termina com 'b'?
- **Entrada**: cadeia sobre Σ = {a, b}  
- **Saída**: `SIM` ou `NAO`  
- Trata casos vazios e valida pré-condições  
- **Exemplos**:  
  - SIM → `prints/item3_sim.png`  
  - NAO → `prints/item3_nao.png`

---

### 4. Avaliador proposicional básico
- **Entradas**: valores de `P`, `Q`, `R`  
- **Fórmulas avaliadas**:  
  1. `P ∧ Q` (conjunção)  
  2. `P ∨ Q` (disjunção)  
  3. `P → Q` (implicação)  
  4. `(P ∧ Q) → R` (implicação composta)  
- Opção de imprimir **tabela-verdade completa**  
- **Exemplos**:  
  - Resultado com valores + tabela → `prints/item4_valores_tabela.png`  
  - Tabela-verdade completa → `prints/item4_tabela_completa.png`

---

### 5. Reconhecedor Σ = {a, b} — L_par_a e L = a b*
- **L_par_a**: cadeias com número **par de 'a'**  
- **L = a b\***: cadeias do tipo `a` seguido de zero ou mais `b`  
- **Saída**: `ACEITA` ou `REJEITA`  
- Validação do alfabeto antes da decisão  
- **Exemplos**:  
  - ACEITA → `prints/item5_aceita.png`  
  - REJEITA → `prints/item5_rejeita.png`

---

## Como executar

### Pré-requisitos
- [.NET 9 SDK](https://dotnet.microsoft.com/download) instalado  
  Verifique com:
  ```bash
  dotnet --version
  ```

### Executar pelo terminal
Na pasta do projeto, rode:
```bash
dotnet run
```

---

### Executar pelo Visual Studio Code
1. Abra a pasta do projeto no VS Code  
2. Instale a extensão **C# Dev Kit**  
3. Pressione **F5** (debug) ou **Ctrl+F5** (executar sem debug)  
4. Ou use o terminal integrado: `dotnet run`

---

## Estrutura do projeto
```
ProjetoToolkit/
├── Program.cs              # Código principal com todos os módulos
├── ProjetoToolkit.csproj   # Arquivo de configuração do projeto
├── README.md               # Este arquivo
└── prints/                 # Screenshots de exemplo (pasta a ser criada)
    ├── item1_valido.png
    ├── item1_invalido.png
    ├── item2_resposta.png
    ├── item2_resumo.png
    ├── item3_sim.png
    ├── item3_nao.png
    ├── item4_valores_tabela.png
    ├── item4_tabela_completa.png
    ├── item5_aceita.png
    └── item5_rejeita.png
```

---

## Uso do programa
- Ao iniciar, o console apresenta um **menu de módulos**.  
- Basta digitar o número do módulo (1-5) e seguir as instruções na tela.  
- Digite `0` para sair do programa.  
- As saídas podem ser comparadas com os exemplos disponíveis na pasta `prints/`.

---

## Menu Principal
```
=== PROJETO TOOLKIT - AV1 FUNDAMENTOS PRÁTICOS ===

1. Verificador de Alfabeto e Cadeia
2. Classificador T/I/N por JSON
3. Programa de Decisão: 'Termina com b?'
4. Avaliador Proposicional Básico
5. Reconhecedor de Linguagens
0. Sair

Escolha uma opção:
```

---

## Tecnologias utilizadas
- **C# (.NET 9)**: Linguagem principal
- **System.Text.Json**: Deserialização de dados JSON
- **Console Application**: Interface de linha de comando
- **Programação estruturada**: Organização em classes e métodos

---

## Prints de execução
Os exemplos de entrada/saída estão organizados na pasta [`prints/`](prints/).  
Eles mostram os resultados esperados para cada módulo implementado.
