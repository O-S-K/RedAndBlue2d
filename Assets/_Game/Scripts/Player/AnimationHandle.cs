using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class AnimationHandle : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation { get; protected set; }
    private Dictionary<int, string> layerAnimator;
    public virtual void Initialize()
    {
        layerAnimator = new Dictionary<int, string>();
        skeletonAnimation = GetComponentInChildren<SkeletonAnimation>();
        skeletonAnimation.Initialize(true);
    }
    public virtual void ResetAnimator()
    {
        layerAnimator.Clear();
        skeletonAnimation.ClearState();
    }
    public void AddAnimation(Spine.Animation animation, int layer, bool isLoop, float delay)
    {
        skeletonAnimation.AnimationState.AddAnimation(layer, animation, isLoop, delay);
    }
    public void AddAnimation(string stateName, int layer, bool isLoop, float delay)
    {
        skeletonAnimation.AnimationState.AddAnimation(layer, stateName, isLoop, delay);
    }
    public void AddEmptyAnimation(int layer, float mixDuration, float delay)
    {
        skeletonAnimation.AnimationState.AddEmptyAnimation(layer, mixDuration, delay);
    }
    public void PlayAnimation(Spine.Animation animation, float mixDuration, int layer, bool isLoop, bool isLast = false)
    {
        if (animation == null)
        {
            if (layerAnimator.ContainsKey(layer))
            {
                layerAnimator[layer] = "";
            }
            skeletonAnimation.AnimationState.SetEmptyAnimation(layer, 0);
            return;
        }
        if (layerAnimator.ContainsKey(layer))
        {
            if (layerAnimator[layer].Equals(animation.Name))
            {
                if (isLoop)
                {
                    return;
                }
            }
            else
            {
                layerAnimator[layer] = animation.Name;
            }
        }
        else
        {
            if (isLoop)
            {
                layerAnimator.Add(layer, animation.Name);
            }
        }
        var a = skeletonAnimation.AnimationState.SetAnimation(layer, animation, isLoop);
        a.MixDuration = mixDuration;
        if (!isLoop && !isLast)
        {
            skeletonAnimation.AnimationState.AddEmptyAnimation(layer, 0, animation.Duration);
        }
        return;
    }
    public void PlayAnimation(string stateName, float mixDuration, int layer, bool isLoop, bool isLast = false)
    {
        if (stateName.Length == 0)
        {
            if (layerAnimator.ContainsKey(layer))
            {
                if (isLoop)
                {
                    layerAnimator[layer] = stateName;
                }
            }
            else
            {
                if (isLoop)
                {
                    layerAnimator.Add(layer, stateName);
                }
            }
            skeletonAnimation.AnimationState.SetEmptyAnimation(layer, 0);
            return;
        }
        if (layerAnimator.ContainsKey(layer))
        {
            if (layerAnimator[layer].Equals(stateName))
            {
                if (isLoop)
                {
                    return;
                }
            }
            else
            {
                layerAnimator[layer] = stateName;
            }
        }
        else
        {
            if (isLoop)
            {
                layerAnimator.Add(layer, stateName);
            }
        }
        var trackEntry = skeletonAnimation.AnimationState.SetAnimation(layer, stateName, isLoop);
        trackEntry.MixDuration = mixDuration;
        if (!isLoop && !isLast)
        {
            skeletonAnimation.AnimationState.AddEmptyAnimation(layer, 0, trackEntry.Animation.Duration);
        }
    }
    public Spine.Animation GetAnimation(string animationName)
    {
        return skeletonAnimation.AnimationState.Data.SkeletonData.FindAnimation(animationName);
    }
}
