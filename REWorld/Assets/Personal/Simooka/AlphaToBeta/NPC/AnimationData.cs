using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Animation/Data")]
public class AnimationData : ScriptableObject
{
    public RuntimeAnimatorController Controller;

    [SerializeField]
    private List<string> triggerName = new List<string>();
    public List<string> TriggerName { get { return triggerName; } }

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
