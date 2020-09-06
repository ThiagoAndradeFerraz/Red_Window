using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Inimigo1 : MonoBehaviour
{
    private float campoVisao = 20f;
    private float campoAtaque = 3f;
    private NavMeshAgent nvmAgent;
    private Transform player;
    public Animator anim;

    private void Start()
    {
        nvmAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    private void Update()
    {
        float distancia = Vector3.Distance(player.position, transform.position);

        if(distancia <= campoVisao)
        {
            nvmAgent.SetDestination(player.position); // Vai atrás do player...

            anim.SetFloat("speedAnim", 5);

            anim.SetBool("andando", true);

            if (distancia <= campoAtaque)
            {
                anim.SetFloat("speedAnim", 0);
                anim.SetBool("andando", false);

                // Atacar o alvo...
                anim.SetTrigger("h1");

                // Olhar alvo...
                VirarProAlvo();
            }

        }
        else
        {
            anim.SetBool("andando", false);
        }
    }

    private void VirarProAlvo()
    {
        
        nvmAgent.SetDestination(transform.position);

        Vector3 direcao = (player.position - transform.position);
        Quaternion rotacaoOlhar = Quaternion.LookRotation(new Vector3(direcao.x, 0, direcao.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacaoOlhar, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        // Campo de ataque
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, campoAtaque);

        // Campo de visão
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, campoVisao);
    }

}
