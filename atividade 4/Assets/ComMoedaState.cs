using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComMoedaState : StateMachineBehaviour
{
    private MaquinaRefrigerante maquina;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        maquina = animator.GetComponent<MaquinaRefrigerante>();
        
        if (maquina != null && maquina.temMoeda)
        {
            maquina.avisoTexto.text = "OK";
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (maquina != null)
        {
            maquina.avisoTexto.text = "";
        }
    }
}


