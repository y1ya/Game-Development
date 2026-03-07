using NUnit.Framework.Constraints;
using System;
using TMPro;
using UnityEngine;

public class HoverScript : MonoBehaviour
{
    Vector3 mousePosition;
    RaycastHit2D raycastHit2d;
    Transform prevHoverObject, nextHoverObject;
    private Vector3 cameraTargetPos, hitboxesTargetPos;
    public GameObject camera, hitboxes, rightHitbox;
    
    public float speedCam = 0f;
    private bool hasMoved;
    public float tolerance = 0.01f;

    private void Start()
    {
        camera.transform.position = new Vector3(0, camera.transform.position.y, camera.transform.position.z);  
    }

    void Update()
    {
        mousePosition = Input.mousePosition;

        Ray mouseRay = Camera.main.ScreenPointToRay(mousePosition);

        prevHoverObject = nextHoverObject;

        raycastHit2d = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);
        nextHoverObject = raycastHit2d ? raycastHit2d.collider.transform : null;

        cameraTargetPos = new Vector3(1.59f, camera.transform.position.y, camera.transform.position.z);
        hitboxesTargetPos = new Vector3(2.093f, hitboxes.transform.position.y, hitboxes.transform.position.z);

        // Move the Camera to the Right
        if (nextHoverObject && nextHoverObject.CompareTag("Right Hover"))
        {
            hasMoved = true;
        }

        if (hasMoved)
        {
            camera.transform.position =
                Vector3.MoveTowards(
                    camera.transform.position,
                    cameraTargetPos,
                    speedCam * Time.deltaTime
                );
            hitboxes.transform.position =
                Vector3.MoveTowards(
                    hitboxes.transform.position,
                    hitboxesTargetPos,
                    speedCam * Time.deltaTime
                );

            if (IsElementsAtTarget())
            {
                Debug.Log("Camera and Hitboxes has reached the target position.");

                rightHitbox.SetActive(false);

                hasMoved = false;
            }
        }


        // After Disabling the Right Hover, Move the Camera to the Left
        if (!isRightHoverActive() && !hasMoved)
        {
            rightHitbox.SetActive(true);
            if (nextHoverObject && nextHoverObject.CompareTag("Left Hover"))
            {
                hasMoved = true;
            }

            if (hasMoved)
            {
                
                cameraTargetPos = new Vector3(0f, camera.transform.position.y, camera.transform.position.z);
                hitboxesTargetPos = new Vector3(0.54792f, hitboxes.transform.position.y, hitboxes.transform.position.z);

                hitboxes.transform.position =
                    Vector3.MoveTowards(
                        hitboxes.transform.position,
                        hitboxesTargetPos,
                        speedCam * Time.deltaTime
                    );
                camera.transform.position =
                    Vector3.MoveTowards(
                        camera.transform.position,
                        cameraTargetPos,
                        speedCam * Time.deltaTime
                    );
            }

            if (IsElementsAtTarget())
            {
                Debug.Log("Camera and Hitboxes has reached the target position.");

                GameObject obj = GameObject.FindWithTag("Right Hover");
                if (obj != null)
                {
                    obj.SetActive(false); // Disables the GameObject
                }

                hasMoved = false;
            }
        }
    }


    bool IsElementsAtTarget()
    {
        return Vector3.Distance(camera.transform.position, cameraTargetPos) < tolerance &&
            Vector3.Distance(hitboxes.transform.position, hitboxesTargetPos) < tolerance;
    }

    bool isRightHoverActive()
    {
        GameObject obj = GameObject.Find("Right Square");
        
        if (obj != null)
        {
            if (!obj.activeSelf)
            {
                Debug.Log("GameObject 'RightHoverBox' is disabled.");
                return false;
            }
            else
            {
                Debug.Log("GameObject 'RightHoverBox' is active.");
                return true;
            }
        }
        return false;
    }


}
