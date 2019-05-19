using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSaver : MonoBehaviour
{
    [SerializeField]
    List<int> scores = new List<int>(3);

    public int currentScore;

    public Text score1Text;
    public Text score2Text;
    public Text score3Text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        currentScore = PlayerPrefs.GetInt("HighScore");
        SaveScores();
    }

    public void SaveScores()
    {
        for (int i = 0; i < scores.Count; i++)
        {
            if (scores[i] < currentScore)
            {
                scores.Add(currentScore);
                scores.Sort();
            }
        }

        string jsonData = JsonUtility.ToJson(scores, true);
        File.WriteAllText(Application.persistentDataPath + "/2dPlatformerScores.json", jsonData);
    }

    public void LoadScores()
    {
        scores = JsonUtility.FromJson<List<int>>(File.ReadAllText(Application.persistentDataPath + "/2dPlatformerScores.json"));

        scores.Sort();

        score1Text.text = "1 ST: " + scores[0].ToString();
        score2Text.text = "2 ND: " + scores[1].ToString();
        score3Text.text = "3 RD: " + scores[2].ToString();
    }
}
