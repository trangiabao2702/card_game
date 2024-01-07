using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float Duration;

    [SerializeField] private Image uiFill;
    [SerializeField] private TextMeshProUGUI uiText;
    [SerializeField] public float remainingDuration;
    private bool isRunning = false;

    public void StartTimer(float duration)
    {
        print("Start Timer");
        isRunning = true;

        Duration = duration;
        remainingDuration = duration;
        uiFill.fillAmount = 1f;
        uiText.text = string.Format("{0:00}", Mathf.CeilToInt(duration));
    }
    private void Update()
    {
        if (isRunning)
        {
            if (remainingDuration > 1)
            {
                remainingDuration -= Time.deltaTime;
                int seconds = Mathf.FloorToInt(remainingDuration % 60);

                uiFill.fillAmount = Mathf.InverseLerp(0, Duration, seconds);
                uiText.text = string.Format("{0:00}", seconds);
            }
            else
            {
                remainingDuration = 0;
                OnEnd();
            }
        }
    }

    private void OnEnd()
    {
        print("End Timer");
        isRunning = false;
    }
}
