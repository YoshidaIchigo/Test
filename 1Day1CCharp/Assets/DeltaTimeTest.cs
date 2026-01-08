using UnityEngine;
using TMPro;

public class DeltaTimeTest : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI normalizedTimerText;
    private float timeElapsed = 0f;
    private bool timerRunning = true; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerRunning)
        {
            timeElapsed += Time.deltaTime;

            timerText.text = timeElapsed.ToString("F8");

            if (timeElapsed >= 6f)
            {
                var normalizedTime = Mathf.Clamp01(timeElapsed / 6f);
                normalizedTimerText.text = normalizedTime.ToString("F8");
                timerRunning = false;
            }
        }
    }
}
