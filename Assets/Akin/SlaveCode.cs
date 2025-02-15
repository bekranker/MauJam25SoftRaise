using UnityEngine;
using System.Collections.Generic;

public class SlaveCode : MonoBehaviour
{
    public ItemSO Gun;
    public int LevelValue;
    public List<ItemSO> SwordItems;
    public List<ItemSO> ArcherItems;
    public List<ItemSO> ShieldItems;

    public int ListIndex = 0;

    public float DMG;
    public float Shield;
    public float Health;
    void Update()
    {
        if(Gun != null)
        {
            DMG = Gun.DMG;
            Shield = Gun.Shield;
        }
       
    }
}
