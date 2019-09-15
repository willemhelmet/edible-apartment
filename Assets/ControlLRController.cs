using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class ControlLRController : MonoBehaviour
{
    MLInputController _controller;
    ControllerConnectionHandler _controllerConnectionHandler;

    LineRenderer _controlLR;

    // Start is called before the first frame update
    void Start()
    {
        MLInput.Start();

        _controllerConnectionHandler = this.gameObject.GetComponent<ControllerConnectionHandler>();
        //_controller = _controllerConnectionHandler.ConnectedController;
        _controller = MLInput.GetController(MLInput.Hand.Left);
        _controlLR = GameObject.Find("Control LR").GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_controllerConnectionHandler.IsControllerValid())
        {
            if (_controller.Type == MLInputControllerType.Control)
            {
                _controlLR.SetPosition(0, _controller.Position);
                RaycastHit hit;
                if (Physics.Raycast(_controller.Position, _controller.Orientation.eulerAngles, out hit, Mathf.Infinity))
                {
                    _controlLR.SetPosition(1, hit.point);
                }
                else
                {
                    _controlLR.SetPosition(1, _controller.Orientation.eulerAngles * 10f);
                }
            }
        }
    }
}
