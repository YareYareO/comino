using UnityEngine;
using UnityEngine.UIElements;
using System;

public class MainMenuUI : MonoBehaviour
{
    State state;
    static VisualElement root;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        
        Button proceedButton = root.Q<Button>("ProceedButton");
        Button resetButton = root.Q<Button>("ResetButton");
        Button backButton = root.Q<Button>("BackButton");

        state = State.GetInstance();

        resetButton.clicked += () => state.SetState(0);
        backButton.clicked += () => state.SetState(state.CurrentState - 1);

        proceedButton.clicked += () => chooseList();

    }

    private void chooseList()
    {
        int currentState = state.CurrentState;
        string[] currentList = {"nothing"}; // somehow get rid of this
        
        switch(currentState)
        {
            case 0:
                currentList = MenuUtility.GetEnvironments();
                break;
            case 1: 
                currentList = MenuUtility.GetStartingpositions();
                break;
            case 2:
                currentList = MenuUtility.GetGoals();
                break;
            case 3: 
                StartSearch search = new StartSearch();
                search.StartSearching();
                break;
        }
        Debug.Log(currentState);

        if(currentState < 3)
        {
            createListUI(currentList);
        }
    }


    private void createListUI(string[] ListOfNames)
    {
        Func<VisualElement> makeItem = () => createClickableButton();
        Action<VisualElement, int> bindItem = (e, i) => (e as Button).text = ListOfNames[i];
        const int itemHeight = 30;

        var listView = new ListView(ListOfNames, itemHeight, makeItem, bindItem);
        listView.name = "ContentList";

        root.Q<VisualElement>("ListContainer").Add(listView);
    }


    private Button createClickableButton()
    {
        Button btn = new Button();
        btn.clicked += () => listItemClicked(btn.text);
        return btn;
    }


    private void listItemClicked(string buttonText)
    {
        Debug.Log(buttonText);
        proceedToState(buttonText);
        destroyList();
    }


    private void proceedToState(string value)
    {
        int proceedingState = state.CurrentState + 1;
        state.Proceed(proceedingState, value);
    }


    private void destroyList()
    {
        var listview = root.Q<VisualElement>("ContentList");
        root.Q<VisualElement>("ListContainer").Remove(listview);
    }

    public static void CreateErrorMessage(){
        Label notFoundMessage = new Label();
        notFoundMessage.text = "The Target could not be found, try again or something else.";
        notFoundMessage.name = "NotFoundMessage";
        root.Q<VisualElement>("AllContainer").Add(notFoundMessage);
    }

    public static void CleanErrorMessage(){
        if(root.Q<VisualElement>("NotFoundMessage") != null)
        {
            var message = root.Q<VisualElement>("NotFoundMessage");
            root.Q<VisualElement>("AllContainer").Remove(message);
        }

    }

}
