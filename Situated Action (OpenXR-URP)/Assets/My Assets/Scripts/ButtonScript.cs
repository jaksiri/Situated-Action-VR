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
    private bool _lastState;
    
    public Material Green;
    public Material Red;
    public UnityEvent waterOn, waterOff;
    // Start is called before the first frame update
    private void Start()
    {
        _startPos = transform.localPosition;
        _isPressed = false;
        _lastState = _isPressed;
    }

    // Update is called once per frame
    private void Update()
    {

    }

    public void Pressed()
    {
        _lastState = _isPressed;
        _isPressed = !_isPressed;
        if (_isPressed)
        {
            gameObject.GetComponentInChildren<MeshRenderer>().material = Green;
            gameObject.transform.localPosition = _startPos - new Vector3(0, moveLimit, 0);
            Debug.Log("Pressed");
            waterOn?.Invoke();
        }
        else
        {
            gameObject.GetComponentInChildren<MeshRenderer>().material = Red;
            gameObject.transform.localPosition = _startPos;
            Debug.Log("Released");
            waterOff?.Invoke();
        }
    }
    
    public void WaterState(bool state)
    {
        if (state)
        {
            if (!_isPressed) { Pressed(); }
        }
        else
        {
            if (_isPressed) { Pressed(); }
        }
    }

}
