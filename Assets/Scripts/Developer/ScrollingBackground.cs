using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] Renderer bgRenderer;
    [Space(20)]
    [SerializeField] float xSpeed = 1;
    [SerializeField] float ySpeed = 1;

    // Update is called once per frame
    void Update()
    {
        Vector4 currentOffset = bgRenderer.material.GetVector("_Offset");
        bgRenderer.material.SetVector("_Offset", new Vector4(currentOffset.x + xSpeed * Time.deltaTime, 
                                        currentOffset.y + ySpeed * Time.deltaTime, 0, 0));
    }
}
