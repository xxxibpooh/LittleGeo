using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectAnim : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        EventHandler.InsectAnim += OnInsectAnim;
    }

    private void OnInsectAnim()
    {
        if (animator != null) 
            animator.SetBool("IsMoving", true);
    }
}
