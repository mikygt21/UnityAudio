using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class MusicController : MonoBehaviour
{
    public AudioMixerSnapshot[] snapshotsContainer;

   // public AudioMixerSnapshot idleSnapshot;
   // public AudioMixerSnapshot idleSuspenseSnapshot;
    public Slider sliderSelector;

    [Space(10)]
    public AudioMixerSnapshot resume_Snapshot;
    public AudioMixerSnapshot pause_Snapshot;

    public Button pauseButton;
    private TextMeshProUGUI pauseButtonText;
    private bool paused;


    // Start is called before the first frame update
    void Start()
    {
        sliderSelector.onValueChanged.AddListener(delegate { ChangeSnapshot(); });
        pauseButton.onClick.AddListener(delegate { PauseButton(); });
       // idleSnapshot.TransitionTo(1f);
        pauseButtonText = pauseButton.GetComponentInChildren<TextMeshProUGUI>();
        snapshotsContainer = new AudioMixerSnapshot[(int)sliderSelector.maxValue];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSnapshot()
    {
        snapshotsContainer[(int)sliderSelector.value].TransitionTo(1f);
    }

    public void PauseButton()
    {
        if(paused) {
          //  paused = false;
            pauseButtonText.text = "Pause";
            resume_Snapshot.TransitionTo(1f);
        }
        else {
            pauseButtonText.text = "Resume";
         //   paused = true;
            pause_Snapshot.TransitionTo(1f);

        }
        paused = !paused;

    }
}
