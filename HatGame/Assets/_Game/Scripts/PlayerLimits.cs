using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLimits : MonoBehaviour
{
    private float minX, maxX;

    [SerializeField] private float minDistance, maxDistance;
    // Start is called before the first frame update
    void Start()
    {
        SetMinAndMax();
    }

    // Update is called once per frame
    void Update()
    {
        SetPlayerPosition();
    }
    private void SetMinAndMax() 
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.safeArea.width, 0f, 0f));
        minX = - bounds.x + minDistance;
        maxX = bounds.x - maxDistance;
    
    }

    private void SetPlayerPosition()
    {
        if (transform.position.x < minX)
        {
            Vector3 temp= transform.position;
            temp.x = minX;
            transform.position = temp;
        }
        else if (transform.position.x > maxX)
        {
            Vector3 temp = transform.position;
            temp.x = maxX;
            transform.position = temp;
        }
    }
}
