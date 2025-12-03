using System;
using System.Collections.Generic;

namespace TrabalhoAlgoritmos;

// arvore binaria de busca bem basica: guarda int, busca, insere e imprime em ordem
public class ArvoreBinaria
{
    private NoArvore? raiz;

    public bool EstaVazia => raiz is null;

    public void CriarArvore()
    {
        raiz = null;
    }

    public void Inserir(int valor)
    {
        raiz = InserirRecursivo(raiz, valor);
    }

    public bool Buscar(int valor)
    {
        return BuscarRecursivo(raiz, valor);
    }

    public int? MaiorValor()
    {
        if (raiz is null)
        {
            return null;
        }

        var atual = raiz;
        while (atual.Direita is not null)
        {
            atual = atual.Direita;
        }

        return atual.Valor;
    }

    public int? MenorValor()
    {
        if (raiz is null)
        {
            return null;
        }

        var atual = raiz;
        while (atual.Esquerda is not null)
        {
            atual = atual.Esquerda;
        }

        return atual.Valor;
    }

    public List<int> ObterValoresEmOrdem()
    {
        var valores = new List<int>();
        PercorrerEmOrdem(raiz, valores);
        return valores;
    }

    private NoArvore InserirRecursivo(NoArvore? atual, int valor)
    {
        if (atual is null)
        {
            return new NoArvore(valor);
        }

        if (valor < atual.Valor)
        {
            atual.Esquerda = InserirRecursivo(atual.Esquerda, valor);
        }
        else
        {
            // se for igual eu jogo pra direita mesmo
            atual.Direita = InserirRecursivo(atual.Direita, valor);
        }

        return atual;
    }

    private bool BuscarRecursivo(NoArvore? atual, int valor)
    {
        if (atual is null)
        {
            return false;
        }

        if (valor == atual.Valor)
        {
            return true;
        }

        return valor < atual.Valor
            ? BuscarRecursivo(atual.Esquerda, valor)
            : BuscarRecursivo(atual.Direita, valor);
    }

    private void PercorrerEmOrdem(NoArvore? atual, List<int> valores)
    {
        if (atual is null)
        {
            return;
        }

        PercorrerEmOrdem(atual.Esquerda, valores);
        valores.Add(atual.Valor);
        PercorrerEmOrdem(atual.Direita, valores);
    }
}
