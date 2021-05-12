using UnityEngine;

public class PainterQuadScaler : MonoBehaviour
{
    public int StandardWidth;
    public int StandardHeigth;

    void Start()
    {
        float standardScreenSize = (float)StandardHeigth / (float)StandardWidth;
        float playerScreenSize = (float)Screen.height / (float)Screen.width;

        Debug.Log(standardScreenSize);
        Debug.Log(playerScreenSize);

        float HorizontalScaleModifier = standardScreenSize / playerScreenSize;
        Debug.Log(HorizontalScaleModifier);

        this.transform.localScale = new Vector3(transform.localScale.x * HorizontalScaleModifier, transform.localScale.y, transform.localScale.z);
    }
}
