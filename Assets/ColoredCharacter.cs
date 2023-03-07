using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ColoredCharacter : MonoBehaviour
{
    [SerializeField] public ElementColor color;

    public void OnValidate()
    {
        SpriteRenderer srenderer = GetComponent<SpriteRenderer>();
        if (srenderer && WorldParameters.Instance)
            srenderer.color = WorldParameters.Instance.GetColor(color);

        #if UNITY_EDITOR
        EditorApplication.delayCall += () =>
        {
            gameObject.layer = WorldParameters.Instance.GetColorCharacterMask(color);

            CharacterController2D controller = GetComponent<CharacterController2D>();
            if (controller)
                controller.groundCheck.gameObject.layer = WorldParameters.Instance.GetColorCharacterGroundMask(color);
        };
        #endif
    }
}
