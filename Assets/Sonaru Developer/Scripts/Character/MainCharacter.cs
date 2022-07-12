using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    public float MoveSpeed;
    public MapSO worldMap;
    [SerializeField] private int rowPos;
    [SerializeField] private int colPos;
    [SerializeField] private CommandType nowFaceDir;
    

    private void Awake()
    {
        nowFaceDir = CommandType.Up;
    }

    public void CommandMoveCharacter(CommandType command)
    {
        switch (command)
        {
            case CommandType.Up:
                TryMove(command, worldMap.GetBlockData(rowPos + 1, colPos));
                break;
            
            case CommandType.Down:
                TryMove(command, worldMap.GetBlockData(rowPos - 1, colPos));
                break;
            
            case CommandType.Left:
                TryMove(command, worldMap.GetBlockData(rowPos, colPos - 1));
                break;
            
            case CommandType.Right:
                TryMove(command, worldMap.GetBlockData(rowPos, colPos + 1));
                break;
            
            case CommandType.NOTHING:
                break;
        }
    }
    
    private void TryMove(CommandType command, Block targetBlock)
    {
        // Count rotate angle
        //var FaceDiff = MathF.Abs((int)nowFaceDir - (int)command);
        
        if (targetBlock == null)
        {
            // Target no block
          
            return;
        }

        if (targetBlock.ThisBlockType == BlockType.Trap || targetBlock.ThisBlockType == BlockType.Wall)
        {
            // Target block is obstacle
            
            return;
        }

        else
        {
            // Target block can move

            rowPos++;
        }
    }
}
