﻿using UnityEngine;
using System.Collections;

public class LevelEndState : GameState
{
    GameObject _levelEndMenu = null;
    GameObject _levelFailMenu = null;

    public override void Enter()
    {
        if(!_levelEndMenu)
            _levelEndMenu = (GameObject)(Instantiate(Resources.Load("LevelEndMenu"), new Vector3(0, -15, 0), Quaternion.identity));
        if(!_levelFailMenu)
            _levelFailMenu = (GameObject)(Instantiate(Resources.Load("LevelEndFail"), new Vector3(0, -15, 0), Quaternion.identity));
        if (_stateName == "Default")
            _stateName = "LevelEnd";

        if (PlayerScript.Instance().Score < 50)
        {
            _levelFailMenu.transform.position = CameraScript.Instance().CameraPosition;
            _levelFailMenu.rigidbody2D.velocity = new Vector2(0, CameraScript.Instance().CameraMoveSpeed);
        }
        else
        {
            _levelEndMenu.transform.position = CameraScript.Instance().CameraPosition;
            _levelEndMenu.rigidbody2D.velocity = new Vector2(0, CameraScript.Instance().CameraMoveSpeed);
        }
    }

    public override void Exit()
    {
        _levelEndMenu.transform.position = new Vector2(0, -15);
        _levelFailMenu.transform.position = new Vector2(0, -15);
    }

    public override void UpdateState()
    {
        if(PlayerScript.Instance().Score < 50)
            _levelFailMenu.GetComponent<LevelEndMenuScript>().UpdateMenu();
        else
            _levelEndMenu.GetComponent<LevelEndMenuScript>().UpdateMenu();
    }
}
