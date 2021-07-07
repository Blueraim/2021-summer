using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerManager : MonoBehaviour
{
    public GameObject target;  //카메라가 따라갈 대상
    public float movespeed;  //카메라가 얼마나 빠른 속도로 따라갈지
    public BoxCollider2D bound;

    private Vector3 targetPosition;  //대상의 현재 위치 값
    private Vector3 minBound;
    private Vector3 maxBound;
    private float halfWidth;
    private float halfHeight;
    private Camera Camera;


    // Start is called before the first frame update
    void Start()
    {
        Camera = GetComponent<Camera>();
        minBound = bound.bounds.min;
        maxBound = bound.bounds.max;
        halfHeight = Camera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        if(target.gameObject != null)
        {
            targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);

            //A값과 B값 사이에 선형 보간으로 중간값을 리턴
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, movespeed * Time.deltaTime);

            float clampedX = Mathf.Clamp(this.transform.position.x, minBound.x + halfWidth, maxBound.x - halfWidth);
            float clampedY = Mathf.Clamp(this.transform.position.y, minBound.y + halfHeight, maxBound.y - halfHeight);

            this.transform.position = new Vector3(clampedX, clampedY, this.transform.position.z);
        }

    }

    /*public void SetBound(BoxCollider2D newBound)
    {
        bound = newBound;
        minBound = bound.bounds.min;
        maxBound = bound.bounds.max;
    }*/
}
