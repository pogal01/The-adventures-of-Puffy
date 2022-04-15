using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationStates : StateMachineBehaviour
{
    private Expressions ExpressionsScript;
	private CharacterControler CharacterControlerScript;
	private PlayerAnimationControler Animationscript;

	private void Awake()
    {
        ExpressionsScript = GameObject.Find("Puffy").GetComponent<Expressions>();
		CharacterControlerScript = GameObject.Find("Puffy").GetComponent<CharacterControler>();
		Animationscript = GameObject.Find("Puffy").GetComponent<PlayerAnimationControler>();
	}

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ExpressionsScript.DisableFace();
    }
	public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if(!CharacterControlerScript.swimming)
		{
			if (CharacterControlerScript.LastCollider == GameObject.Find("Sky").GetComponent<BoxCollider2D>())
			{
				Animationscript.FlyAnimFin();
				Animationscript.StartSwim();


			}
		}
	
	}



	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	//{
	//    
	//}
	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ExpressionsScript.ChangeExpression();
    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
