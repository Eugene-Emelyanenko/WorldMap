using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveDuration = 1f;
    public float zoomDuration = 1f;
    public float defaultSize = 5f;
    public Camera mainCamera;

    private Vector3 startPosition = new Vector3(0f, 0f, -10f);

    private void Start()
    {
        mainCamera = Camera.main;
        mainCamera.transform.position = new Vector3(0f, 0f, mainCamera.transform.position.z);
        mainCamera.orthographicSize = defaultSize;
    }

    public void MoveAndZoomToTargetCountry(Vector2 targetPoint, float targetZoom, Action onCompleteAction)
    {
        Vector3 targetPosition = new Vector3(targetPoint.x, targetPoint.y, mainCamera.transform.position.z);
        
        LeanTween.move(mainCamera.gameObject, targetPosition, moveDuration)
            .setEase(LeanTweenType.easeInOutQuad).setOnComplete(() => onCompleteAction?.Invoke());
        
        LeanTween.value(mainCamera.gameObject, mainCamera.orthographicSize, targetZoom, zoomDuration)
            .setEase(LeanTweenType.easeInOutQuad)
            .setOnUpdate((value) =>
            {
                mainCamera.orthographicSize = value;
            });
    }

    public void ResetCamera(Action onCompleteAction)
    {
        LeanTween.move(mainCamera.gameObject, startPosition, moveDuration)
            .setEase(LeanTweenType.easeInOutQuad).setOnComplete(() => onCompleteAction?.Invoke());
        
        LeanTween.value(mainCamera.gameObject, mainCamera.orthographicSize, defaultSize, zoomDuration)
            .setEase(LeanTweenType.easeInOutQuad)
            .setOnUpdate((value) =>
            {
                mainCamera.orthographicSize = value;
            });
    }
}
