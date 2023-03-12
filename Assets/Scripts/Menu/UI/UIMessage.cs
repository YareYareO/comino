using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIMessage : MonoBehaviour
{

    private static VisualElement root;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
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
