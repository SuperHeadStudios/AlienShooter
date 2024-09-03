using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pAnimatorController : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void Isidle()
    {
        animator.SetBool("Idle",true);
        animator.SetBool("Walk",false);
        animator.SetBool("IdleShoot",false);
    }
    public void IsRun()
    {
        animator.SetBool("Idle",false);
        animator.SetBool("Walk",true);
        animator.SetBool("IdleShoot",false);
    }
    public void IsIdleShoot()
    {   
        animator.SetBool("IdleShoot",true);
        animator.SetBool("Idle",false);
        animator.SetBool("Walk",false);
    }


}
