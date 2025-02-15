using UnityEngine;

public class Shield : MonoBehaviour,IItem,IGun
{
    [SerializeField] private ItemSO _itemSettings;
    [SerializeField] private DragAndDrop _itemDropData;

    public bool objestIsTaken { get; set; }

    public ItemSO itemSettings
    {
        get => _itemSettings;
        set
        {
            if (value == null)
            {
                return;
            }
            _itemSettings = value;
        }
    }

    public DragAndDrop itemDropData
    {
        get => _itemDropData;
        set
        {
            if (value == null)
            {
                return;
            }
            _itemDropData = value;
        }
    }

    public float price { get; set; }

    void Start()
    {
        objestIsTaken = false;
        SOSettings();
        DayPriceEventVoid();
    }

    void SOSettings()
    {
        if (itemSettings == null)
        {
            return;
        }

        if (itemDropData == null)
        {
            itemDropData = GetComponent<DragAndDrop>();

            if (itemDropData == null)
            {
                return;
            }
        }

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = itemSettings.assetSprite;
        }
        else
        {
            Debug.LogError($"{gameObject.name}: SpriteRenderer bileþeni eksik!");
        }
    }

    public void DayPriceEventVoid()
    {
        price = itemSettings.DayPrice;
    }

    public void NightPriceEventVoid()
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

    public void Upgrade()
    {
        Debug.Log("upgradeEffect");
        SlaveCode chosenSlave = itemDropData.ChosenSlave.GetComponent<SlaveCode>();

        if (chosenSlave.Gun != null && itemSettings.itemType == chosenSlave.Gun.itemType)
        {
            chosenSlave.LevelValue = chosenSlave.LevelValue + itemSettings.LevelNumber;

            if (chosenSlave.LevelValue == chosenSlave.Gun.LevelNumber)
            {
                if (chosenSlave.ListIndex < chosenSlave.ShieldItems.Count)
                    chosenSlave.ListIndex++;


                if (itemSettings.itemType == ItemType.Shield)
                {
                    chosenSlave.Gun = chosenSlave.ShieldItems[chosenSlave.ListIndex];
                }

                chosenSlave.LevelValue = 0;
            }
        }
        else if (chosenSlave.Gun == null && itemSettings.LevelNumber == 1)
        {
            if (itemSettings.itemType == ItemType.Shield)
            {
                chosenSlave.Gun = chosenSlave.ShieldItems[0];
            }

            CoinCode.instance.TakeObject(price);
        }
        else if (itemSettings.itemType == ItemType.Shield && itemSettings.LevelNumber > 1)
        {
            foreach (ItemSO i in chosenSlave.ShieldItems)
            {
                if (i.LevelNumber == itemSettings.LevelNumber)
                {
                    chosenSlave.Gun = i;
                }
            }
        }
    }

    public void Effect()
    {
        //efekt yaz
    }
}
