using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pAnimatorController : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void Isidle()
    {
        animator.SetBool("Idle",true);
        animator.SetBool("Run",false);
    }
    public void IsRun()
    {
        animator.SetBool("Idle",false);
        animator.SetBool("Run",true);
    }


}
