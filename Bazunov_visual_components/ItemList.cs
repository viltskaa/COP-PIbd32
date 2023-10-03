namespace Bazunov_visual_components
{
    public partial class ItemList : UserControl
    {
        private EventHandler? _changeEvent;
        public ListBox.ObjectCollection Items => ListBoxCustom.Items;
        
        public ItemList()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            ListBoxCustom.Items.Clear();
        }

        public event EventHandler ChangeEvent
        {
            add
            {
                _changeEvent += value;
            }
            remove
            {
                _changeEvent -= value;
            }
        }

        public string SelectedElement
        {
            get
            {
                return (ListBoxCustom.SelectedIndex != -1 && ListBoxCustom.SelectedItem != null)
                    ? ListBoxCustom.SelectedItem.ToString()
                    : string.Empty;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    int index = ListBoxCustom.FindString(value);
                    if (index == -1) return;
                    ListBoxCustom.SetSelected(index, true);
                }
            }
        }

        private void ListBoxCustom_SelectedIndexChanged(object sender, EventArgs e)
        {
            _changeEvent?.Invoke(sender, e);
        }
    }
}
