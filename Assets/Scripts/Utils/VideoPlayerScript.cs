using MexiColeccion.Collection;
using MexiColeccion.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerScript : MonoBehaviour
{
    [SerializeField] private Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.GetComponent<VideoPlayer>().clip.name == "MemoryVideo")
        {
            if (PlayerPrefs.GetInt(CollectionDatabase.MemoryVideo) != 1)
            {
                gameObject.transform.localPosition = new Vector3(-gameObject.GetComponent<RectTransform>().rect.width / 2, -gameObject.GetComponent<RectTransform>().rect.height / 2, 0);
                PlayerPrefs.SetInt(CollectionDatabase.MemoryVideo, 1);
                StartCoroutine(DeActivateVideo());
            }
            else
                CancelVideo();

        }
        else
        {
            if (PlayerPrefs.GetInt(CollectionDatabase.PainterVideo) != 1)
            {
                gameObject.transform.localPosition = new Vector3(0, 0, 0);
                PlayerPrefs.SetInt(CollectionDatabase.PainterVideo, 1);
                StartCoroutine(DeActivateVideo());
            }
            else
                CancelVideo();

        }

    }
    IEnumerator DeActivateVideo()
    {
        yield return new WaitForSeconds((float)gameObject.GetComponent<VideoPlayer>().clip.length);
        CancelVideo();
    }

    public void CancelVideo()
    {
        timer.IsTimerRunning = true;
        gameObject.SetActive(false);
    }
}
