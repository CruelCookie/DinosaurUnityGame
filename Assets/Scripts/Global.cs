using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Global : MonoBehaviour
{
    public static float gameSpeed;
    public static float SpeedIncrease = 0.1f;
    public static float maxGameSpeed = 1000f;
    
    public static float score;

    public static bool isPaused = false;
    
    public static float groundCheckRadius = 0.1f;

    public static readonly string ObstacleTag = "Obstacle";
    public static readonly string DinosaurTag = "Dinosaur";

    public static float minSpawnDelay = 1f;
    public static float maxSpawnDelay = 3f;
    
}