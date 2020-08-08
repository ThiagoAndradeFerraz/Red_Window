using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogModel
{
    // Classe modelo usada no processo de iteração de linhas...
    private string nome;
    private string fala;

    // NOME -----------------------------
    public string GetNome()
    {
        return nome;
    }
    public void SetNome(string nome)
    {
        this.nome = nome;
    }

    // FALA ----------------------------- 
    public string GetFala()
    {
        return fala;
    }
    public void SetFala(string fala)
    {
        this.fala = fala;
    }

    // Construtor -----------------------
    public DialogModel(string nome, string fala)
    {
        SetNome(nome);
        SetFala(fala);
    }
}
