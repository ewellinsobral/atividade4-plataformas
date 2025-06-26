using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemRefrigeranteState : StateMachineBehaviour
{
    MaquinaRefrigerante maquina;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        maquina = animator.GetComponent<MaquinaRefrigerante>();
         if (maquina.estoque == 0)
        {
            maquina.animator.SetBool("estoquezerado", maquina.estoque <= 0);
            maquina.avisoTexto.text = "VAZIO";
        }
    }

}
