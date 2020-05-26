using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Escalavel : MonoBehaviour
{
    private GameObject player;
    private Text txtAlerta;
    private float distMin = 26.0f;
    private bool estdAgr = false;
    private bool estdAntes = true;
    private string mensagem = "[E] - ESCALAR";

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        txtAlerta = GameObject.FindGameObjectWithTag("txtAlerta").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectarPLayer();
    }

    private void DetectarPLayer()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) < distMin)
        {
            Debug.Log("perto");
            estdAgr = true;
            if (estdAgr != estdAntes)
            {

                txtAlerta.text = mensagem;
                estdAntes = estdAgr;
                //Interagir();
            }
            //Interagir();
        }
        else
        {
            Debug.Log("longe");
            estdAgr = false;
            if (estdAgr != estdAntes)
            {
                LimpaTexto();
                estdAntes = estdAgr;
            }
        }
    }

    private void LimpaTexto()
    {
        txtAlerta.text = " ";
    }


}