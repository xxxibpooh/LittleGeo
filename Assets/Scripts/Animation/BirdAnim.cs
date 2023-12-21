using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAnim : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        EventHandler.BirdAnim += OnBirdAnim; ;
    }

    private void OnBirdAnim()
    {
        if (animator != null) 
            animator.SetBool("IsMoving", true);
    }
}
