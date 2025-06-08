using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClassSelectorScript : MonoBehaviour
{
    public enum Class
    {
        Warrior,
        Archer,
        Mage,
        Thief
    }

    [SerializedDictionary("Class", "Sprite")]
    public SerializedDictionary<Class, Sprite> classSprites;

    [SerializedDictionary("Class", "Description")]
    public SerializedDictionary<Class, string> classDesc;

    [SerializedDictionary("Class", "Image")]
    public SerializedDictionary<Class, Sprite> classSkillImages;

    [SerializedDictionary("Class", "Buff Description")]
    public SerializedDictionary<Class, string> classBuffDesc;

    [SerializeField] private Image player1ClassImage;
    [SerializeField] private Image player2ClassImage;

    [SerializeField] private TMP_Text player1ClassDescText;
    [SerializeField] private TMP_Text player2ClassDescText;

    [SerializeField] private Image player1ClassDescImage;
    [SerializeField] private Image player2ClassDescImage;

    [SerializeField] private TMP_Text player1ClassBuffDescText;
    [SerializeField] private TMP_Text player2ClassBuffDescText;

    private int player1Class = 0;
    private int player2Class = 0;

    private void Start()
    {
        player1ClassImage.sprite = classSprites.GetValueOrDefault((Class)player1Class);
        player1ClassDescText.text = classDesc.GetValueOrDefault((Class)player1Class);
        player1ClassDescImage.sprite = classSkillImages.GetValueOrDefault((Class)player1Class);
        player1ClassBuffDescText.text = classBuffDesc.GetValueOrDefault((Class)player1Class);

        player2ClassImage.sprite = classSprites.GetValueOrDefault((Class)player2Class);
        player2ClassDescText.text = classDesc.GetValueOrDefault((Class)player2Class);
        player2ClassDescImage.sprite = classSkillImages.GetValueOrDefault((Class)player2Class);
        player2ClassBuffDescText.text = classBuffDesc.GetValueOrDefault((Class)player2Class);
    }

    public void ChangeClassPlayer1(int dir)
    {
        player1Class += dir;

        if (player1Class < 0) player1Class = classSprites.Count - 1;
        else if (player1Class >= classSprites.Count) player1Class = 0;

        player1ClassImage.sprite = classSprites.GetValueOrDefault((Class)player1Class);
        player1ClassDescText.text = classDesc.GetValueOrDefault((Class)player1Class);
        player1ClassDescImage.sprite = classSkillImages.GetValueOrDefault((Class)player1Class);
        player1ClassBuffDescText.text = classBuffDesc.GetValueOrDefault((Class)player1Class);
    }

    public void ChangeClassPlayer2(int dir)
    {
        player2Class += dir;

        if (player2Class < 0) player2Class = classSprites.Count - 1;
        else if (player2Class >= classSprites.Count) player2Class = 0;

        player2ClassImage.sprite = classSprites.GetValueOrDefault((Class)player2Class);
        player2ClassDescText.text = classDesc.GetValueOrDefault((Class)player2Class);
        player2ClassDescImage.sprite = classSkillImages.GetValueOrDefault((Class)player2Class);
        player2ClassBuffDescText.text = classBuffDesc.GetValueOrDefault((Class)player2Class);
    }

    public ClassSelectSaver selectedClasses;
    public void OnPlay()
    {
        selectedClasses.player1Class = (Class)player1Class;
        selectedClasses.player2Class = (Class)player2Class;
    }
}
