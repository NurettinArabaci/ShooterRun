using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    [SerializeField]GameObject[] levelPrefabs;

    public static LevelController Instance;

    public int levelNumber;

    private void Awake()
    {
        Instance = this;
        levelNumber = PlayerPrefs.GetInt("Level", 0);   
    }

    private void Start()
    {
       LevelCreate(); 
    }

    public void LevelCompleted()
    {
        levelNumber++;
        PlayerPrefs.SetInt("Level", levelNumber);

        Invoke(nameof(OpenLevelCompleteButton), 4f);
    }

    public void RestartLevelButton()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevelButton()
    {
        Destroy(GameObject.FindGameObjectWithTag("Level"));
        LevelCreate();
    }

    public void OpenLevelCompleteButton()
    {
        ButtonController.Instance.nextLevelBut.gameObject.SetActive(true);
    }

    public void LevelCreate()
    {
        Instantiate(levelPrefabs[levelNumber%(levelPrefabs.Length)]);
    }


}
