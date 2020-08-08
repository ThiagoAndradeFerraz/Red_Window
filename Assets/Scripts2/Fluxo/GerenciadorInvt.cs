using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorInvt : MonoBehaviour
{
    // ========================================================
    // --------------------------------------------------------
    // DESCRIÇÃO: Classe dedicada a cuidar do inventario...
    // --------------------------------------------------------
    // ======================================================== 

    // Instancia statica... -------------------------------------
    public static GerenciadorInvt Instancia { get; private set; }
    // ----------------------------------------------------------

    // Inventário...
    public int contLampadas = 0;

    // Controle fala...
    public bool falando = false; // Indica se uma fala está sendo dita ou não...

    private void Awake()
    {
        // Aplicando singleton...
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
