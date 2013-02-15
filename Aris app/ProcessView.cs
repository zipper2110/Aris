using System;

public class ProcessView
{
    private Panel viewPanel;
    private ProgressBar progressBar;
    private Panel canvas;

	public ProcessView(Panel canvas)
	{
        viewPanel = new Panel();
        progressBar = new ProgressBar();
        this.canvas = canvas;
	}

    public void run()
    {
    }

    public void stop()
    {
    }

    public void pause() 
    { 
    }

    private void refreshSettings()
    {
    }

    public void draw()
    {
        this.canvas.get();
    }
}