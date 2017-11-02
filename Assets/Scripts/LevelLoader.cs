﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public enum Level
{
    TEXTURETEST, MAPTEST, CALIFORNIA_STATE, FLORIDA_STATE, OHIO_STATE, NEWYORK_NYC 
}

public class LevelLoader : MonoBehaviour
{
    public const string LEVEL_PATH = "";

    public Texture2D textureMap;


    private districtMap districtMap;

    public void setDistrictMap(districtMap map)
    {
        districtMap = map;
    }

    public void loadLevel(Level lvl, Vector2 lvlDimension)
    {
        Assert.IsNotNull(districtMap, "This district map has not been set for the Level Loader");

        textureMap = Resources.Load<Texture2D>("Levels/"+lvlDimension.x.ToString() + "x" + lvlDimension.y.ToString()
                                        + "_" + lvl.ToString());

        for (int x = 0; x < textureMap.width; x++)
        {
            for (int y = 0; y < textureMap.height; y++)
            {
                if (textureMap.GetPixel(x, y) != Color.white)
                {
                    //  Do something or nothing
                    gridSpace space = Instantiate(districtMap.getCountryPrefab(), new Vector3(x, 0, y), Quaternion.identity).GetComponent<gridSpace>();
                    space.transform.parent = Services.Scenes.CurrentScene.transform;
                    int totalInArea = Random.Range(1, 10); //total of 9 "people"
                    int firstGroup = Random.Range(0, totalInArea);
                    if (firstGroup == totalInArea / 2.0f)
                    {
                        //prevent ties, we can't handle them right now
                        firstGroup++;
                    }

                    space.setGroups(firstGroup, totalInArea - firstGroup);

                    space.setDistrict(-1);
                    space.setGridPos(x, y);

                    space.setCirclePartyPopulation(firstGroup);
                    space.setTrianglePartyPopulation((totalInArea - firstGroup));

                    districtMap.addGridSpaceToMap(space);
                    districtMap.setGridCoordinates(new Vector2(x, y), space);
                    districtMap.setCountyPopulation(new int[] { firstGroup, (totalInArea - firstGroup) });
                }
                else
                {
                    //  Do something else or nothing
                    Debug.Log("Not White");
                }
            }
        }
    }
}