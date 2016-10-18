using UnityEngine;
using System;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class ActionMasterTest {

	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
	private ActionMaster.Action reset = ActionMaster.Action.Reset;

	private ActionMaster actionMaster;

	[SetUp]
	public void Setup() {
		actionMaster = new ActionMaster();
	}
	

	[Test]
	public void T01OneStrikeReturnsEndTurn()
	{
		Assert.AreEqual(endTurn, actionMaster.Bowl(10));
	}

	[Test]
	public void T02Bowl8ReturnsTidy () {
		Assert.AreEqual(tidy, actionMaster.Bowl(8));
	}

	// [Test]
	// public void T03TwoBowlsReturnReset () {
	// 	actionMaster.Bowl(2);
	// 	Assert.AreEqual(reset, actionMaster.Bowl(3));
	// }

	[Test]
	public void T0428ReturnsEndTurn() {
		actionMaster.Bowl(2);
		Assert.AreEqual(endTurn, actionMaster.Bowl(8));
	}
}
