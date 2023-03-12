// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UIElements;

// public class DownloadUI : MonoBehaviour
// {
//     public MainMenuUI mainmenu;

//     private VisualElement root;

//     private void OnEnable()
//     {
//         root = GetComponent<UIDocument>().rootVisualElement;
//         Button downloadButton = root.Q<Button>("DownloadButton");

//         downloadButton.clicked += () => createDownloadList();
//     }

//     private void createDownloadList()
//     {
//         string[] mapnames = FirebaseManager.RetrieveMapNames();
//         Button downloadButton = createClickableDownloadButton();

//         mainmenu.createListUI(mapnames, downloadButton);
//     }

//     private Button createClickableDownloadButton()
//     {
//         Button btn = new Button();
//         btn.clicked += () => downloadMap(btn.text);
//         btn.clicked += () => mainmenu.destroyList();
//         btn.AddToClassList("listitem");
//         return btn;
//     }

//     private void downloadMap(string mapname)
//     {
//         System.IO.File
//         .WriteAllText("C:\blahblah_yourfilepath\yourtextfile.txt", firstnameGUI + ", " + lastnameGUI);
//     }
// }

// we need this class when we use offline and online support, for now just online
