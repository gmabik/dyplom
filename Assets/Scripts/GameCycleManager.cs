using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static ClassSelectorScript;

public class GameCycleManager : MonoBehaviour
{
    #region singleton
    public static GameCycleManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null) Destroy(Instance);
        Instance = this;
    }
    #endregion

    [Header("Classes")]
    [SerializeField] private ClassSelectSaver selectedClasses;

    [SerializedDictionary("Class", "Prefab")]
    public SerializedDictionary<Class, GameObject> classPrefabs;

    [SerializedDictionary("Class", "Sprite")]
    public SerializedDictionary<Class, Sprite> classSkillSprites;

    [Header("Spawns")]
    [SerializeField] private Transform player1Spawn;
    [SerializeField] private Transform player2Spawn;

    [Header("Score Texts")]
    [SerializeField] private TMP_Text player1ScoreText;
    [SerializeField] private TMP_Text player2ScoreText;

    [Header("HP Sliders")]
    [SerializeField] private Slider player1HPSlider;
    [SerializeField] private Slider player2HPSlider;

    [Header("CD Indicators")]
    [SerializeField] private RectTransform player1CD;
    [SerializeField] private RectTransform player2CD;

    [Header("Result Texts")]
    [SerializeField] private TMP_Text player1ResultText;
    [SerializeField] private TMP_Text player2ResultText;
    private void Start()
    {
        player1ScoreText.text = selectedClasses.player1Score.ToString();
        player2ScoreText.text = selectedClasses.player2Score.ToString();

        var player1 = Instantiate(classPrefabs.GetValueOrDefault(selectedClasses.player1Class));
        var player2 = Instantiate(classPrefabs.GetValueOrDefault(selectedClasses.player2Class));

        player1.transform.position = player1Spawn.position;
        player2.transform.position = player2Spawn.position;

        player1.GetComponent<PlayerMovement>().playerNum = 1;
        player2.GetComponent<PlayerMovement>().playerNum = 2;

        Camera cam1 = player1.GetComponentInChildren<Camera>();
        cam1.rect = new(0f, 0f, 0.5f, 1f);
        EventManager.Instance.cameras.Add(cam1);

        Camera cam2 = player2.GetComponentInChildren<Camera>();
        cam2.rect = new(0.5f, 0f, 0.5f, 1f);
        EventManager.Instance.cameras.Add(cam2);

        player1.GetComponent<PlayerMovement>().hpSlider = player1HPSlider;
        player2.GetComponent<PlayerMovement>().hpSlider = player2HPSlider;

        player1CD.parent.GetComponent<Image>().sprite = classSkillSprites.GetValueOrDefault(selectedClasses.player1Class);
        player2CD.parent.GetComponent<Image>().sprite = classSkillSprites.GetValueOrDefault(selectedClasses.player2Class);

        player1.GetComponent<ClassScript>().CDIndicator = player1CD;
        player2.GetComponent<ClassScript>().CDIndicator = player2CD;

        player1ResultText.gameObject.SetActive(false);
        player2ResultText.gameObject.SetActive(false);
    }

    public IEnumerator PlayerDied(int playerNum)
    {
        if(playerNum == 2)
        {
            selectedClasses.player1Score++;
            player1ScoreText.text = selectedClasses.player1Score.ToString();
        }
        else
        {
            selectedClasses.player2Score++;
            player2ScoreText.text = selectedClasses.player2Score.ToString();
        }

        string sceneName;
        if (selectedClasses.player1Score + selectedClasses.player2Score < 3)
        {
            sceneName = "Castle";
        }
        else
        {
            sceneName = "MainMenu";
            player1ResultText.gameObject.SetActive(true);
            player2ResultText.gameObject.SetActive(true);

            if (selectedClasses.player1Score > selectedClasses.player2Score)
            {
                player1ResultText.text = "WON";
                player1ResultText.color = Color.yellow;

                player2ResultText.text = "LOST";
                player2ResultText.color = Color.red;
            }
            else
            {
                player2ResultText.text = "WON";
                player2ResultText.color = Color.yellow;

                player1ResultText.text = "LOST";
                player1ResultText.color = Color.red;
            }

            selectedClasses.player1Score = 0;
            selectedClasses.player2Score = 0;

        }
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(sceneName);
    }

    private void OnApplicationQuit()
    {
        selectedClasses.player1Score = 0;
        selectedClasses.player2Score = 0;
    }
}
