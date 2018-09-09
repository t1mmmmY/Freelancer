using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSystem : BaseSingleton<StarSystem> 
{
	public StarSystemObject[] stars;
	public StarSystemObject[] planets;
}

[System.Serializable]
public class StarSystemObject
{
	public string name;
	public SpaceObject spaceObject;
}