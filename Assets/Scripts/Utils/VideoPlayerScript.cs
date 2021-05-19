using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeActivateVideo());
    }
    IEnumerator DeActivateVideo()
    {
        yield return new WaitForSeconds((float)gameObject.GetComponent<VideoPlayer>().clip.length);
        gameObject.SetActive(false);
    }
}
