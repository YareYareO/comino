using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListItemHandler : MonoBehaviour
{
    public Button button;

    void Start()
    {
    button.onClick.AddListener(ButtonClicked);

    }
    private void ButtonClicked()
    {
        string ret = name;
        UIHelper.changeValue(ret);
    }
}
