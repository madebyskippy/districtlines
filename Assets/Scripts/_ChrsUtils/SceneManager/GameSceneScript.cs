﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneScript : Scene<TransitionData>
{

    internal override void OnEnter(TransitionData data)
    {
        //  Use level loader like this
        //Services.LevelLoader.loadLevel(Level.TEXTURETEST);
    }

    internal override void OnExit()
    {

    }

	// Update is called once per frame
	void Update () {
		
	}
}
