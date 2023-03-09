using System;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField] private BoxCollider2D m_Trigger;
    [SerializeField] private CharacterController2D m_Controller;
    private SpriteRenderer m_Renderer;
    
    void Start()
    {
        m_Trigger = GetComponent<BoxCollider2D>();
        m_Renderer = GetComponent<SpriteRenderer>();
        m_Renderer.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        m_Controller = col.GetComponent<CharacterController2D>();
        
        if (m_Controller)
        {
            m_Controller.Die();
        }
    }
}
