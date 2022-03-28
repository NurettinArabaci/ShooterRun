using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [HideInInspector]
    public Button playBut, restartBut, nextLevelBut;

    public GameObject player,enemiesParent;
    [SerializeField] Text levelText;
    public static ButtonController Instance;

    ColliderController colliderController;

    private void Awake()
    {
        Instance = this;

        colliderController = player.GetComponent<ColliderController>();
        ButtonReference();
    }
    private void Start()
    {
        levelText.GetComponent<Text>().text = "Level " + (PlayerPrefs.GetInt("Level")+1).ToString();
    }

    public void PlayButton()
    {
        playBut.gameObject.SetActive(false);
        colliderController.EnabledOpenClose(player, enemiesParent, true);
    }

    public void RestartButton()
    {
        //Leveli yeniden yükle
        restartBut.gameObject.SetActive(false);
        LevelController.Instance.RestartLevelButton();

    }

    public void NextLevelButton()
    {
        LevelController.Instance.NextLevelButton();
        nextLevelBut.gameObject.SetActive(false);

    }

    public void ButtonReference()
    {
        playBut = transform.GetChild(0).GetComponent<Button>();
        nextLevelBut = transform.GetChild(1).GetComponent<Button>();
        restartBut = transform.GetChild(2).GetComponent<Button>();
    }
}
