using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventosAnimPL : MonoBehaviour
{
    // ********************************************************
    // Classe dedicada a guardar os animation events do player.
    // ********************************************************

    public Animator anim;

    // Indica que a animação de ataque foi encerrada...
    public void TerminarAtq1()
    {
        anim.SetBool("h1Bool", false);
    }
}
