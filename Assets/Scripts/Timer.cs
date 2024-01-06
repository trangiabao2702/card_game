using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private Image uiFill;
    [SerializeField] private TextMeshProUGUI uiText;
    [SerializeField] float remainingDuration;

    public float Duration;

    void Update()
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

    private void OnEnd()
    {
        print("End");
    }
}
