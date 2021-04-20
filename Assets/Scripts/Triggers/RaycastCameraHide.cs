using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Switches to a different material when in-between camera and the target

public class RaycastCameraHide : MonoBehaviour 
{
    public Material materialToSwitch;
    public float waitUntilFadeBack = 1.0f;
    public float fadeSpeed = 1.0f;

    private Material materialOriginal;
    private MeshRenderer meshRenderer;
    private float currentTime = 0;
    private bool culled = false;
    private Color originalColor;

    private Material newMaterial;

    private void Start() {
        meshRenderer = GetComponent<MeshRenderer>();
        materialOriginal = meshRenderer.material;
        originalColor = meshRenderer.material.color;
    }


    private void LateUpdate() {
        if (culled) {
            if (currentTime > 0) {
                Color colorToFade = meshRenderer.material.color;
                float fade = colorToFade.a - (fadeSpeed * Time.deltaTime);
                Color newColor = new Color(colorToFade.r, colorToFade.g, colorToFade.b, fade);
                meshRenderer.material.color = newColor;
                currentTime -= Time.deltaTime;
            }
            else {                                            
                culled = false;
            }
        } else {
            Color colorToFade = meshRenderer.material.color;
            float fade = colorToFade.a + (fadeSpeed * Time.deltaTime);
            Color newColor = new Color(colorToFade.r, colorToFade.g, colorToFade.b, fade);
            meshRenderer.material.color = newColor;
            if ((meshRenderer.material.color.a >= originalColor.a)
                   && (meshRenderer.material != materialOriginal)) {
                meshRenderer.material = materialOriginal;
            }
        }
    }

    public void Hide() {
        culled = true;
        currentTime = waitUntilFadeBack;
        meshRenderer.material = materialToSwitch;      
    }

}
