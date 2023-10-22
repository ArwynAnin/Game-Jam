using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

 
    void Update()
    {
        
    }
}
