using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    //[SerializeField] Button btnEasy;
    [SerializeField] TextMeshProUGUI enemy;
    [SerializeField] TextMeshProUGUI player;

    //[SerializeField] static string key_level = "levelOfDifficult_save";
    //[SerializeField] static string levelOfDifficult;
    public static bool isEasy;
    public GameObject gameObject;

    public static int scoreEnemy;
    public static int scorePlayer;

    void Start()
    {
        PlayerPrefs.DeleteAll();
        ChangeText();
    }    

    public  void PlayGameSceneHard()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        isEasy = false;
        //levelOfDifficult = "Hard";
        //Save();
    }    

    public void PlayGameSceneEasy()
    {
        //SceneManager.LoadScene("SampleScene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        isEasy = true;
        //levelOfDifficult = "Easy";
        //Save();
    }

    public void Score(Vector3 ballPos, bool playerHitted, int countGround, bool inZone)
    {
        Debug.Log(countGround + " - " + inZone + " - " + playerHitted);
        if (countGround == 0 && inZone == false) //true
        {
            if (playerHitted)
                scoreEnemy++;
            else
                scorePlayer++;
        }
        if (countGround == 1 && inZone == false) //true
        {
            if (playerHitted)
                scorePlayer++;
            else
                scoreEnemy++;
        }
        if (countGround == 2)
        {
            if (playerHitted)
                scorePlayer++;
            else
                scoreEnemy++;
        }
        Debug.Log(scorePlayer + " - " + scoreEnemy);
        ChangeText();
    }


    //public void Save()
    //{
    //    PlayerPrefs.SetString(key_level, levelOfDifficult);
    //    PlayerPrefs.Save();
    //}

    //public void Load()
    //{
    //    string lv = PlayerPrefs.GetString(key_level);
    //    Debug.Log("Load key: " + lv);
    //}

    //public void QuitGame()
    //{
    //    Application.Quit();
    //}    

    public void ChangeText()
    {
        enemy.text = "Enemy: " + scoreEnemy;
        player.text = "Player: " + scorePlayer;
    }
}
