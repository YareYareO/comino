using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SearchAlgorithm
{
    List<TargetHandler.Connection> all_connections;
    TargetHandler.Target chosen_target;
    TargetHandler.StartingPosition chosen_start;

    List<Domino.Stone> used_stones;
    List<Domino.Stone> queued_stones;
    Domino.Stone start_stone; 
    string target_room_name;
    bool is_target_found;
    List<TargetHandler.Point> quickest_path;

    public SearchAlgorithm()
    {
        all_connections = SearchData.PointList.connections;
        chosen_target = SearchData.Target;
        chosen_start = SearchData.Startposition;

        used_stones = new List<Domino.Stone>();     //Create necessary lists
        queued_stones = new List<Domino.Stone>();
        start_stone = new Domino.Stone(chosen_start);
        target_room_name = chosen_target.Room;      //in which room we want to be at the end of the path
        is_target_found = false;
        quickest_path = new List<TargetHandler.Point>();
    }

    public List<TargetHandler.Point> DominoAlgorithm()
    {
        queued_stones.Add(start_stone);     //our starting point / first in queue

        ifTargetIsInStartingRoom();     // will alter used_stones and set is_target_found if requirements are met

        LookForTarget();    // will alter used_stones
        
        if(isTargetNotFindable())
        {
            return null;
        }

        List<Domino.Stone> path_as_dominos = buildPathAsDominos();
        makePathAsPoints(path_as_dominos);    // this adds the points to quickest_path variable

        return quickest_path;
    }

    // \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    private void ifTargetIsInStartingRoom() 
    {
        // incase the user is in the same room as the target already
        if(start_stone.lookingFor == target_room_name)                    
        {
            setTargetFoundToTrue();
            addStoneToUsedStones(start_stone);
        }
    }

    private void addStoneToUsedStones(Domino.Stone stone)
    {
        used_stones.Add(stone);
    }

    private void setTargetFoundToTrue()
    {
        is_target_found = true;
    }

    // \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    private void LookForTarget()
    {
        List<Domino.Stone> unused_stones = convertToDominos(all_connections);   //Convert Connections to Dominos
        while(isLookingForTarget())       //if queue is empty there are no more dominos to continue (no more compatible Dominos)
        {
            Domino.Stone firstInQueue = queued_stones[0];                     // reference to first element in queue because we dont want to reference the whole list over and over again
            List<Domino.Stone> reduced_unused_stones = copyDominoList(unused_stones);  //Deep Copy of the List, which will be iterated over, because we want to change the list during iteration

            foreach(Domino.Stone stone in unused_stones)                      //every nonused Domino
            {
                if(isMatching(firstInQueue.lookingFor, stone))               //every Domino which is compatible with the first in queue
                {
                    Domino.Stone found_stone = prepareStone(stone, firstInQueue);   //copy of Domino because we dont want to (cant) change the original array notUsed
                    reduced_unused_stones.Remove(stone);                        //remove the domino from the copy of notused

                    if(found_stone.lookingFor == target_room_name)
                    {
                        setTargetFoundToTrue();                     //IF TARGET IS FOUND THE WHILE LOOP ENDS AND CODE WILL CONTINUE AT THE **************
                        addStoneToUsedStones(firstInQueue);
                        addStoneToUsedStones(found_stone);
                    }
                    else 
                    {
                        queued_stones.Add(found_stone);                    //finally add to queue
                    }
                }  
            }
            if(is_target_found == false)
            {
                unused_stones = reduced_unused_stones;                      //Basically remove the earlier found dominos from notUsed. its always -> notUsedTMP.Count <= notUsed.Count                
                queued_stones.Remove(firstInQueue);                         //We dealt with the first in queue so now we remove it
                addStoneToUsedStones(firstInQueue);                             //And add it to used, which will be later used to backtrack
            }
        }
        return;
    }

    private List<Domino.Stone> convertToDominos(List<TargetHandler.Connection> connections)
    {
        // Self explanatory
        List<Domino.Stone> dominos = new List<Domino.Stone>();
        foreach(TargetHandler.Connection connection in connections)
        {
            Domino.Stone stone = new Domino.Stone(connection);
            dominos.Add(stone);
        }
        return dominos;
    }

    private bool isLookingForTarget()
    {
        return (!(queued_stones.Count == 0) & is_target_found == false);
    }

    private List<Domino.Stone> copyDominoList(List<Domino.Stone> toCopy)
    {
        // This exists because of "collection was modified" error. We need a copy for the foreach loop to work
        List<Domino.Stone> ret = new List<Domino.Stone>();
        foreach(Domino.Stone d in toCopy)
        {
            ret.Add(d);
        }
        return ret;
    }

    private bool isMatching(string queueDomLF, Domino.Stone notUsedDom)
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

    private Domino.Stone prepareStone(Domino.Stone toPrepare, Domino.Stone usedToPrepare)
    {
        Domino.Stone preparedStone = toPrepare;
        preparedStone.lookingFor = findLookingFor(usedToPrepare.lookingFor, toPrepare);    //prepare founddom to be the next element in queue
        preparedStone.depth = usedToPrepare.depth + 1;                                    //same

        return preparedStone;
    }

    private string findLookingFor(string queueLookingFor, Domino.Stone notUsedDom)
    {
        // We want the string that leads us to the next Domino in line
        string ret;
        if(queueLookingFor != notUsedDom.values[0])
            {ret = notUsedDom.values[0];}
        else 
            {ret = notUsedDom.values[1];}
        return ret;
    }

    // \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    private bool isTargetNotFindable()
    {
        return (queued_stones.Count == 0 & is_target_found == false);
    }

    private List<Domino.Stone> buildPathAsDominos()
    {
        used_stones.Reverse();      // for easier backtracking
        Domino.Stone current_stone = used_stones[0];
        List<Domino.Stone> path = new List<Domino.Stone>();
        path.Add(current_stone);     // last domino before target gets appended to path 

        if(used_stones.Count > 1)       // because it makes sence 
        {
            foreach(Domino.Stone stone in used_stones)      // all the other dominos are appended to path by backtracking
            {
                if(isMatching(stone.lookingFor, current_stone) & (stone.depth == (current_stone.depth - 1)) & stone.depth > 0)
                {
                    path.Add(stone);
                    current_stone = stone;
                }
            }
        }
        return path;
    }

    // \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    private void makePathAsPoints(List<Domino.Stone> dominos)
    {
        // This alters the quickest_path variable. From empty list to filled
        addTarget();
        addPoints(dominos);
    }

    private void addTarget()
    {
        quickest_path.Add(calculatePointAttributes(chosen_target));
    }

    private void addPoints(List<Domino.Stone> dominos)
    {
        foreach(Domino.Stone stone in dominos)
        {
            foreach(TargetHandler.Point connection in all_connections)
            {
                if(stone.name == connection.Name)
                {
                    quickest_path.Add(calculatePointAttributes(connection));
                }
            }
        }
    }

    private TargetHandler.Point calculatePointAttributes(TargetHandler.Point t)
    {
        TargetHandler.Point ret = new TargetHandler.Point();
        ret.Name = t.Name;
        ret.PosX = t.PosX - chosen_start.PosX;
        ret.PosY = t.PosY - chosen_start.PosY;
        ret.PosZ = t.PosZ - chosen_start.PosZ;
        ret.RotY = t.RotY - chosen_start.RotY - 90;
        return ret;
    }
}