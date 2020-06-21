using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleGlobal : MonoBehaviour
{
    // Controle de fase...
    private string idioma = "PT-BR"; // O valor da variavel tem que ser setado pelo usuario!!!!!
    private int idCena = 1;

    // Contadores
    private int contComestiveis = 0;



    public static ControleGlobal Instancia { get; private set; } // Instancia unica...

    private void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public string GetIdioma()
    {
        return idioma;
    }

    // =================================

    public int GetIdCena()
    {
        return idCena;
    }

    public void SetIdCena(int novaId)
    {
        idCena = novaId;
    }
    // =================================

    public int GetContComestiveis()
    {
        return contComestiveis;
    }

    public void SetContComestiveis()
    {
        contComestiveis++;
    }

    // =================================
}
