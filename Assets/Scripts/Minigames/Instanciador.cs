using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : MonoBehaviour
{
    public GameObject peixePrefab;
    private float tempo;
    public float tpEspera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempo += Time.deltaTime;

        if (tempo > tpEspera)
        {
            InstanciarPeixe();
            tempo = 0;
        }

        
    }

    private void InstanciarPeixe()
    {
        Instantiate(peixePrefab, new Vector3(this.transform.position.x,
            this.transform.position.y, this.transform.position.z), Quaternion.identity);
    }
}