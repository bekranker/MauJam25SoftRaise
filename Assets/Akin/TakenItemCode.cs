using UnityEngine;

public class TakenItemCode : MonoBehaviour
{
    public bool objestIsTaken;
    public ItemSO itemSettings;
    public DragAndDrop itemDropData;

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = itemSettings.assetSprite;
    }

    public void ItemTaken()
    {
        CoinCode.instance.TakeObject(itemSettings.Price);
        objestIsTaken = true;
    }
    public void ItemSell()
    {
        CoinCode.instance.SellObject(itemSettings.Price);
        Destroy(gameObject);
    }
    public void CharacterBuff(GameObject Slave)
    {
        //Slave buff interface;
    }

    



}
