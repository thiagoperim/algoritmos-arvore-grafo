using System;

namespace TrabalhoAlgoritmos;

// no simples da arvore, guarda um numero e aponta pros dois lados
public class NoArvore
{
    public int Valor { get; set; }
    public NoArvore? Esquerda { get; set; }
    public NoArvore? Direita { get; set; }

    public NoArvore(int valor)
    {
        Valor = valor;
    }
}
