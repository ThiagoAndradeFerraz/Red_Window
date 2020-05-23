using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casa : MonoBehaviour
{
    private GameObject playerObj;
    private GameObject objControle;
    private float distMin = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        objControle = GameObject.FindGameObjectWithTag("Controle_Global");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, playerObj.transform.position) < distMin)
        {
            
        }
        else
        {
            
        }
    }
}
