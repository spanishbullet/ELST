/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELSTWinFormsLibrary;

public class TutorialManager
{
    private Form form;
    private Queue<Action> tutorialSteps;
    private OverlayHelper overlayHelper;

    public TutorialManager(Form form)
    {
        this.form = form;
        this.tutorialSteps = new Queue<Action>();
        this.overlayHelper = new OverlayHelper(form);
    }

    public void AddStep(Control control, string message)
    {
        tutorialSteps.Enqueue(() => overlayHelper.HighlightControl(control, message));
    }

    public void StartTutorial()
    {
        ShowNextStep();
    }

    private void ShowNextStep()
    {
        if (tutorialSteps.Count > 0)
        {
            var step = tutorialSteps.Dequeue();
            step();
        }
        else
        {
            EndTutorial();
        }
    }

    private void EndTutorial()
    {
        overlayHelper.HideOverlay();
        MessageBox.Show("Tutorial Complete!");
    }

    public void ContinueToNextStep()
    {
        overlayHelper.HideOverlay();
        ShowNextStep();
    }
}
*/