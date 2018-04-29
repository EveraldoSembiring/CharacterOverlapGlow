using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Replace wall shader into only white shader
public class WallReplacement : MonoBehaviour
{
    RenderTexture _Rt;
    // Use this for initialization
    void Start()
    {
        _Rt = new RenderTexture(Screen.width, Screen.height, 24);
        Camera camera = GetComponent<Camera>();
        var wallShader = Shader.Find("RnD/WallReplace");
        camera.targetTexture = _Rt;
        camera.SetReplacementShader(wallShader, "Wall");
        Shader.SetGlobalTexture("_WallPassTex", _Rt);
    }
}
