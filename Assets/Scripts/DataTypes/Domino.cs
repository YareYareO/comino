using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Domino
{
    [System.Serializable]
    public struct Stone
    {
        public string name;
        public int depth;
        public string[] values;
        public string lookingFor;

        public Stone(Connection connection)
        {
            this.name = connection.Name;
            this.depth = -1;
            this.values = new string[2];
            this.values[0] = connection.Room1;
            this.values[1] = connection.Room2;
            this.lookingFor = "";
        } 
        public Stone(Target target)
        {
            this.name = target.Name;
            this.depth = 0;
            this.values = new string[2];
            this.values[0] = target.Room;
            this.values[1] = target.Room;
            this.lookingFor = target.Room;
        } 
        
        public string toString() {return (this.name + ", " + this.depth + ", (" + values[0] + "," + values[1] + "), " + lookingFor);}
    }
}
