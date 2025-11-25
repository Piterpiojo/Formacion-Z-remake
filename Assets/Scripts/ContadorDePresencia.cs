using UnityEngine;

public class ContadorDePresencia : StateMachineBehaviour
{
    private int ciclosRestantes;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ciclosRestantes = Random.Range(1, 5); // entre 1 y 4 ciclos
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Esperar a que termine un ciclo completo de Presencia
        if (stateInfo.normalizedTime >= 1f && !animator.IsInTransition(layerIndex))
        {
            ciclosRestantes--;

            if (ciclosRestantes <= 0)
            {
                animator.SetTrigger("Disparar");
                ciclosRestantes = Random.Range(1, 5); // reiniciar para la próxima vez
            }
        }
    }
}
