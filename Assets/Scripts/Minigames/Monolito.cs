using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monolito : InterativoDialog
{
    public TextAsset arqTexto; // Texto a ser exibido em cena...
    private GameObject ponte;  


    protected override void Interagir()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            LimpaTexto(); // Limpando a UI...
            ChamarGerenciador(arqTexto); // Lendo e exibindo dados do arquivo de texto...
            LigarPonte();
        }
    }


    protected void LigarPonte()
    {
        ponte.transform.position = new Vector3(778, 39.9f, -22);  
    }



    // Start is called before the first frame update
    void Start()
    {
        ponte = GameObject.FindGameObjectWithTag("ponte");


        setarObjetos();
        setTexto("[E] - Despejar sangue");
        
    }

    // Update is called once per frame
    void Update()
    {
        distMin = 5f;
        DetectarPlayer();
    }
}
