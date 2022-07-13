using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class MainCharacter : MonoBehaviour
{
    public float RotateDuration;
    public float MoveDuration;
    public MapSO worldMap;
    
    [SerializeField] private int rowPos;
    [SerializeField] private int colPos;
    //[SerializeField] private CommandType nowFaceDir;
    [SerializeField] private Block targetBlock;
    private Tweener rotateTweener;
    private Tweener moveTweener;
    
    public bool MoveOver;
    
    private PointData getPoint = null;
    private Animator characterAnim;
    
    public PointData GetPoint
    {
        get => getPoint;
        set
        {
            if(value != null) OnCharacterPointGet?.Invoke(value);
            getPoint = value;  
        } 
    }

    public event Action<PointData> OnCharacterPointGet;
    
    
    public void SetOriginPos(int col, int row)
    {
        colPos = col;
        rowPos = row;
    }
    
    private void Awake()
    {
        characterAnim = GetComponentInChildren<Animator>();
        //nowFaceDir = CommandType.Up;
        MoveOver = true;
        //Debug.Log(worldMap.GetBlockData(4,7));
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            CommandMoveCharacter(CommandType.Down);
        }
        
    }

    public void CommandMoveCharacter(CommandType command)
    {
        MoveOver = false;
        switch (command)
        {
            case CommandType.Up:
                if (TryMove(command, worldMap.GetBlockData(colPos, rowPos + 1))) rowPos++;
                break;
            
            case CommandType.Down:
                if(TryMove(command, worldMap.GetBlockData(colPos, rowPos - 1))) rowPos--;
                break;
            
            case CommandType.Left:
                if(TryMove(command, worldMap.GetBlockData(colPos - 1, rowPos))) colPos--;
                break;
            
            case CommandType.Right:
                if(TryMove(command, worldMap.GetBlockData(colPos + 1, rowPos))) colPos++;
                break;
            
            case CommandType.NOTHING:
                MoveOver = true;
                break;
        }
    }
    
    private bool TryMove(CommandType command, Block target)
    {
        targetBlock = target;
        
        rotateTweener?.Kill();
        // Count rotate angle
        if (command == CommandType.Up) rotateTweener = transform.DORotate(new Vector3(0,0,0), RotateDuration);
        if (command == CommandType.Down) rotateTweener = transform.DORotate(new Vector3(0,180,0), RotateDuration);
        if (command == CommandType.Left) rotateTweener = transform.DORotate(new Vector3(0,-90,0), RotateDuration);
        if (command == CommandType.Right) rotateTweener = transform.DORotate(new Vector3(0,90,0), RotateDuration);
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
            MoveOver = true;
            return;
        }

        if (targetBlock.ThisBlockType == BlockType.Trap || targetBlock.ThisBlockType == BlockType.Wall)
        {
            // Target block is obstacle
            Debug.Log("Hit a obstacle: " + targetBlock);
            moveTweener?.Kill();
            var moveForward = transform.forward * 5;    //5單位
            moveTweener = transform.DOMove(transform.position + moveForward, MoveDuration / 4).SetEase(Ease.OutSine);
            moveTweener.onComplete += () =>
            {
                transform.DOMove(transform.position - moveForward, MoveDuration / 4).SetEase(Ease.InSine).onComplete += () => MoveOver = true;
            };
            moveTweener.Play();
            targetBlock = null;
            
            return;
        }

        else
        {
            // Target block can move
            Debug.Log($"GO to : ({rowPos}, {colPos})" );
            moveTweener?.Kill();
            moveTweener = transform.DOMove(worldMap.GetWorldPosition(colPos, rowPos), MoveDuration);
            moveTweener.onUpdate += () => characterAnim.SetBool("isMoving", true);
            moveTweener.onComplete += () =>
            {
                characterAnim.SetBool("isMoving", false);
                MoveOver = true;
            };
            moveTweener.Play();
            //Debug.Log(worldMap.GetBlockData(colPos,rowPos));
            
            targetBlock = null;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PointItem"))
        {
            // same element get point -> add 2 points
            // opposite element -> lose 2 steps
            GetPoint = other.GetComponent<PointData>();
            if (GetPoint != null) GetPoint.Remove();
        }
    }
}
