using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleCreature", menuName = "Obstacles/ObstacleCreature", order = 1)]

public class CreatureObjects : ScriptableObject
{
    public bool shark = false;
    public bool seal = false;
    public float creatureSpeed = 0;
    public string name = "";

    public CreatureHandler cH;
}