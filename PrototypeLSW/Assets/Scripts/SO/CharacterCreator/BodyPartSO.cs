using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Body Part", menuName = "ScriptableObjects/CharacterCreator/Body Part")]
public class BodyPartSO : ScriptableObject
{
    public string bodyPartName;
    public int bodyPartAnimationID;

    public List<AnimationClip> allBodyPartAnimations = new List<AnimationClip>();
}
