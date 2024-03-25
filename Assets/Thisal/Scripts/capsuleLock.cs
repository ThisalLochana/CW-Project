using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capsuleLock : MonoBehaviour
{
    private bool isLocked = false;
    private Vector3 lockedPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.L))
        {
            isLocked = !isLocked;
            if (isLocked)
            {
                lockedPosition = transform.position;
            }
        }
        if (isLocked)
        {
            transform.position = lockedPosition;
        }
    }
}
