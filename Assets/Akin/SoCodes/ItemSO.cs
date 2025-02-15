using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName ="Item",menuName ="Item")]
public class ItemSO : ScriptableObject
{
    public Sprite assetSprite;
    public float DayPrice;
    public float NightPrice;
    public ItemType itemType;
    public int LevelNumber = 1;
}
public enum ItemType
{
    Archer,
    Sword,
    Shield
}
