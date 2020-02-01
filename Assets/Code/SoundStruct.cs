public class SoundStruct // this class creates the container for the sound
{
    public SoundStruct(FMOD.Studio.EventInstance sound, string name) // constructor
    {
        this.name = name;
        this.instance = sound;
    }
    public FMOD.Studio.EventInstance instance { get; private set; } // generating the FMOD Sound in Unity
    public string name { get; private set; } // give the FMOD instance a name and path reflected from the FMOD Project

    public void modifyFloat(string parameterName, float parameterValue) // This function is called in other scripts to have the sound's parameters changed 
    {
        instance.setParameterByName(parameterName, parameterValue); // actually update the parameter
    }
}