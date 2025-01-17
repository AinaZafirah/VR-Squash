using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHit : MonoBehaviour
{
    public Color collisionColor = Color.green;
    private Color originalColor;
    private Renderer objectRenderer;

    private void Start()
    {
        objectRenderer = GetComponent<MeshRenderer>();
        if (objectRenderer != null)
        {
            if (ColorUtility.TryParseHtmlString("#E8CECE", out originalColor))
            {
                originalColor.a = 0f;
                Material material = objectRenderer.material;

                material.SetFloat("_Mode", 3);
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                material.SetInt("_ZWrite", 0);
                material.DisableKeyword("_ALPHATEST_ON");
                material.EnableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = 3000;

                material.color = originalColor;
            }
            else
            {
                Debug.LogWarning("Failed to parse original color.");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball") && objectRenderer != null)
        {
            objectRenderer.material.color = collisionColor;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball") && objectRenderer != null)
        {
            objectRenderer.material.color = originalColor;
        }
    }
}
