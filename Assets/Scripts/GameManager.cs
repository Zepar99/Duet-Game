using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonGeneric<GameManager>
{
    [HideInInspector] public bool isGameOver = false;
}
