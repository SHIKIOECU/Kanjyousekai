using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Animation/Data")]
public class AnimationData : ScriptableObject
{
    //アニメーション
    public RuntimeAnimatorController Controller;

    //トリガーの名前
    [SerializeField]
    private List<string> triggerName = new List<string>();
    public List<string> TriggerName { get { return triggerName; } }

    //アニメーターのトリガーを変更
    public void SetAnimation(Animator animator,string Name,bool value=true)
    {
        foreach(string name in triggerName)
        {
            if (name == Name)
            {
                animator.SetBool(Name, value);
            }
        }
    }
}
