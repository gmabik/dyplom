using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Firewall : MonoBehaviour
{
    [Header("Ruch firewalla")]
    [Tooltip("Obiekt, do którego firewall ma siê poruszaæ")]
    public Transform target;

    [Tooltip("Prêdkoœæ poruszania siê firewalla")]
    public float speed = 2f;

    [Header("Timer")]
    [Tooltip("Czas odliczania (sekundy)")]
    public float countdownTime = 120f;

    [Tooltip("UI TextMeshPro wyœwietlaj¹cy timer")]
    public TextMeshProUGUI timerText;

    private float currentTime;
    private bool isCounting = true;
    private bool isMoving = false;

    void Start()
    {
        currentTime = countdownTime;
    }

    void Update()
    {
        // Odliczanie czasu
        if (isCounting)
        {
            currentTime -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(currentTime / 60f);
            int seconds = Mathf.FloorToInt(currentTime % 60f);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            if (currentTime <= 0)
            {
                isCounting = false;
                timerText.gameObject.SetActive(false); // Ukryj timer
                isMoving = true; // Rozpocznij ruch
            }
        }

        // Ruch firewalla po X
        if (isMoving && target != null)
        {
            Vector3 direction = new Vector3(target.position.x - transform.position.x, 0f, 0f).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
