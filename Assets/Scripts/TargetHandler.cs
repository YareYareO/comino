using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHandler : MonoBehaviour
{
    [System.Serializable]
    public abstract class Point
    {
        public string Name;
        public float PosX;
        public float PosY;
        public float PosZ;
        public float RotY;
    }
    [System.Serializable]
    public class StartingPosition : Target
    {}

    [System.Serializable]
    public class Target : Point
    {
        public string Room;
    }

    [System.Serializable]
    public class Connection : Point
    {
        public string Room1;
        public string Room2;
    }

    [System.Serializable]
    public class PointList
    {
        public List<StartingPosition> startingpositions;
        public List<Target> targets;
        public List<Connection> connections;


        public string toString(){
            string s = "Starting: ";
            foreach( StartingPosition sp in startingpositions)
            {
                s += (sp.Name + " ");
            }
            s += "Targets: ";
            foreach( Target t in targets)
            {
                s += (t.Name + " ");
            }
            s += "Connections: ";
            foreach( Connection c in connections)
            {
                s += (c.Name + " ");
            }
            return s;
        }
    }

}
