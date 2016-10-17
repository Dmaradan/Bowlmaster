using UnityEngine;
using System;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class ActionMasterTest {

	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;

	[Test]
	public void T01OneStrikeReturnsEndTurn()
	{
		ActionMaster actionMaster = new ActionMaster();
		Assert.AreEqual(endTurn, actionMaster.Bowl(10));
	}
}
