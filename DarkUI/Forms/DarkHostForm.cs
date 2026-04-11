using DarkUI.Controls;
using DarkUI.Data.Enums;
using DarkUI.Docking;
using DarkUI.Managers;
using System.Windows.Forms;

namespace DarkUI.Forms
{
    public partial class DarkHostForm : DarkMetroForm
    {
        public bool HasContent => dockPanel.Contents.Count > 0;
        public DarkDockPanel DockPanel => dockPanel;

        public DarkHostForm()
        {
            InitializeComponent();

            Application.AddMessageFilter(dockPanel.DockContentDragFilter);

            dockPanel.ContentAdded += DockPanel_ContentAdded;
            dockPanel.ContentRemoved += DockPanel_ContentRemoved;
        }

        private void DockPanel_ContentAdded(object sender, DockContentEventArgs e)
        {
            // Withouth this, the MouseDrag event will not be captured by the DockPanel
            Focus();
        }

        private void DockPanel_ContentRemoved(object sender, DockContentEventArgs e)
        {
            Focus(); // Play it safe and focus again

            if (!HasContent)
            {
                DockDocumentManager.FormClosed(this);
                Close();
            }
        }

        private void DarkHostForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (HasContent)
            {
                var result = DarkMessageBox.ShowWarning("Close all documents?", "Attention", DarkDialogButton.YesNo);
                if (result == DialogResult.No || result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }
    }
}
