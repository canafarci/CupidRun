using UnityEngine;

public static class PrefKeys
{
    public static string Currency = "Currency";
}

public static class AnimationStrings
{
    public static string CupidIdle = "female_idle_2";
    public static string FemaleIdle = "female_idle_1";
    public static string MaleIdle = "male_idle";
    public static string Kissing = "kiss";
    public static string Throw = "throw";
    public static string Dance = "dance";
    public static string Catwalk = "catwalk";
    public static string Flying = "flying";
    public static string Punch = "punch";
    public static string FlyTrigger = "fly_trig";
    public static string DanceTrigger = "dance_trig";
    public static string Argue = "argue";
}

public static class CameraStrings
{
    public static string RunCamera = "Run Camera";
    public static string EndPlatformCamera = "End Platform Camera";
    public static string FlyCamera = "Fly Camera";
    public static string StartCamera = "Start Camera";
    public static string EndGameCamera = "End Game Camera";
}

public enum AlignmentType
{
    Good,
    Evil,
    Neutral
}

public enum AnimatorEnums
{
    Cupid,
    Female,
    Male
}