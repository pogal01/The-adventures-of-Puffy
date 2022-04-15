using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimState : StateMachineBehaviour
{
    private Expressions ExpressionsScript;
	private CharacterControler CharacterControlerScript;
	
	private void Awake()
    {
        ExpressionsScript = GameObject.Find("Puffy").GetComponent<Expressions>();
		CharacterControlerScript = GameObject.Find("Puffy").GetComponent<CharacterControler>();
	}

    // public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
    //     ExpressionsScript.ChangeExpression();
    //     ExpressionsScript.EnableNormalEyes();
	// 	if (!CharacterControlerScript.swimming)
	// 	{
	// 		CharacterControlerScript.swimming = true;



	// 	}
	// }

	// public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	// {
	// 	if (!CharacterControlerScript.swimming)
	// 	{
	// 		CharacterControlerScript.swimming = true;



	// 	}
	// }

}
