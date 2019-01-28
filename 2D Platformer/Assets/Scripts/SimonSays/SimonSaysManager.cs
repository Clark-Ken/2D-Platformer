using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonSaysManager : MonoBehaviour
{
    public GameObject buttonPrefab;                         //A reference to our GameButton prefab

    public List<SimonSaysButtonSetting> buttonSettings;     //A list of our button settings (each button has other colors)
    List<GameObject> gameButtons;                           //A list for our instantiated GameButtons
    List<int> bleeps;                                       //A list for generated bleeps
    List<int> playerBleeps;                                 //A list for the player's bleeps

    public Transform gameFieldPanelTransform;               //A reference to the GameFieldPanel, so we can add the GameButtons to it

    int bleepCount = 3;                                     //An integer to set the current bleep count

    bool inputEnabled = false;
    bool gameOver = false;

    Random rng;

    // Start is called before the first frame update
    void Start()
    {
        gameButtons = new List<GameObject>();

        CreateSimonSaysButton(0, new Vector3(-64, 64));
        CreateSimonSaysButton(1, new Vector3(64, 64));
        CreateSimonSaysButton(2, new Vector3(-64, -64));
        CreateSimonSaysButton(3, new Vector3(64, -64));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateSimonSaysButton(int index, Vector3 position)
    {
        GameObject gameButton = Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity);

        gameButton.transform.SetParent(gameFieldPanelTransform);
        gameButton.transform.localPosition = position;

        gameButton.GetComponent<Image>().color = buttonSettings[index].normalColor;
        //gameButton.GetComponent<Image>().color.
        gameButton.GetComponent<Button>().onClick.AddListener(() =>
        {

        });

        gameButtons.Add(gameButton);
    } 
}
