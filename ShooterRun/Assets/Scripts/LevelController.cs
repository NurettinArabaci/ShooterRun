using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;

    public int levelNumber;

    private void Awake()
    {
        Instance = this;

        levelNumber = PlayerPrefs.GetInt("Level", 0);
    }

    public void LevelCompleted()
    {
        levelNumber++;
        PlayerPrefs.SetInt("Level", levelNumber);
    }

    public void LevelFailed()
    {
        PlayerPrefs.GetInt("Level");
    }

}
