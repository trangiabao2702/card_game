using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    [SerializeField] Button startBtn;
    [SerializeField] Button quitBtn;
    // Start is called before the first frame update
    void Start()
    {
        startBtn.onClick.AddListener(() =>
        {
            toGame();
        });

        quitBtn.onClick.AddListener(() =>
        {
            quit();
        });
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown("escape"))
        //{
        //    Application.Quit();
        //}
    }
    public void toGame()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void quit()
    {
        Application.Quit();
    }
}
