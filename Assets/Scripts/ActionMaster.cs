using UnityEngine;
using System.Collections;

public class ActionMaster {

	public enum Action {Tidy, Rest, EndTurn, EndGame};



	public Action Bowl (int pins) {
		
		if(pins < 0 || pins > 10) {throw new UnityException("Invalid pin amount");}

		//other behavior

		if(pins == 10) {
			return Action.EndTurn;
		}

		//other behavior

		throw new UnityException("Not sure what action to return!");
	}
}
