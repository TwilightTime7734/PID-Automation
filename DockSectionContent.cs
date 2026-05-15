using WeifenLuo.WinFormsUI.Docking;

namespace DronePidTuningAssistant.WinForms;

internal sealed class DockSectionContent : DockContent
{
    private readonly string _persistKey;

    public DockSectionContent(string title, string persistKey, Control hostedControl)
    {
        _persistKey = persistKey;
        Text = title;
        TabText = title;
        CloseButton = false;
        HideOnClose = true;
        DockAreas = DockAreas.DockLeft
            | DockAreas.DockRight
            | DockAreas.DockTop
            | DockAreas.DockBottom
            | DockAreas.Float
            | DockAreas.Document;

        if (hostedControl is GroupBox groupBox)
        {
            groupBox.Text = string.Empty;
            groupBox.Padding = new Padding(6);
        }

        hostedControl.Dock = DockStyle.Fill;
        Controls.Add(hostedControl);
    }

    protected override string GetPersistString()
    {
        return _persistKey;
    }
}
