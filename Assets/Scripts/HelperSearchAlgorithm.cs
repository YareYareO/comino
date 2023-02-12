using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HelperSearchAlgorithm
{
    [System.Serializable]
    private struct Domino
    {
        public string name;
        public int depth;
        public string[] values;
        public string lookingFor;

        public Domino(TargetHandler.Connection connection)
        {
            this.name = connection.Name;
            this.depth = -1;
            this.values = new string[2];
            this.values[0] = connection.Room1;
            this.values[1] = connection.Room2;
            this.lookingFor = "";
        } 
        public Domino(TargetHandler.Target target)
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




    public static List<TargetHandler.Connection> DominoAlgorithm(List<TargetHandler.Connection> connections, TargetHandler.Target target, TargetHandler.StartingPosition startposition)
    {
        List<Domino> notUsed = convertToDominos(connections);   //Convert Connections to Dominos

        List<Domino> used = new List<Domino>();                 //Create necessary lists
        List<Domino> queue = new List<Domino>();

        Domino start = new Domino(startposition);               //starting position needs to be a Domino too (check constructor of struct)
        queue.Add(start);                                       //our starting point / first in queue

        string targetString = target.Room;                      //in which room we want to be at the end of the path
        bool targetFound = false;

        if(start.lookingFor == targetString)                    // incase the user is in the same room as the target already (while loop will be skipped)
        {
            targetFound = true;
            used.Add(start);
        }

        while(!(queue.Count == 0) & targetFound == false)       //if queue is empty there are no more dominos to continue (no more compatible Dominos)
        {
            Debug.Log(targetFound); 
    
            Domino firstInQueue = queue[0];                     // reference to first element in queue because we dont want to reference the whole list over and over again
            List<Domino> notUsedTMP = copyDominoList(notUsed);  //Deep Copy of the List, which will be iterated over, because we want to change the list during iteration

            foreach(Domino dom in notUsed)                      //every nonused Domino
            {
                if(isMatching(firstInQueue.lookingFor, dom))               //every Domino which is compatible with the first in queue
                {
                    Domino foundDom = dom;                      //copy of Domino because we dont want to (cant) change the original array notUsed
                    notUsedTMP.Remove(dom);                     //remove the domino from the copy of notused

                    foundDom.lookingFor = findLookingFor(firstInQueue.lookingFor, foundDom);    //prepare founddom to be the next element in queue
                    foundDom.depth = firstInQueue.depth + 1;                                    //same

                    Debug.Log(foundDom.name); 
                    if(foundDom.lookingFor == targetString)
                    {
                        targetFound = true;                     //IF TARGET IS FOUND THE WHILE LOOP ENDS AND CODE WILL CONTINUE AT THE **************
                        used.Add(firstInQueue);
                        used.Add(foundDom);
                    }
                    else 
                    {
                        queue.Add(foundDom);                    //finally add to queue
                    }
                }  
            }
            if(targetFound == false)
            {
                notUsed = notUsedTMP;                               //Basically remove the earlier found dominos from notUsed. its always -> notUsedTMP.Count <= notUsed.Count                
                queue.Remove(firstInQueue);                         //We dealt with the first in queue so now we remove it
                used.Add(firstInQueue);                             //And add it to used, which will be later used to backtrack
            }
            
        }
        if(queue.Count == 0 & targetFound == false)
        {
            return null;
        }
                                                                // ***********************
        List<Domino> path = new List<Domino>();

        used.Reverse();                                         // for easier backtracking
        Domino tmp = used[0];
        path.Add(tmp);                                          // last domino before target gets appended to path 

        if(used.Count > 1)                                      // because it makes sence 
        {
            foreach(Domino d in used)                           // all the other dominos are appended to path by backtracking
            {
                if(isMatching(d.lookingFor, tmp) & (d.depth == (tmp.depth - 1)) & d.depth > 0)
                {
                    path.Add(d);
                    tmp = d;
                }
            }
        }

        List<TargetHandler.Connection> ret = makeConnectionsPath(path, connections, target, startposition); // converts dominos to points and adds the target to the list
        return ret;
    }


    //HELPER
    private static List<Domino> convertToDominos(List<TargetHandler.Connection> connections)
    {
        // Self explanatory
        List<Domino> list = new List<Domino>();
        foreach(TargetHandler.Connection c in connections)
        {
            Domino d = new Domino(c);
            list.Add(d);
        }
        return list;
    }

    private static bool isMatching(string queueDomLF, Domino notUsedDom)
    {
        // We want to know if the Dominos are somehow compatible
        if(Array.IndexOf(notUsedDom.values, queueDomLF) != -1)
        {
            return true;
        }
        else{
            return false;
        }
    }

    private static string findLookingFor(string queueLookingFor, Domino notUsedDom)
    {
        // We want the string that leads us to the next Domino in line
        string ret;
        if(queueLookingFor != notUsedDom.values[0])
            {ret = notUsedDom.values[0];}
        else 
            {ret = notUsedDom.values[1];}
        return ret;
    }
    
    private static List<Domino> copyDominoList(List<Domino> toCopy)
    {
        // This exists because of "collection was modified" error. We need a copy for the foreach loop to work

        List<Domino> ret = new List<Domino>();
        foreach(Domino d in toCopy)
        {
            ret.Add(d);
        }
        return ret;
    }

    private static List<TargetHandler.Connection> makeConnectionsPath(List<Domino> dominos, List<TargetHandler.Connection> connects, TargetHandler.Target target, TargetHandler.StartingPosition start)
    {
        // maybe just use points instead of connections ?
        List<TargetHandler.Connection> ret = new List<TargetHandler.Connection>();
        ret.Add(convertPointToConnec(target, start));
        foreach(Domino d in dominos)
        {
            foreach(TargetHandler.Connection c in connects)
            {
                if(d.name == c.Name)
                {
                    ret.Add(convertPointToConnec(c, start));
                }
            }
        }
        
        return ret;
    }

    private static TargetHandler.Connection convertPointToConnec(TargetHandler.Point t, TargetHandler.StartingPosition start)
    {
        // Convert the dominos to points. Later if you wanna you can send the room information (like 'u are now in room xyz')
        //you need to specify target or connction or change the targethandler class
        TargetHandler.Connection ret = new TargetHandler.Connection();
        ret.Name = t.Name;
        ret.PosX = t.PosX - start.PosX;
        ret.PosY = t.PosY - start.PosY;
        ret.PosZ = t.PosZ - start.PosZ;
        ret.RotY = t.RotY - start.RotY - 90;
        return ret;
    }
}