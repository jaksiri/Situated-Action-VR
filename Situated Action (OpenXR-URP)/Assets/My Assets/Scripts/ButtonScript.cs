using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private float moveLimit = .02f;

    private Vector3 _startPos;
    private bool _isPressed;
    
    public Material Green;
    public Material Red;
    public UnityEvent waterOn, waterOff;
    // Start is called before the first frame update
    private void Start()
    {
        _startPos = transform.localPosition;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_isPressed)
        {
            gameObject.GetComponentInChildren<MeshRenderer>().material = Green;
            gameObject.transform.localPosition = _startPos - new Vector3(0, moveLimit, 0);
            Debug.Log("Pressed Visual");
        }
        else
        {
            gameObject.GetComponentInChildren<MeshRenderer>().material = Red;
            gameObject.transform.localPosition = _startPos;
            Debug.Log("Released Visual");
        }
    }

    public void Pressed()
    {
        _isPressed = !_isPressed;
        if (_isPressed)
        {
            waterOn.Invoke();
        }
        else
        {
            waterOff.Invoke();
        }
    }


}
