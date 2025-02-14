using UnityEngine;

public class TakenItemCode : MonoBehaviour
{
    public bool objestIsTaken;
    void Start()
    {
        
    }

    public void ItemTaken()
    {
        CoinCode.instance.TakeObject(5);
        objestIsTaken = true;
    }
    public void ItemSell()
    {
        CoinCode.instance.SellObject(5);
        Destroy(gameObject);
    }
}
