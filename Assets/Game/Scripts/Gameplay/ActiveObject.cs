using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveObject : MonoBehaviour 
{
	[SerializeField] string _actionTextKey;
	public string actionTextKey { get { return _actionTextKey; }}

	public abstract void DoAction(GameplayCharacter character);
}
