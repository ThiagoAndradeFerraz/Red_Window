using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : Interativo
{
    // -------------------------------------
    // DESCRIÇÃO: CLASSE ABSTRATA PARA NPCS 
    // -------------------------------------

    // ***********************
    protected int estagioIntr = 1; // Define qual é o estágio de interação disponível...

    // ***********************
    // ***********************

    // Método publico para o sistema de save definir o estado de certas variaveis...
    public void LoadVariaveis()
    {
        // TEMPORÁRIO, PRECISA IMPLEMENTAR DIREITO DEPOIS!
    }

}
