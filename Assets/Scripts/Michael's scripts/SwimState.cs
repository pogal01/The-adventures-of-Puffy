using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimState : StateMachineBehaviour
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
        ExpressionsScript.ChangeExpression();
        ExpressionsScript.EnableNormalEyes();
		if (CharacterControlerScript.PuffyState != CharacterControler.state.Swim)
		{
			CharacterControlerScript.PuffyState = CharacterControler.state.Swim;



		}
	}

	public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (CharacterControlerScript.PuffyState == CharacterControler.state.Swim)
		{
			if (CharacterControlerScript.LastCollider == GameObject.Find("Water_Tilemap").GetComponent<CompositeCollider2D>())
			{
				Animationscript.FlyAnimStart();
			}
		}
	}

}
