using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SelectedClasses")]
public class ClassSelectSaver : ScriptableObject
{
    public ClassSelectorScript.Class player1Class;
    public ClassSelectorScript.Class player2Class;

    public int player1Score;
    public int player2Score;
}
