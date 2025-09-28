using DarkUI.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;

namespace DarkUI.Controls
{
    public class DarkGridView : DarkScrollView
    {
        #region Event Region
        public event EventHandler<DarkListItem> SelectedItemChanged;
        #endregion

        #region Field Region
        private const int DEFAULT_ITEM_HEIGHT = 48;

        private readonly int _iconSize = 32;
        private int _itemHeight = DEFAULT_ITEM_HEIGHT;
        private bool _multiSelect;

        private ObservableCollection<DarkListItem> _items;
        private List<DarkListItem> _selectedItems;
        #endregion

        #region Property Region
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ObservableCollection<DarkListItem> Items
        {
            get { return _items; }
            set
            {
                if (_items != null)
                    _items.CollectionChanged -= Items_CollectionChanged;

                _items = value;
                _items.CollectionChanged += Items_CollectionChanged;
                UpdateGrid();
            }
        }

        /// <summary>
        /// Gets the list of selected indices.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<DarkListItem> SelectedIndices
        {
            get { return _selectedItems; }
        }

        /// <summary>
        /// Gets or sets the height of the individual list view items.
        /// </summary>
        [Category("Appearance")]
        [Description("Determines the height of the individual list view items.")]
        [DefaultValue(20)]
        public int ItemHeight
        {
            get { return _itemHeight; }
            set
            {
                _itemHeight = value;
                UpdateGrid();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether multiple list view items can be selected at once.
        /// </summary>
        [Category("Behaviour")]
        [Description("Determines whether multiple list view items can be selected at once.")]
        [DefaultValue(false)]
        public bool MultiSelect
        {
            get { return _multiSelect; }
            set { _multiSelect = value; }
        }
        #endregion

        #region Constructor
        public DarkGridView()
        {
            Items = [];
            _selectedItems = [];
        }
        #endregion

        #region Event Handle Region
        private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Method Region
        public void SelectItem(int index)
        {
            if(index < 0 || index > Items.Count - 1)
                throw new ArgumentOutOfRangeException(nameof(index));
            
            _selectedItems.Clear();
            _selectedItems.Add(Items[index]);

            SelectedItemChanged?.Invoke(this, Items[index]);

            Invalidate();
        }

        public void SelectItems(IEnumerable<int> indices)
        {
            _selectedItems.Clear();
            foreach (var index in indices)
            {
                if (index < 0 || index > Items.Count - 1)
                    throw new ArgumentOutOfRangeException(nameof(index));

                _selectedItems.Add(Items[index]);
            }

            //SelectedItemChanged?.Invoke(this, Items[index]);

            Invalidate();
        }

        private void UpdateGrid()
        {

        }
        #endregion

        #region Paint Region
        protected override void PaintContent(Graphics g)
        {

        }
        #endregion
    }
}
