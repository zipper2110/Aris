using System;

public class SettingsPack
{
    private int breathInTime;
    private int breathOutTime;
    private int pauseAfterBreathIn;
    private int pauseAfterBreathOut;
    private int fullTime;

    public SettingsPack()
	{
	}

    public SettingsPack(int breathInTime, int breathOutTime, int pauseAfterBreathIn, int pauseAfterBreathOut, int fullTime)
    {

    }

    public void setBreathInTime(int breathInTime)
    {
        this.breathInTime = breathInTime;
    }

    public void setBreathOutTime(int breathOutTime)
    {
        this.breathOutTime = breathOutTime;
    }

    public void setPauseAfterBreathIn(int pauseAfterBreathIn)
    {
        this.pauseAfterBreathIn = pauseAfterBreathIn;
    }

    public void setPauseAfterBreathIn(int pauseAfterBreathIn)
    {
        this.pauseAfterBreathIn = pauseAfterBreathIn;
    }

    public void setFullTime(int fullTime)
    {
        this.fullTime = fullTime;
    }


    public int getBreathInTime()
    {
        return this.breathInTime;
    }

    public void getBreathOutTime()
    {
        return this.breathOutTime;
    }

    public void getPauseAfterBreathIn()
    {
        return this.pauseAfterBreathIn;
    }

    public void getPauseAfterBreathIn()
    {
        return this.pauseAfterBreathOut;
    }

    public void getFullTime()
    {
        return this.fullTime;
    }
}
