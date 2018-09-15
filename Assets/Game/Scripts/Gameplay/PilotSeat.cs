using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotSeat : ActiveObject 
{
	[SerializeField] PlayerShipController spaceShip;
	public Transform seatPosition;
	public Transform getUpPosition;

	public override void DoAction(GameplayCharacter character)
	{
		character.SitInPilotChair(spaceShip, this);
	}
}
