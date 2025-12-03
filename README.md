# trabalho de arvore binaria e grafo (console em c#)

esse aqui é um projetinho de faculdade pra mostrar como funciona uma arvore binaria de busca (bst) e um grafo com lista de adjacencia. tudo roda no console e foi feito pra ser simples, nada chique.

## tecnologias usadas
- c#
- .net 8.0
- app de console mesmo

## como rodar
1. precisa ter o .net sdk instalado.
2. entra na pasta `src/TrabalhoAlgoritmos`.
3. rodar com `dotnet run`.

## o que dá pra fazer
- menu principal deixa escolher entre arvore, grafo ou sair.
- na arvore:
  - criar/resetar a arvore
  - enfiar nó
  - buscar um valor
  - ver maior valor
  - ver menor valor
  - imprimir a arvore em ordem
- no grafo:
  - criar grafo
  - adicionar aresta (nao direcionada)
  - adicionar arco (direcionada)
  - procurar se existe aresta/arco
  - imprimir grafo

## sobre os menus
- só dá pra sair pelo menu principal (opção 0).
- os submenus sempre têm opção de voltar pro principal, sem fechar o programa de cara.

## estrutura do projeto
- `src/TrabalhoAlgoritmos/Program.cs`
- `src/TrabalhoAlgoritmos/ArvoreBinaria.cs`
- `src/TrabalhoAlgoritmos/NoArvore.cs`
- `src/TrabalhoAlgoritmos/Grafo.cs`
