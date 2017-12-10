﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VotingSceneScript : Scene<TransitionData>
{

	internal override void OnEnter(TransitionData data)
	{

	}

	internal override void OnExit()
	{
        
    }

    public void PlayAgain()
    {
        Services.GameManager.PrepareToSaveScene();
        Services.Scenes.PopScene();
        Services.Scenes.PopScene();
    }

    public void Back()
    {
        Services.Scenes.PopScene();
    }
}
