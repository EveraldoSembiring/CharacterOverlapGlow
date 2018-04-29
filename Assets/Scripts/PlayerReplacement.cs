using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Replace character shader into only white shader
public class PlayerReplacement : MonoBehaviour
{
    RenderTexture _Rt;
    // Use this for initialization
    void Start()
    {
        _Rt = new RenderTexture(Screen.width, Screen.height, 24);
        Camera camera = GetComponent<Camera>();
        var playerShader = Shader.Find("RnD/PlayerReplace");
        camera.targetTexture = _Rt;
        camera.SetReplacementShader(playerShader, "Player");
        Shader.SetGlobalTexture("_PlayerPassTex", _Rt);
    }
}
