using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManutencaoState : StateMachineBehaviour
{
    private MaquinaRefrigerante maquina;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        maquina = animator.GetComponent<MaquinaRefrigerante>();

        if (maquina.emManutencao)
        {
            maquina.avisoTexto.text = "MANUTENÇÃO";
            maquina.compartimentoRefrigerantes.SetActive(true);
        }
        else
        {
            maquina.compartimentoRefrigerantes.SetActive(false);
        }
    }
}
