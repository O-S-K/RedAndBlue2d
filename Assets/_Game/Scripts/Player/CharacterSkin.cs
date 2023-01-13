using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSkin : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation { get; protected set; }
    [SerializeField] string skinName;
    [SpineAnimation]public string tesst;
    [SpineSkin] public string skinTesst;
    public virtual void Initialize()
    {
        skeletonAnimation = GetComponentInChildren<SkeletonAnimation>();
        skeletonAnimation.Initialize(true);
    }
    public void SetSkin(string nameSkin)
    {
        skeletonAnimation.Skeleton.SetSkin(nameSkin);
        skeletonAnimation.Skeleton.SetSlotsToSetupPose();
        skeletonAnimation.AnimationState.Apply( skeletonAnimation.Skeleton);
    }
}
