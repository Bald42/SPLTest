public static class Enums
{
    public enum EnemyMoveVector
    {
        Null = 0,
        MoveX = 1,
        MoveZ = 2
    }

    public enum Tag
    {
        Null = 0,
        Player = 1,
        Enemy = 2,
        Obstacle = 3,
        Bullet = 4
    }

    public enum GameState
    {
        Null = 0,
        Play = 1,
        Win = 2,
        Lose = 3
    }
}