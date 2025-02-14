using UnityEngine;

public class TakenItemCode : MonoBehaviour
{
    public bool objestIsTaken;
    public ItemSO itemSettings;
    void Start()
    {
        
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
