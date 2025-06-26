using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendendoState : StateMachineBehaviour
{
    private MaquinaRefrigerante maquina;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        maquina = animator.GetComponent<MaquinaRefrigerante>();

        if (maquina != null)
        {
            maquina.avisoTexto.text = "ENTREGANDO...";
            maquina.AbrirCompartimento(); 

            maquina.Invoke(nameof(maquina.FecharCompartimento), 2f); 

            // Desabilita os botões durante a entrega
            maquina.btnInserir.interactable = false;
            maquina.btnCancelar.interactable = false;
            maquina.btnComprar.interactable = false;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (maquina != null)
        {
            maquina.avisoTexto.text = "";

           
            maquina.btnInserir.interactable = true;
            maquina.btnCancelar.interactable = true;
            maquina.btnComprar.interactable = true;
        }
    }
}
