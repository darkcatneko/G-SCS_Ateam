using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class MainCharacter : MonoBehaviour
{
    public float RotateDuration;
    public float MoveSpeed;
    public MapSO worldMap;
    [SerializeField] private int rowPos;
    [SerializeField] private int colPos;
    [SerializeField] private CommandType nowFaceDir;
    [SerializeField] private Block targetBlock;
    private Tweener rotateTweener;

    private void Awake()
    {
        nowFaceDir = CommandType.Up;
    }

    private void Update()
    {
        foreach (Gamepad g in Gamepad.all)
        {
            if (g.buttonEast.wasPressedThisFrame)
            {
                CommandMoveCharacter(CommandType.Right);
            }
        }
    }

    public void CommandMoveCharacter(CommandType command)
    {
        switch (command)
        {
            case CommandType.Up:
                if (TryMove(command, worldMap.GetBlockData(rowPos + 1, colPos))) rowPos++;
                break;
            
            case CommandType.Down:
                if(TryMove(command, worldMap.GetBlockData(rowPos - 1, colPos))) rowPos--;
                break;
            
            case CommandType.Left:
                if(TryMove(command, worldMap.GetBlockData(rowPos, colPos - 1))) colPos--;
                break;
            
            case CommandType.Right:
                if(TryMove(command, worldMap.GetBlockData(rowPos, colPos + 1))) colPos++;
                break;
            
            case CommandType.NOTHING:
                break;
        }
    }
    
    private bool TryMove(CommandType command, Block target)
    {
        targetBlock = target;
        
        rotateTweener?.Kill();
        // Count rotate angle
        if (command == CommandType.Up) rotateTweener = transform.DORotate(new Vector3(0,0,0), RotateDuration);
        if (command == CommandType.Down) rotateTweener = transform.DORotate(new Vector3(0,90,0), RotateDuration);
        if (command == CommandType.Left) rotateTweener = transform.DORotate(new Vector3(0,180,0), RotateDuration);
        if (command == CommandType.Right) rotateTweener = transform.DORotate(new Vector3(0,-90,0), RotateDuration);
        rotateTweener.onComplete += OnRotateFinish;
        rotateTweener.Play();

        return targetBlock.ThisBlockType == BlockType.Empty || targetBlock.ThisBlockType == BlockType.Point;
    }

    private void OnRotateFinish()
    {
        if (targetBlock == null)
        {
            // Target no block
            Debug.Log("Can't Move !");
            targetBlock = null;
            return;
        }

        if (targetBlock.ThisBlockType == BlockType.Trap || targetBlock.ThisBlockType == BlockType.Wall)
        {
            // Target block is obstacle
            Debug.Log("Hit a obstacle !");
            targetBlock = null;
            return;
        }

        else
        {
            // Target block can move
            Debug.Log("GO GO GO !");
            targetBlock = null;
            
        }
    }
}
