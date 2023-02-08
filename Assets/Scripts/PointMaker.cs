/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
    using UnityEditor;
#endif
using System.IO;
using System;
using System.Globalization;

public class PointMaker : MonoBehaviour
{
    #if UNITY_EDITOR

        internal static int counter;
        static GameObject ObjectToCopy;

        [MenuItem("ARLocation/Create New Point")]
        static void PointMake()
        {
            ObjectToCopy = GameObject.Find("Point0");
            if(ObjectToCopy == null)
            {
                counter = 0;
            }

            GameObject CopiedObject = Instantiate(Resources.Load("RealPoint") as GameObject);
            CopiedObject.transform.position = new Vector3(0,0,0);

            CopiedObject.name = "Point" + counter;
            counter++;
        }

        

        [MenuItem("ARLocation/Read File")]
        static void ReadTextFile()
        {
            string wholeText;
            string[] lines;
            string pathToFile = "Assets/Resources/Pointslist.txt";
            StreamReader reader = new StreamReader(pathToFile);
            wholeText = reader.ReadToEnd().ToString();

            lines = wholeText.Split(new string[] {"NEXT"}, StringSplitOptions.None);
            for(int i = 0; i < lines.Length-1; i++)
            {
                if(lines[i].Contains("POINT"))
                {
                    lines[i] = lines[i].Remove(lines[i].Length-5, 5);
                    print(lines[i]);
                    StartProcess(lines[i]);
                }
            }
            reader.Close();
        }

        private static void StartProcess(string text)
        {
            var Obj = StringToVector3(text);
            string S = Vector3ToString(Obj);
            GameObject GameObj = Instantiate(Resources.Load("Point") as GameObject);
            GameObj.transform.position = new Vector3(Obj.PosX, Obj.PosY, Obj.PosZ);
            GameObj.transform.localEulerAngles = new Vector3(Obj.RotX, Obj.RotY, Obj.RotZ);
            GameObj.transform.localScale = new Vector3(Obj.ScaX, Obj.ScaY, Obj.ScaZ);
            GameObj.name = Obj.Name;
        }

        private static ObjectTransform StringToVector3(string s)
        {
            string[] information = s.Split('_');
            ObjectTransform objectTransform = new ObjectTransform();
            objectTransform.Name = information[0].Remove(0,2);
            objectTransform.PosX = GiveMe(information[1]);
            objectTransform.PosY = GiveMe(information[2]);
            objectTransform.PosZ = GiveMe(information[3]);
            objectTransform.RotX = GiveMe(information[4]);
            objectTransform.RotY = GiveMe(information[5]);
            objectTransform.RotZ = GiveMe(information[6]);
            objectTransform.ScaX = GiveMe(information[7]);
            objectTransform.ScaY = GiveMe(information[8]);
            objectTransform.ScaZ = GiveMe(information[9]);
            return objectTransform;
        }

        private static float GiveMe(string s)
        {
            s = s.Remove(0, 3);
            return float.Parse(s, CultureInfo.InvariantCulture.NumberFormat);
        }

        private static string Vector3ToString(ObjectTransform objTransform)
        {
            string Name = "N:" + objTransform.Name;
            string PosX = "PX:" + objTransform.PosX;
            string PosY = "PY:" + objTransform.PosY;
            string PosZ = "PZ:" + objTransform.PosZ;
            string RotX = "RX:" + objTransform.RotX;
            string RotY = "RY:" + objTransform.RotY;
            string RotZ = "RZ:" + objTransform.RotZ;
            string ScaX = "SX:" + objTransform.ScaX;
            string ScaY = "SY:" + objTransform.ScaY;
            string ScaZ = "SZ:" + objTransform.ScaZ;
            return Name + "_" + PosX + "_" + PosY + "_" + PosZ + "_" + RotX + "_" + RotY + "_" + RotZ + "_" + ScaX + "_" + ScaY + "_" + ScaZ + "kh";
        }

        [System.Serializable]
        public struct ObjectTransform
        {
            public string Name;
            public float PosX;
            public float PosY;
            public float PosZ;
            public float RotX;
            public float RotY;
            public float RotZ;
            public float ScaX;
            public float ScaY;
            public float ScaZ;
        }

    #endif
}
*/