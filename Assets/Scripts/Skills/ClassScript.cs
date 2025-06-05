using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClassScript : MonoBehaviour
{
    private int playerNum;
    [SerializeField] private AudioClip skillAudio;
    private void Start()
    {
        playerNum = gameObject.GetComponent<PlayerMovement>().playerNum;
        currentCD = 0f;
    }

    [SerializeField] protected float skillCD;
    protected float currentCD;

    public RectTransform CDIndicator;

    private void Update()
    {
        currentCD -= Time.deltaTime;
        if(currentCD < 0f) currentCD = 0f;
        CDIndicator.sizeDelta = new(CDIndicator.sizeDelta.x, 325 * (currentCD / skillCD));
        if (Input.GetButtonDown("Skill" + playerNum) && currentCD <= 0f)
        {
            currentCD = skillCD;
            Skill();
            GetComponent<AudioSource>().PlayOneShot(skillAudio);
        }
    }

    protected abstract void Skill();

    public abstract void GetBuff();
}
