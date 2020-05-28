using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    UP, DOWN, LEFT, RIGHT
}

public static class DirectionsExtension
{

    public static Vector2 GetVector(this Direction dir)
    {
        switch (dir)
        {
        case Direction.UP:
            return Vector2.up;
        case Direction.DOWN:
            return Vector2.down;
        case Direction.RIGHT:
            return Vector2.right;
        case Direction.LEFT:
            return Vector2.left;
        default:
                Debug.LogError("Error in GetVector: Defaulting");
            return new Vector2(0,0);
        }
    }

    public static Direction GetOpposite(this Direction dir)
    {
        switch (dir)
        {
            case Direction.UP:
                return Direction.DOWN;
            case Direction.DOWN:
                return Direction.UP;
            case Direction.RIGHT:
                return Direction.LEFT;
            case Direction.LEFT:
                return Direction.RIGHT;
            default:
                Debug.LogError("Error in GetOpposite: Defaulting");
                return Direction.UP;
        }
    }

    public static float GetAngle(this Direction dir)
    {
        switch (dir)
        {
            case Direction.UP:
                return 0;
            case Direction.DOWN:
                return 180;
            case Direction.RIGHT:
                return -90;
            case Direction.LEFT:
                return 90;
            default:
                Debug.LogError("Error in GetAngle: Defaulting");
                return 45;
        }
    }

    public static Orientation GetCornerWith(this Direction dir, Direction compare)
    {
        if (dir == compare)
        {
            switch (dir)
            {
                case Direction.UP:
                    return Orientation.UP;
                case Direction.DOWN:
                    return Orientation.DOWN;
                case Direction.LEFT:
                    return Orientation.LEFT;
                case Direction.RIGHT:
                    return Orientation.RIGHT;
            }
        }

        switch (dir)
        {
            case Direction.UP:
                switch (compare)
                {
                    case Direction.LEFT:
                        return Orientation.UP_LEFT;
                    case Direction.RIGHT:
                        return Orientation.UP_RIGHT;
                }
                break;
            case Direction.DOWN:
                switch (compare)
                {
                    case Direction.LEFT:
                        return Orientation.DOWN_LEFT;
                    case Direction.RIGHT:
                        return Orientation.DOWN_RIGHT;
                }
                break;
            case Direction.LEFT:
                switch (compare)
                {
                    case Direction.UP:
                        return Orientation.LEFT_UP;
                    case Direction.DOWN:
                        return Orientation.LEFT_DOWN;
                }
                break;
            case Direction.RIGHT:
                switch (compare)
                {
                    case Direction.UP:
                        return Orientation.RIGHT_UP;
                    case Direction.DOWN:
                        return Orientation.RIGHT_DOWN;
                }
                break;
            default:
                Debug.LogError("Error in GetCornerWith: Defaulting Not one of the 4 directions");
                return Orientation.NONE;
        }
        Debug.LogError("Error in GetCornerWith: Final Return");
        return Orientation.NONE;
    }

    public static Direction GetDirection(float Angle)
    {
        switch (Angle)
        {
            case 0:
                return Direction.UP;
            case 180:
                return Direction.DOWN;
            case -90:
                return Direction.RIGHT;
            case 90:
                return Direction.LEFT;
            default:
                Debug.LogError("Error in GetDirection: Defaulting");
                return Direction.UP;
        }
    }
        
    public static string ToString(this Direction dir)
    {
        switch (dir)
        {
            case Direction.UP:
                return "Up";
            case Direction.DOWN:
                return "Down";
            case Direction.RIGHT:
                return "Right";
            case Direction.LEFT:
                return "Left";
            default:
                Debug.LogError("Error in ToString: Defaulting");
                return "Non-Cardinal";
        }
    }
}
        


