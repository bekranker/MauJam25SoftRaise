using UnityEngine;
using System.Collections.Generic;

public class TakenItemCode : MonoBehaviour,IGun
{
    public bool objestIsTaken;
    public ItemSO itemSettings;
    public DragAndDrop itemDropData;
    public float price;

    void Start()
    {
        objestIsTaken = false;
        SOSettings();
        DayPriceEventVoid();
    }
    void SOSettings()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = itemSettings.assetSprite;
        itemDropData = GetComponent<DragAndDrop>();
    }

    void DayPriceEventVoid()
    {
        price = itemSettings.DayPrice;
    }
    void NightPriceEventVoid()
    {
        price = itemSettings.NightPrice;

    }

    public void ItemTaken()
    {
        CoinCode.instance.TakeObject(price);
        objestIsTaken = true;
    }
    public void ItemSell()
    {
        CoinCode.instance.SellObject(price);
        Destroy(gameObject);
    }
    public void CharacterBuff(GameObject Slave)
    {
        //Slave buff interface;
    }

    public void Upgrade()
    {
        Debug.Log("upgradeEffect");
        if(itemDropData.ChosenSlave.GetComponent<SlaveCode>().Gun != null && itemSettings.itemType == itemDropData.ChosenSlave.GetComponent<SlaveCode>().Gun.itemType)
        {
            itemDropData.ChosenSlave.GetComponent<SlaveCode>().LevelValue = itemDropData.ChosenSlave.GetComponent<SlaveCode>().LevelValue + 1;
            if(itemDropData.ChosenSlave.GetComponent<SlaveCode>().LevelValue == itemDropData.ChosenSlave.GetComponent<SlaveCode>().Gun.LevelNumber)
            {
                if(itemSettings.itemType == ItemType.Sword)
                {
                    itemDropData.ChosenSlave.GetComponent<SlaveCode>().ListIndex = itemDropData.ChosenSlave.GetComponent<SlaveCode>().ListIndex + 1;
                    itemDropData.ChosenSlave.GetComponent<SlaveCode>().Gun = itemDropData.ChosenSlave.GetComponent<SlaveCode>().SwordItems[itemDropData.ChosenSlave.GetComponent<SlaveCode>().ListIndex];

                }
                else if (itemSettings.itemType == ItemType.Archer)
                {
                    itemDropData.ChosenSlave.GetComponent<SlaveCode>().ListIndex = itemDropData.ChosenSlave.GetComponent<SlaveCode>().ListIndex + 1;
                    itemDropData.ChosenSlave.GetComponent<SlaveCode>().Gun = itemDropData.ChosenSlave.GetComponent<SlaveCode>().ArcherItems[itemDropData.ChosenSlave.GetComponent<SlaveCode>().ListIndex];

                }
                else if (itemSettings.itemType == ItemType.Shield)
                {
                    itemDropData.ChosenSlave.GetComponent<SlaveCode>().ListIndex = itemDropData.ChosenSlave.GetComponent<SlaveCode>().ListIndex + 1;
                    itemDropData.ChosenSlave.GetComponent<SlaveCode>().Gun = itemDropData.ChosenSlave.GetComponent<SlaveCode>().ShieldItems[itemDropData.ChosenSlave.GetComponent<SlaveCode>().ListIndex];

                }
                itemDropData.ChosenSlave.GetComponent<SlaveCode>().LevelValue = 0;
            }

            

        }
        else if(itemDropData.ChosenSlave.GetComponent<SlaveCode>().Gun == null)
        {
            if (itemSettings.itemType == ItemType.Sword)
            {
                //itemDropData.ChosenSlave.GetComponent<SlaveCode>().ListIndex = itemDropData.ChosenSlave.GetComponent<SlaveCode>().ListIndex + 1;
                itemDropData.ChosenSlave.GetComponent<SlaveCode>().Gun = itemDropData.ChosenSlave.GetComponent<SlaveCode>().SwordItems[0];

            }
            else if (itemSettings.itemType == ItemType.Archer)
            {
                //itemDropData.ChosenSlave.GetComponent<SlaveCode>().ListIndex = itemDropData.ChosenSlave.GetComponent<SlaveCode>().ListIndex + 1;
                itemDropData.ChosenSlave.GetComponent<SlaveCode>().Gun = itemDropData.ChosenSlave.GetComponent<SlaveCode>().ArcherItems[0];

            }
            else if (itemSettings.itemType == ItemType.Shield)
            {
               // itemDropData.ChosenSlave.GetComponent<SlaveCode>().ListIndex = itemDropData.ChosenSlave.GetComponent<SlaveCode>().ListIndex + 1;
                itemDropData.ChosenSlave.GetComponent<SlaveCode>().Gun = itemDropData.ChosenSlave.GetComponent<SlaveCode>().ShieldItems[0];

            }
            CoinCode.instance.TakeObject(price);
            

        }
    }
}
