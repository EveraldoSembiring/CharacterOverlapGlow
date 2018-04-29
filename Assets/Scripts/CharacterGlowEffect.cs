using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Process glow from player's and wall's rendertexture 
public class CharacterGlowEffect : MonoBehaviour
{
    public Material CompositeMaterial;
    public Color GlowColor = Color.gray;
    public float Intensity = 1;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Shader.SetGlobalFloat("_CharacterOverlayIntensity", Intensity);
        Shader.SetGlobalColor("_CharacterOverlayColor", GlowColor);
        Graphics.Blit(source, destination, CompositeMaterial, 0);
    }
}
