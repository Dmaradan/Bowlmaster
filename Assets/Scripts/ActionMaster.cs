using UnityEngine;
using System.Collections;

public class ActionMaster {

	public enum Action {Tidy, Reset, EndTurn, EndGame};

	private int[] bowls = new int[21];
	private int bowl = 1;

	public Action Bowl (int pins) {
		
		if(pins < 0 || pins > 10) {throw new UnityException("Invalid pin amount");}

		//last frame
		if(bowl == 19) {
			bowls[bowl - 1] = pins;

			if(pins == 10) {
				pins += 2;
				return Action.Reset;
			} else {
				bowl += 1;
				return Action.Tidy;
			}
		} else if(bowl == 20) {
			bowls[bowl - 1] = pins;
			if(bowls[18] + bowls[19] == 10) {
				//reset for last frame
				bowl += 1;
				return Action.Reset;
			} else {
				return Action.EndGame;
			} 
		}


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

	public void setBowl(int theBowl) {
		bowl = theBowl;
	}

	public int getBowl() {
		return bowl;
	}

	public int getSum() {
		return bowls[18] + bowls[19];
	}

	public int readNineteen() {
		return bowls[18];
	}

	public int readTwenty() {
		return bowls[19];
	}
}
