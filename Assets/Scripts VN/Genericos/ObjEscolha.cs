using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjEscolha
{
    public int idCena;
    public string falaSim;
    public string falaNao;

    public ObjEscolha(int id, string sim, string nao)
    {
        idCena = id;
        falaSim = sim;
        falaNao = nao;
    }

    public int GetId()
    {
        return idCena;
    }

    public string GetSim()
    {
        return falaSim;
    }

    public string GetNao()
    {
        return falaNao;
    }
}
