using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenciadorGlobal : MonoBehaviour
{
    private GameObject player;
    private Text txtObjt;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        txtObjt = GameObject.FindGameObjectWithTag("txtObjetivo").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetarObjetivo(string objetivo)
    {
        txtObjt.text = "Objetivo: " + objetivo;
    }

    public void LimparObjetivo()
    {
        txtObjt.text = " ";
    }
}
