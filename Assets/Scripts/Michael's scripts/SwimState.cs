using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimState : StateMachineBehaviour
{
    private Expressions ExpressionsScript;

    private void Awake()
    {
        ExpressionsScript = GameObject.Find("Puffy").GetComponent<Expressions>();
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ExpressionsScript.ChangeExpression();
        ExpressionsScript.EnableNormalEyes();
    }

}
