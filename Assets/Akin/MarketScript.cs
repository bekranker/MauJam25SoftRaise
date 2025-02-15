using UnityEngine;
using System.Collections.Generic;
public class MarketScript : MonoBehaviour
{
    [SerializeField] List<GameObject> MarketPoints;
    [SerializeField] List<GameObject> ObjectSale;

    [SerializeField] List<GameObject> Level1Object;
    [SerializeField] List<GameObject> level2Object;
    [SerializeField] List<GameObject> level3Object;
    [SerializeField] List<GameObject> level4Object;


    private int Level1ItemRandomizer;
    private int Level2ItemRandomizer;
    private int Level3ItemRandomizer;
    private int Level4ItemRandomizer;


    [SerializeField] int DayLevel1Item;
    [SerializeField] int DayLevel2Item;
    [SerializeField] int DayLevel3Item;
    [SerializeField] int DayLevel4Item;

    [SerializeField] int NightLevel1Item;
    [SerializeField] int NightLevel2Item;
    [SerializeField] int NightLevel3Item;
    [SerializeField] int NightLevel4Item;
    void Start()
    {
        DaySettings();
        ObjectRandomLister();
    }

    void DaySettings()
    {
        Level1ItemRandomizer = DayLevel1Item;
        Level2ItemRandomizer = DayLevel2Item;
        Level3ItemRandomizer = DayLevel3Item;
        Level4ItemRandomizer = DayLevel4Item;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void ObjectRandomLister()
    {
        foreach (GameObject b in ObjectSale)
        {
            if (b.GetComponent<IItem>().itemSettings.LevelNumber == 1)
            {
                Level1Object.Add(b);
            }
            else if (b.GetComponent<IItem>().itemSettings.LevelNumber == 2)
            {
                level2Object.Add(b);
            }
            else if (b.GetComponent<IItem>().itemSettings.LevelNumber == 3)
            {
                level3Object.Add(b);
            }
            else if (b.GetComponent<IItem>().itemSettings.LevelNumber == 4)
            {
                level4Object.Add(b);
            }
        }
        for (int i = 0; i < MarketPoints.Count; i++)
        {
            int RandomValue = Random.Range(0, Level1ItemRandomizer);
            if (RandomValue <= Level4ItemRandomizer)
            {
                int RandomObject = Random.Range(0, level4Object.Count);
                GameObject SpawnedObject = Instantiate(level4Object[RandomObject]);
                SpawnedObject.transform.position = MarketPoints[i].transform.position;

            }
            else if ( RandomValue > Level4ItemRandomizer && RandomValue<=Level3ItemRandomizer)
            {
                int RandomObject = Random.Range(0, level3Object.Count);
                GameObject SpawnedObject = Instantiate(level3Object[RandomObject]);
                SpawnedObject.transform.position = MarketPoints[i].transform.position;

            }
            else if (RandomValue > Level3ItemRandomizer && RandomValue <= Level2ItemRandomizer)
            {
                int RandomObject = Random.Range(0, level2Object.Count);
                GameObject SpawnedObject = Instantiate(level2Object[RandomObject]);
                SpawnedObject.transform.position = MarketPoints[i].transform.position;

            }
            else if (RandomValue > Level2ItemRandomizer && RandomValue <= Level1ItemRandomizer)
            {
                int RandomObject = Random.Range(0, Level1Object.Count);
                GameObject SpawnedObject = Instantiate(Level1Object[RandomObject]);
                SpawnedObject.transform.position = MarketPoints[i].transform.position;

            }
        }
    }
}