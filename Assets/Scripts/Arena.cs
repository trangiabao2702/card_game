using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class arena : MonoBehaviour
{
    [SerializeField] private ConfirmMoveToArena arenaConfirmModel;
    // Start is called before the first frame update

  
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0)) {
        //    OnMouseDown();
        //}
    }

    private void OpenConfirmModels(string message)
    {
        arenaConfirmModel.gameObject.SetActive(true);
        if (arenaConfirmModel.yesBtn == null || arenaConfirmModel.noBtn == null)
        {
            Debug.Log("null btn");
        }
        arenaConfirmModel.yesBtn.onClick.AddListener(() =>
        {
            YesClicked();
        });
        arenaConfirmModel.noBtn.onClick.AddListener(() =>
        {
            NoClicked();
        });
        //arenaConfirmModel.messageText.text = message;
    }

    private void YesClicked()
    {
        arenaConfirmModel.gameObject.SetActive(false);
        SceneManager.LoadScene("ArenaScene");
        Debug.Log("Move to arena");
    }

    private void NoClicked()
    {
        arenaConfirmModel.gameObject.SetActive(false);
        Debug.Log("Cancel move to arena");
    }

    private void OnMouseDown()
    {
        Debug.Log("clicked");
        OpenConfirmModels("");
    }
}
