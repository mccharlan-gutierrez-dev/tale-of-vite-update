using TMPro;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;
    public TextMeshProUGUI meatText;
    public TextMeshProUGUI coinText;
    public int meatCollected = 0;
    public int coinCollected = 0;
   
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    
    void Update()
    {
        meatText.text = meatCollected.ToString();
        coinText.text = coinCollected.ToString();
    }
}
