using UnityEngine;
using System.Collections;

public class ActionMaster {

	public enum Action {Tidy, Reset, EndTurn, EndGame};

	//private int[] bowls = new int[21];
	private int bowl = 1;

	public Action Bowl (int pins) {
		
		if(pins < 0 || pins > 10) {throw new UnityException("Invalid pin amount");}

		//other behavior

		if(pins == 10) {
			bowl += 2;
			return Action.EndTurn;
		} 

		if (bowl % 2 != 0) { // Mid frame (or last frame)
			bowl += 1;
			return Action.Tidy;
		} else {
			bowl += 1;
			return Action.EndTurn;
		}

		//other behavior

		throw new UnityException("Not sure what action to return!");
	}
}
