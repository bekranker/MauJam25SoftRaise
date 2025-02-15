using UnityEngine;

public class HealthPosion : MonoBehaviour,IItem,IPowerItem
{
    [SerializeField] private ItemSO _itemSettings;
    [SerializeField] private DragAndDrop _itemDropData;

    [SerializeField] float Health;
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

    public void PowerEffect(SlaveCode slaveCode)
    {
        slaveCode.Health = slaveCode.Health + Health;
    }
}
