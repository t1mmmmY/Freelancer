using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotSeat : ActiveObject 
{
	[SerializeField] PlayerShipController spaceShip;
	[SerializeField] Transform characterPosition;

	public override void DoAction(GameplayCharacter character)
	{
		character.SitInPilotChair(spaceShip, characterPosition);
	}
}
