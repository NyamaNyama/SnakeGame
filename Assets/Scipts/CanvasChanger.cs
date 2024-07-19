using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasChanger : MonoBehaviour
{
    [SerializeField] private Canvas Pause;
    [SerializeField] private Canvas GameOver;
    [SerializeField] private Canvas PointCount;

    private void Start()
    {
        SetActiveCanvas(PointCount);
    }
    private void Update()
    {
       PausePressed();
    }

    private void PausePressed()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pause.enabled)
            {
                SetActiveCanvas (PointCount);
          
            }
            else if (!Pause.enabled && !GameOver.enabled)
            {
                SetActiveCanvas(Pause);
            }
        }
    }

    public void ContinuePoint()
    {
        SetActiveCanvas(PointCount);
    }
    public void Die()
    {
        SetActiveCanvas(GameOver);
    }
    private void SetActiveCanvas(Canvas ActiveCanvas)
    {
        if(ActiveCanvas == PointCount) Time.timeScale = 1.0f;
        else Time.timeScale = 0;

        Pause.enabled = false;
        GameOver.enabled = false;
        PointCount.enabled = false;
        ActiveCanvas.enabled = true;

    }

}
