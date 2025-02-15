using UnityEngine;
using System;
public class DragAndDrop : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;
    private Vector2 objectStartPosition;
    private Vector2 objectInventoryPosition;

    bool isObjectHandled;
    bool isRecyle;
    bool isPlayerAdd;
    
    public GameObject ChosenSlave;
    public GameObject HumanPanel;
    SlaveCode SlaveCode;
    public IItem ObjectItemControlCode;

    [SerializeField]GameObject collidedTile = null;
    private void Start()
    {
        objectStartPosition = transform.position;
        objectInventoryPosition = objectStartPosition;
        ObjectItemControlCode = GetComponent<IItem>();
    }
    void SOSettings()
    {
        objectStartPosition = transform.position;
        objectInventoryPosition = objectStartPosition;
        ObjectItemControlCode = GetComponent<IItem>();
    }
    void OnMouseDown()
    {
        offset = transform.position - GetMouseWorldPosition();
        isDragging = true;
        
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPosition() + offset;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
        gameObject.transform.position = objectInventoryPosition;

        if (isObjectHandled && !ObjectItemControlCode.objestIsTaken && CoinCode.instance.Coin>= ObjectItemControlCode.itemSettings.DayPrice)
        {
            collidedTile.GetComponent<InventoryCode>().isFull = true;
            ObjectItemControlCode.ItemTaken();
        }
          

        if (isRecyle)
        {
            ObjectItemControlCode.ItemSell();
            isRecyle = false;
        }

        if(ChosenSlave != null) 
        {
           
           if(ObjectItemControlCode is IGun)
            {
                ((IGun)ObjectItemControlCode).Upgrade();
                ((IGun)ObjectItemControlCode).Effect();
                Destroy(gameObject);
            }
            else if(ObjectItemControlCode is IPowerItem)
            {
                ((IPowerItem)ObjectItemControlCode).PowerEffect();
            }
            ChosenSlave = null;
            SlaveCode = null;


        }

        if (isPlayerAdd)
        {
            if(ObjectItemControlCode is IHuman)
            {
                ((IHuman)ObjectItemControlCode).HumanEffect(HumanPanel);
                Destroy(HumanPanel);
            }
        }




    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Inventory" )
        {
            if (!collision.GetComponent<InventoryCode>().isFull && !ObjectItemControlCode.objestIsTaken)
            {
                objectInventoryPosition = collision.transform.position;
                objectStartPosition = collision.transform.position;
                collidedTile = collision.gameObject;
                isObjectHandled = true;
            }
            
        }
        if(collision.gameObject.tag == "Slave")
        {
            
            ChosenSlave = collision.gameObject;
            SlaveCode = ChosenSlave.GetComponent<SlaveCode>();
            
        }

        if(collision.gameObject.tag == "Recycle")
        {
            isRecyle = true;
        }

        if(ObjectItemControlCode.itemSettings.itemType ==ItemType.Human && collision.gameObject.tag == "Holder")
        {
            isPlayerAdd = true;
            HumanPanel = collision.gameObject;
        }
        
        
    }

   
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Recycle")
        {
            collidedTile.GetComponent<InventoryCode>().isFull = false;
            isRecyle = false;
        }
            

        if(collision.gameObject.tag == "Slave")
        {
            ChosenSlave = null;
            SlaveCode = null;
        }

        if (ObjectItemControlCode.itemSettings.itemType == ItemType.Human && collision.gameObject.tag == "Holder")
        {
            isPlayerAdd = false;
            HumanPanel = null;

        }


        if (collision.gameObject.tag == "Inventory")
        {
           
        }
      
           

    }
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
