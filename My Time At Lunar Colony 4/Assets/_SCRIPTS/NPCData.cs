using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NPCData", menuName = "NPCData")]
public class NPCData : ScriptableObject
{
    public string name;
    public Sprite portraitSprite;

    public string species;
    public string occupation;
    public string cargoWeight;
    public string vehicleID;

    public bool isGuilty;
}
