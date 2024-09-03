using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator e_Animator;

    public void IsEidle()
    {
        e_Animator.SetBool("Idle", true);
        e_Animator.SetBool("Walk", false);
        e_Animator.SetBool("Dead", false);
    }
    public void IsEwalk()
    {
        e_Animator.SetBool("Walk", true);
        e_Animator.SetBool("Idle", false);
        e_Animator.SetBool("Dead", false);
    }

    public void IsEdead()
    {
        e_Animator.SetBool("Dead", true);
        e_Animator.SetBool("Walk", false);
        e_Animator.SetBool("Idle", false);
    }


}
