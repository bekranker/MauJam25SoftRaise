using UnityEngine;
using System.Collections.Generic;
public class MarketScript : MonoBehaviour
{
    [SerializeField] List<GameObject> MarketPoints;
    [SerializeField] List<GameObject> ObjectSale;

    private List<GameObject> Level1Items;
    private List<GameObject> Level2Items;
    private List<GameObject> Level3Items;
    private List<GameObject> Level4Items;

    private int RandomLevel1;
    private int RandomLevel2;
    private int RandomLevel3;
    private int RandomLevel4;


    private int DayRandomLevel1;
    private int DayRandomLevel2;
    private int DayRandomLevel3;
    private int DayRandomLevel4;

    private int NightRandomLevel1;
    private int NightRandomLevel2;
    private int NightRandomLevel3;
    private int NightRandomLevel4;
    void Start()
    {
        ObjectRandomLister();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ObjectRandomLister()
    {
        foreach (GameObject Items in ObjectSale)
        {
            if(Items.GetComponent<ItemSO>().LevelNumber == 1)
            {
                Level1Items.Add(Items);
            }
            else if(Items.GetComponent<ItemSO>().LevelNumber == 2)
            {
                Level2Items.Add(Items);
            }
            else if (Items.GetComponent<ItemSO>().LevelNumber == 3)
            {
                Level3Items.Add(Items);
            }
            else if (Items.GetComponent<ItemSO>().LevelNumber == 4)
            {
                Level4Items.Add(Items);
            }
        }
        for (int i = 0; i< MarketPoints.Count; i++)
        {
            int LevelRandom = Random.Range(0, 101);

            if(LevelRandom <= RandomLevel4)
            {
                int RandomSelection = Random.Range(0, ObjectSale.Count);
                GameObject createdObject = Instantiate(Level4Items[RandomSelection]);
                createdObject.transform.position = MarketPoints[i].transform.position;
            }
            else if (LevelRandom>RandomLevel4 && LevelRandom <= RandomLevel3)
            {
                int RandomSelection = Random.Range(0, ObjectSale.Count);
                GameObject createdObject = Instantiate(Level3Items[RandomSelection]);
                createdObject.transform.position = MarketPoints[i].transform.position;
            }
            else if (LevelRandom > RandomLevel3 && LevelRandom <= RandomLevel2)
            {
                int RandomSelection = Random.Range(0, ObjectSale.Count);
                GameObject createdObject = Instantiate(Level2Items[RandomSelection]);
                createdObject.transform.position = MarketPoints[i].transform.position;
            }
            else
            {
                int RandomSelection = Random.Range(0, ObjectSale.Count);
                GameObject createdObject = Instantiate(Level1Items[RandomSelection]);
                createdObject.transform.position = MarketPoints[i].transform.position;
            }


        }
    }
}
