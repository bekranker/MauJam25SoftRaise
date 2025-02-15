using UnityEngine;

public class HumanStore : MonoBehaviour
{
    [SerializeField] GameObject HumanPanel;

    private void OnEnable()
    {
        PlayerItem.isResetHumanPanel += HumanPanelCreator;
    }
    
    private void OnDisable()
    {
        PlayerItem.isResetHumanPanel -= HumanPanelCreator;
    }
    void Start()
    {
        HumanPanelCreator();
    }

    void HumanPanelCreator()
    {
        GameObject humanpanelobject = Instantiate(HumanPanel);
        humanpanelobject.transform.position = gameObject.transform.position;
    }

}
