using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    private static State stateInstance;

    public int CurrentState{get; private set;}

    private State(int state){ CurrentState = state; }

    public static State GetInstance()
    {
        if(stateInstance == null){
            stateInstance = new State(0);
        }
        return stateInstance;
    }

    public void Proceed(int wantedState, string value)
    {
        if(wantedState > CurrentState){
            setSearchData(value);
        }
        SetState(wantedState);
        updateUI();
    }

    public void SetState(int wantedState)
    {
        CurrentState = wantedState;
    }

    private void setSearchData(string value)
    {
        switch(CurrentState)
        {
            case 0: 
                SearchData.ChosenEnvironment = value;
                break;
            case 1: 
                SearchData.setStartPFromString(value);
                break;
            case 2: 
                SearchData.setTargetFromString(value);
                break; 
        }
    }

    private void updateUI()
    {
        updateButton();
        updateText();
    }

    private void updateButton(){}

    private void updateText(){}

}
