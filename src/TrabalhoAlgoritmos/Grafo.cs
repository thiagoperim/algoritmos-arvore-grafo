using System;
using System.Collections.Generic;

namespace TrabalhoAlgoritmos;

// grafo com lista de adjacencia, bem direto: cria, coloca aresta/arco, procura e imprime
public class Grafo
{
    private Dictionary<int, List<int>> adjacencias = new();
    private int quantidadeVertices;

    public bool FoiCriado => quantidadeVertices > 0;
    public int QuantidadeVertices => quantidadeVertices;

    public void CriarGrafo(int quantidade)
    {
        quantidadeVertices = quantidade;
        adjacencias = new Dictionary<int, List<int>>();

        for (int i = 0; i < quantidadeVertices; i++)
        {
            adjacencias[i] = new List<int>();
        }
    }

    public bool AdicionarAresta(int origem, int destino)
    {
        if (!VerticesValidos(origem, destino))
        {
            return false;
        }

        AdicionarVizinho(origem, destino);
        AdicionarVizinho(destino, origem);
        return true;
    }

    public bool AdicionarArco(int origem, int destino)
    {
        if (!VerticesValidos(origem, destino))
        {
            return false;
        }

        AdicionarVizinho(origem, destino);
        return true;
    }

    public bool ExisteAresta(int v1, int v2)
    {
        return FoiCriado && VerticeValido(v1) && VerticeValido(v2) && adjacencias[v1].Contains(v2);
    }

    public Dictionary<int, List<int>> ObterAdjacencias()
    {
        return adjacencias;
    }

    private bool VerticesValidos(int origem, int destino)
    {
        return VerticeValido(origem) && VerticeValido(destino);
    }

    public bool VerticeValido(int vertice)
    {
        return vertice >= 0 && vertice < quantidadeVertices;
    }

    private void AdicionarVizinho(int origem, int destino)
    {
        if (!adjacencias[origem].Contains(destino))
        {
            adjacencias[origem].Add(destino);
        }
    }
}
