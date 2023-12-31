using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    FMOD.Studio.EventInstance gameMusic;
    FMOD.Studio.EventInstance gameAmbience;
    FMOD.Studio.EventInstance attackUnitSteps;
    FMOD.Studio.EventInstance springUnitSteps;
    FMOD.Studio.EventInstance catapultUnitSteps;
    FMOD.Studio.EventInstance bounce;
    FMOD.Studio.EventInstance buttonPressed;
    FMOD.Studio.EventInstance buttonRelease;
    FMOD.Studio.EventInstance bombButton;

    private void Awake()
    {
        gameMusic = FMODUnity.RuntimeManager.CreateInstance("event:/GameplayMusic");
        gameAmbience = FMODUnity.RuntimeManager.CreateInstance("event:/GameplayAmbience");
        attackUnitSteps = FMODUnity.RuntimeManager.CreateInstance("event:/AttackUnitSteps");
        springUnitSteps = FMODUnity.RuntimeManager.CreateInstance("event:/SpringUnitSteps");
        catapultUnitSteps = FMODUnity.RuntimeManager.CreateInstance("event:/CatapultUnitSteps");
        bounce = FMODUnity.RuntimeManager.CreateInstance("event:/Bounce");
        buttonPressed = FMODUnity.RuntimeManager.CreateInstance("event:/ButtonPressed");
        buttonRelease = FMODUnity.RuntimeManager.CreateInstance("event:/ButtonRelease");
        bombButton = FMODUnity.RuntimeManager.CreateInstance("event:/BombButton");
    }

    public void playMusic() {
        gameMusic.start();
    }
    
    public void stopMusic() {
        gameMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    //0- Reproduce musica noche 1- reproduce musica d�a. Con un gradiente se hace una transici�n suave
    public void setMusicState( float state) {
        gameMusic.setParameterByName("timeProgress", state);
    }

    //0 reproduce la m�sca - 1 reproduce la secuencia final.
    public void endMusic( int state) {
        gameMusic.setParameterByName("End", state);
    }

    public void playAmbience() {
        gameAmbience.start();
    }
    public void stopAmbience()
    {
        gameAmbience.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    //0- Reproduce ambiente noche 1- reproduce ambiente d�a. Con un gradiente se hace una transici�n suave
    public void setAmbienceState(float state)
    {
        gameAmbience.setParameterByName("dayState", state);
    }

    public void playBounce() {
        bounce.start();
    } 
    public void playButtonPressed() {
        buttonPressed.start();
    } 
    public void playButtonReleased() {
        buttonRelease.start();
    } 
    public void playBombButton() {
        bombButton.start();
    }
}
