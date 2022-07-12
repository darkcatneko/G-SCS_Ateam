﻿

public enum StateEnum
{
    NOTHING,
    StartGame,
    PlayerCommand,
    CharacterMove,
    GameOver,
    SpecialEvent,
}

public enum CommandType
{
    Up,
    Right,
    Down,
    Left,
    NOTHING
}
[System.Serializable]
public enum Player
{
    Player1, Player2, Player3, Player4
}
[System.Serializable]
public enum ElementType
{
    Fire,Water,Wind,Earth
}

