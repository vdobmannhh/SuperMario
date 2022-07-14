using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public enum AudioType
    {
        MainTheme,
        UnderworldTheme,
        BrickExplosion,
        PipeSound,
        Coin,
        FlagBar,
        OneUp,
        Oof,
        Waah,
        Mushroom,
        GoombaStomp,
        Click,
        StarTheme,
        GoombaExplosion,
        PowerDown,
        PowerUp,
        ItemPopUp,
        Fireball,
        Jump
    }

    [SerializeField] private AudioSource mainTheme;
    [SerializeField] private AudioSource underworldTheme;
    [SerializeField] private AudioSource brickExplosion;
    [SerializeField] private AudioSource pipeSound;
    [SerializeField] private AudioSource coin;
    [SerializeField] private AudioSource flagBar;
    [SerializeField] private AudioSource oneUp;
    [SerializeField] private AudioSource oof;
    [SerializeField] private AudioSource waah;
    [SerializeField] private AudioSource mushroom;
    [SerializeField] private AudioSource goombaStomp;
    [SerializeField] private AudioSource click;
    [SerializeField] private AudioSource starTheme;
    [SerializeField] private AudioSource goombaExplosion;
    [SerializeField] private AudioSource powerDown;
    [SerializeField] private AudioSource powerUp;
    [SerializeField] private AudioSource itemPopUp;
    [SerializeField] private AudioSource fireball;
    [SerializeField] private AudioSource jump;

    private static AudioSource audioMainTheme;
    private static AudioSource audioUnderworldTheme;
    private static AudioSource audioBrickExplosion;
    private static AudioSource audioPipeSound;
    private static AudioSource audioCoin;
    private static AudioSource audioFlagBar;
    private static AudioSource audioOneUp;
    private static AudioSource audioOof;
    private static AudioSource audioWaah;
    private static AudioSource audioMushroom;
    private static AudioSource audioGoombaStomp;
    private static AudioSource audioClick;
    private static AudioSource audioStarTheme;
    private static AudioSource audioGoombaExplosion;
    private static AudioSource audioPowerDown;
    private static AudioSource audioPowerUp;
    private static AudioSource audioItemPopUp;
    private static AudioSource audioFireball;
    private static AudioSource audioJump;

    private void Awake()
    {
        audioMainTheme = mainTheme;
        audioUnderworldTheme = underworldTheme;
        audioBrickExplosion = brickExplosion;
        audioPipeSound = pipeSound;
        audioCoin = coin;
        audioFlagBar = flagBar;
        audioOneUp = oneUp;
        audioOof = oof;
        audioWaah = waah;
        audioMushroom = mushroom;
        audioGoombaStomp = goombaStomp;
        audioClick = click;
        audioStarTheme = starTheme;
        audioGoombaExplosion = goombaExplosion;
        audioPowerDown = powerDown;
        audioPowerUp = powerUp;
        audioItemPopUp = itemPopUp;
        audioFireball = fireball;
        audioJump = jump;
    }

    public static AudioSource GetAudioSource(AudioType type)
    {
        switch (type)
        {
            case AudioType.MainTheme:
                return audioMainTheme;
            case AudioType.UnderworldTheme:
                return audioUnderworldTheme;
            case AudioType.BrickExplosion:
                return audioBrickExplosion;
            case AudioType.PipeSound:
                return audioPipeSound;
            case AudioType.Coin:
                return audioCoin;
            case AudioType.FlagBar:
                return audioFlagBar;
            case AudioType.OneUp:
                return audioOneUp;
            case AudioType.Oof:
                return audioOof;
            case AudioType.Waah:
                return audioWaah;
            case AudioType.Mushroom:
                return audioMushroom;
            case AudioType.GoombaStomp:
                return audioGoombaStomp;
            case AudioType.Click:
                return audioClick;
            case AudioType.StarTheme:
                return audioStarTheme;
            case AudioType.GoombaExplosion:
                return audioGoombaExplosion;
            case AudioType.PowerDown:
                return audioPowerDown;
            case AudioType.PowerUp:
                return audioPowerUp;
            case AudioType.ItemPopUp:
                return audioItemPopUp;
            case AudioType.Fireball:
                return audioFireball;
            case AudioType.Jump:
                return audioJump;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
}