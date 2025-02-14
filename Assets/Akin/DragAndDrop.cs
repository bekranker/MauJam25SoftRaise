using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;
    private Vector2 objectStartPosition;
    private Vector2 objectInventoryPosition;

    bool isObjectTaken;

    bool isInventorydedect;
    private void Start()
    {
        objectStartPosition = transform.position;
        objectInventoryPosition = objectStartPosition;
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

        if(isObjectTaken)
            CoinCode.instance.TakeObject(5);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Inventory" )
        {
            if (!collision.GetComponent<InventoryCode>().isFull)
            {
                objectInventoryPosition = collision.transform.position;
                collision.GetComponent<InventoryCode>().isFull = true;
                isObjectTaken = true;
            }
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Inventory")
        {
            objectInventoryPosition = objectStartPosition;
            collision.GetComponent<InventoryCode>().isFull = false;
        }
    }





    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
