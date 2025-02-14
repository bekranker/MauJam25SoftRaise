using UnityEngine;

[CreateAssetMenu(fileName ="Item",menuName ="Item")]
public class ItemSO : ScriptableObject
{
    public Sprite assetSprite;
    public float Price;
    public ItemType itemType;
    public int PhaseNumber;
}
public enum ItemType
{
    Damage,
    Shield
}
