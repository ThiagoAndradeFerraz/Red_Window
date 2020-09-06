using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortaQrtoPly : Interativo
{
    // ----------------------------
    // Porta do quarto do player...
    // ----------------------------

    public bool dentro; // Indica se a interação é de dentro ou de fora...

    protected override void DefinirInteracoes()
    {
        strInteracao = "[E] - Abrir porta";
    }

    protected override void Interagir1()
    {
        string cena = dentro ? "CORREDOR1" : "QUARTO_PLAYER";
        SceneManager.LoadScene(cena);
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
