using UnityEngine;
using System.Collections.Generic;
public class MarketScript : MonoBehaviour
{
    [SerializeField] List<GameObject> MarketPoints;
    [SerializeField] List<GameObject> ObjectSale;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ObjectRandomLister()
    {
        for(int i = 0; i< MarketPoints.Count; i++)
        {
            int RandomSelection = Random.Range(0, ObjectSale.Count);
            Instantiate(ObjectSale[RandomSelection], MarketPoints[i].transform);
        }
    }
}
