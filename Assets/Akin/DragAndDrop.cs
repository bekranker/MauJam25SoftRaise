using UnityEngine;
using System;
public class DragAndDrop : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;
    private Vector2 objectStartPosition;
    private Vector2 objectInventoryPosition;

    bool isObjectTaken;
    bool isRecyle;
    
    public GameObject ChosenSlave;
    SlaveCode SlaveCode;
    public TakenItemCode ObjectItemControlCode;

    Collider2D collidedTile = null;
    Collider2D CollidedHuman = null;
    private void Start()
    {
        objectStartPosition = transform.position;
        objectInventoryPosition = objectStartPosition;
        ObjectItemControlCode = GetComponent<TakenItemCode>();
    }
    void SOSettings()
    {
        objectStartPosition = transform.position;
        objectInventoryPosition = objectStartPosition;
        ObjectItemControlCode = GetComponent<TakenItemCode>();
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

        if (isObjectTaken && !ObjectItemControlCode.objestIsTaken && CoinCode.instance.Coin>= ObjectItemControlCode.itemSettings.DayPrice)
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
                ObjectItemControlCode.Upgrade();
                Destroy(gameObject);
            }
            else
            {
                ObjectItemControlCode.CharacterBuff(ChosenSlave);
            }
            ChosenSlave = null;
            SlaveCode = null;


        }

      
           
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Inventory" )
        {
            if (!collision.GetComponent<InventoryCode>().isFull)
            {
                objectInventoryPosition = collision.transform.position;
                objectStartPosition = collision.transform.position;
                collidedTile = collision;
                isObjectTaken = true;
            }
            
        }

        if(collision.gameObject.tag == "Recycle")
        {
            isRecyle = true;
        }

        if(collision.gameObject.tag == "Slave")
        {
            
            ChosenSlave = collision.gameObject;
            SlaveCode = ChosenSlave.GetComponent<SlaveCode>();
            
        }
        
    }

   
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Recycle")
        {
            collidedTile.GetComponent<InventoryCode>().isFull = false;
            isRecyle = false;
        }
            

        if(collision.gameObject.tag == "Slaves")
        {
            collidedTile.GetComponent<InventoryCode>().isFull = false;
            ChosenSlave = null;
        }
      
           

    }
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
