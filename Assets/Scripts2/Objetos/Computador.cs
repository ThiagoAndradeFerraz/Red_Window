using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.UI;

public class Computador : Interativo
{
    private bool bloqueado = true; // Define se a senha já foi digitada ou não...

    // Objetos filhos do objeto de input...
    public Transform txtPlaceholder;
    public Transform txtInput;

    private string senha = "abc"; // Senha do computador...

    // Start is called before the first frame update
    void Start()
    {
        IniciarBase(3, "Computador");
    }

    // Update is called once per frame
    void Update()
    {
        DetectarPlayer();
        AguardarInput();
    }

    protected override void DefinirInteracoes()
    {
        strInteracao = "[E] - Usar";
        strInteracao2 = "[R] - Ver";
    }

    // Interação 1...
    protected override void Interagir1()
    {
        SetarIntr(1);
        IniciarDialogo("OBJETOS/Computador/PC-USAR-1");
    }

    // Interação 2...
    protected override void Interagir2()
    {
        SetarIntr(2);
        IniciarDialogo("OBJETOS/Computador/PC-VER1");
    }

    // Interação pós dialogo...
    protected override void PosDialogo()
    {
        // Pedindo senha do computador...
        GerenciadorInvt.Instancia.PausarParcialmente(0);
        GerenciadorInvt.Instancia.esperandoSenha = true;
        PedirSenha(true);
    }

    protected void PedirSenha(bool comando)
    {
        // Deixando o campo de entrada como clicavel...
        inputPC.GetComponent<InputField>().interactable = true;

        // Setando a transparencia do input field...
        Color cor = inputPC.GetComponent<Image>().color;
        float transparencia = comando ? 1 : 0;
        cor.a = transparencia;
        inputPC.GetComponent<Image>().color = cor;

        // Obtendo os objetos filhos...
        txtPlaceholder = inputPC.transform.GetChild(1);
        txtInput = inputPC.transform.GetChild(2);

        txtPlaceholder.GetComponent<Text>().text = comando ? "Digite sua senha" : " "; // O texto placeholder precisa variar de acordo com o idioma!!!
    }

    protected void AguardarInput()
    {
        if (GerenciadorInvt.Instancia.esperandoSenha)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                string entrada = inputPC.GetComponent<InputField>().text;
                if(entrada == senha)
                {
                    Debug.Log("Acesso autorizado! Bem-Vindo!");
                    
                }
                else
                {
                    Debug.Log("Senha incorreta. Acesso negado!");
                }
            }
        }
    }
}