using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpeedPreference", order = 1)]
public class SpeedPreference : ScriptableObject
{
    public enum SpeedChoices { Normal, Slow, VerySlow };

    public SpeedChoices speedPreference;
}
