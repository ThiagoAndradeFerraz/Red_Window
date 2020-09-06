using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QrtPlayer : MonoBehaviour
{
    private GameObject player;
    private Transform posicao;


    // Start is called before the first frame update
    void Start()
    {
        // Obtendo o gameobject de PLayer por tag...
        player = GameObject.FindGameObjectWithTag("Player");


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DeterminarPosicao()
    {
        
    }
}
