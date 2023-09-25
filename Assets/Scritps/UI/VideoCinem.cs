using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoCinem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Find the GameObject tagged as VideoPlayer
        GameObject videoPlayerObject = GameObject.FindGameObjectWithTag("VideoPlayer");

        // Get the VideoPlayer component
        VideoPlayer videoPlayer = videoPlayerObject.GetComponent<VideoPlayer>();

        // Set the URL based on the video in StreamingAssets
        string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, "Fly-Cinematica.mov");

        videoPlayer.url = videoPath;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
