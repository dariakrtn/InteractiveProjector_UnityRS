using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BlitManager : MonoBehaviour
{
    [System.Serializable]
    public struct BlitPipeline{
        public RenderTexture sourceTexture;
        public Material material;
        public RenderTexture desinationTexture;
    }

    [SerializeField]
    private BlitPipeline[] blitPipelines;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var pipeline in blitPipelines)
        {
            if (pipeline.sourceTexture == pipeline.desinationTexture){
                Debug.Log("sourceTeture should be different from destinationTexture");
                continue;
            }
            else{
                Graphics.Blit(pipeline.sourceTexture, pipeline.desinationTexture, pipeline.material);
            }
        }
    }
}
