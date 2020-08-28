using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : Interativo
{
    protected override void DefinirInteracoes()
    {
        strInteracao = "[E] - Abrir porta";
    }

    protected override void Interagir1()
    {
        Debug.Log("droga, está trancado...");
    }

    protected override void Interagir2()
    {
        
    }

    protected override void PosDialogo()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        IniciarBase(3, "Porta");
    }

    // Update is called once per frame
    void Update()
    {
        DetectarPlayer();
    }
}
