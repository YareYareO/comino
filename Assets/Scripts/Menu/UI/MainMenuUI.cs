using UnityEngine;
using UnityEngine.UIElements;
using System;

public class MainMenuUI : MonoBehaviour
{
    public FirebaseManager db;
    State state;
<<<<<<< HEAD
<<<<<<< HEAD
    private VisualElement root;
    Button proceedButton;
    public StartSearch search;
=======
    static VisualElement root;
>>>>>>> parent of b11f381 (Ui aufgeraeumt)
=======
    static VisualElement root;
>>>>>>> parent of b11f381 (Ui aufgeraeumt)

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

    private async void chooseList()
    {
        int currentState = state.CurrentState;
        string[] currentList = {"nothing"}; 
        
        switch(currentState)
        {
            case 0:
                currentList = await FirebaseManager.DB.RetrieveMapNames();
                break;
            case 1: 
                currentList = MenuUtility.GetStartingpositions();
                break;
            case 2:
                currentList = MenuUtility.GetGoals();
                break;
            case 3:
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

<<<<<<< HEAD
<<<<<<< HEAD
    private void setVisibilityProceedButton(bool wantToBeVisible)
    {
        if(wantToBeVisible)
        {
            proceedButton.style.visibility = Visibility.Visible;
        }
        else
        {
            proceedButton.style.visibility = Visibility.Hidden;
        }
        
    }
=======
>>>>>>> parent of b11f381 (Ui aufgeraeumt)
=======
>>>>>>> parent of b11f381 (Ui aufgeraeumt)

    private Button createClickableButton()
    {
        Button btn = new Button();
        btn.clicked += () => listItemClicked(btn.text);
        return btn;
    }


    private void listItemClicked(string buttonText)
    {
        proceedToState(buttonText);
        destroyList();
    }


    private void proceedToState(string value)
    {
        int proceedingState = state.CurrentState + 1;
        state.Proceed(proceedingState, value);
    }

    private bool thereIsAList()
    {
        return (root.Q<VisualElement>("ListContainer").childCount != 0);
    }

    private void destroyList()
    {
<<<<<<< HEAD
        if( thereIsAList() )
=======
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
>>>>>>> parent of b11f381 (Ui aufgeraeumt)
        {
            var listview = root.Q<VisualElement>("ContentList");
            root.Q<VisualElement>("ListContainer").Remove(listview);
            setVisibilityProceedButton(true);
        }
    }

    

}
