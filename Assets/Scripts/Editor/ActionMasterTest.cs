using UnityEngine;
using System;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class ActionMasterTest {

	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action endGame = ActionMaster.Action.EndGame;
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

	[Test]
	public void T031AndSpareLastFrameReturnReset () {
		actionMaster.setBowl(19);
		actionMaster.Bowl(1);
		Assert.AreEqual(reset, actionMaster.Bowl(9));
	}

	[Test]
	public void T0428ReturnsEndTurn() {
		actionMaster.Bowl(2);
		Assert.AreEqual(endTurn, actionMaster.Bowl(8));
	}

	[Test]
	public void T05SetBowlActuallyWorks() {
		actionMaster.setBowl(19);
		Assert.AreEqual(19, actionMaster.getBowl());
	}

	[Test]
	public void T0619thBowlReturnsTidy() {
		actionMaster.setBowl(19);
		Assert.AreEqual(tidy, actionMaster.Bowl(1));
	}

	[Test]
	public void T07NoSpareInLastFrameReturnsEndGame() {
		actionMaster.setBowl(19);
		actionMaster.Bowl(3);
		Assert.AreEqual(endGame, actionMaster.Bowl(2));
	}
}
