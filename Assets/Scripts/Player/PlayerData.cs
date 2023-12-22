using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    public AnimatorOverrideController animatorOverride;
    public Material material;
    public Material materialFlip;
}
