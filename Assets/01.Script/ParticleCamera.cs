using UnityEngine;

public class ParticleCamera : MonoBehaviour
{
    public Camera renderCam;
    public RenderTexture renderTexture;

    void Start()
    {
        renderCam.clearFlags = CameraClearFlags.SolidColor;
        renderCam.backgroundColor = new Color(0, 0, 0, 0);
        renderCam.targetTexture = renderTexture;
    }
}
