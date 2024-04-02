using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="SceneInfo", menuName ="Persistence")]
public class SceneInfo : ScriptableObject
{
    public int overallCoins = 0;
    public float overallTime = 0;
}
