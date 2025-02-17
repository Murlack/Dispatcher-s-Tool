using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class OpenPanels
    {
        private Panel _activePanel;
        private Panel[] _panels = new Panel[7];

        public OpenPanels(Panel[] _panel) 
        {
            _panels = _panel;
        }
        private void ShowActivePanel()
        {
            _activePanel.Show();
        }
        private void HidePanel()
        {
            foreach (var panel in _panels)
                if (panel.Name != _activePanel.Name)
                    if (panel.Visible == true)
                        panel.Hide();
        }
        public void SetActivePanel(Panel _panel)
        { 
            _activePanel = _panel;
            ShowActivePanel();
            HidePanel();
        }
    }
}
