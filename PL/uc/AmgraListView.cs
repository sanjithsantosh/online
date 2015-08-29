

using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web;
using System.Data;

namespace PL.Amgra
{
    /// <summary>
    /// AgoraListView: Custom list with inbuilt pagination and sorting. 
    /// </summary>
    public class AmgraListView : ListView
    {   

        #region ShowPagination
        /// <summary>
        /// Get or Set whether the pagination block need to show or not.
        /// </summary>
        public bool ShowPagination
        {
            get;
            set;
        }
        #endregion

        #region ViewMode
        public ListViewMode _ViewMode = ListViewMode.ReadOnly;
        /// <summary>
        /// Get or sets the view mode of the list view. You need to rebind the datasource if you are
        /// setting view mode as 'ReadOnly'
        /// </summary>
        public ListViewMode ViewMode
        {
            get
            {
                object _ViewModeViewState = ViewState[this.ClientID + "_ViewMode"];
                if (_ViewModeViewState != null)
                {
                    return (ListViewMode) _ViewModeViewState;
                }
                else
                {
                    return _ViewMode;
                }
            }
            set
            {
                this.ViewState[this.ClientID + "_ViewMode"] = _ViewMode = value;
                this.DataSource = null;
                this.DataBind();
            }
        }
        #endregion

        #region CommandSource
        /// <summary>
        /// Get or sets the command source of the list view
        /// </summary>
        public object CommandSource
        {
            get;
            set;
        }
        #endregion
        
        #region FilterOptions
        public List<FilterOption> _FilterOptions = new List<FilterOption>();
        /// <summary>
        /// Get or sets selected filter options of the list view
        /// </summary>
        public List<FilterOption> FilterOptions
        {
            get
            {
                object _FilterOptionsViewState = ViewState[this.ClientID + "_FilterOptions"];
                if (_FilterOptionsViewState != null)
                {
                    return (List<FilterOption>) _FilterOptionsViewState;
                }
                else
                {
                    return _FilterOptions;
                }
            }
            set
            {
                this.ViewState[this.ClientID + "_FilterOptions"] = _FilterOptions = value;
            }
        }
        #endregion

        #region EmptyInfoText
        private string _EmptyInfoText = "No Records Found";
        /// <summary>
        /// Get or sets the information text need to show while the datasource is empty or null.
        /// </summary>
        [Bindable(true)]
        public string EmptyInfoText
        {
            get
            {
                object _EmptyInfoTextViewState = ViewState[this.ClientID + "_EmptyInfoText"];
                if (_EmptyInfoTextViewState != null)
                {
                    return Convert.ToString(_EmptyInfoTextViewState);
                }
                else
                {
                    return _EmptyInfoText;
                }
            }
            set
            {
                this.ViewState[this.ClientID + "_EmptyInfoText"] = _EmptyInfoText = value;
            }
        }
        #endregion

        #region ShowListHeader
        /// <summary>
        /// Get or Set whether the list header need to show or not. 
        /// FYI: Filter Link will show only if the List header is visible
        /// </summary>
        public bool ShowListHeader
        {
            get;
            set;
        }
        #endregion

        #region IsOnFilter
        /// <summary>
        /// Get or Set whether the user has applied any filter on the list.
        /// </summary>
        public bool IsOnFilter
        {
            get
            {
                if (FilterOptions.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion

        #region ListHeading
        /// <summary>
        /// Get or Set the list heading of the list
        /// </summary>
        public string ListHeading
        {
            get;
            set;
        }
        #endregion

        #region ShowFilter
        /// <summary>
        /// Get or Set whether the list header need to show or not.
        /// FYI: Filter Link will show only if the List header is visible
        /// </summary>
        public bool ShowFilter
        {
            get;
            set;
        }
        #endregion

        #region CssClassPagination
        private string _CssClassPagination = "Pagination";
        /// <summary>
        /// Get or Set CSS class name of the pagination block (TR)
        /// </summary>
        public string CssClassPagination
        {
            get
            {
                object _CssClassPaginationViewState = ViewState[this.ClientID + "_CssClassPagination"];
                if (_CssClassPaginationViewState != null)
                {
                    return _CssClassPaginationViewState.ToString();
                }
                else
                {
                    return _CssClassPagination;
                }
            }
            set
            {
                this.ViewState[this.ClientID + "_CssClassPagination"] = _CssClassPagination = value;
            }
        }
        #endregion

        #region CssClassListHeader
        private string _CssClassListHeader = "GridTitle";
        /// <summary>
        /// Get or Set CSS class name of the pagination block (TR)
        /// </summary>
        public string CssClassListHeader
        {
            get
            {
                object _CssClassListHeaderViewState = ViewState[this.ClientID + "_CssClassListHeader"];
                if (_CssClassListHeaderViewState != null)
                {
                    return _CssClassListHeaderViewState.ToString();
                }
                else
                {
                    return _CssClassListHeader;
                }
            }
            set
            {
                this.ViewState[this.ClientID + "_CssClassListHeader"] = _CssClassListHeader = value;
            }
        }
        #endregion

        #region PaginationPanelID
        /// <summary>
        /// Get or Set the panel id of the pagination
        /// </summary>
        public string PaginationPanelID
        {
            get;
            set;
        }
        #endregion

        #region FilterBoxContainerID
        /// <summary>
        /// Get or Set the container id of the filter box
        /// </summary>
        public string FilterBoxContainerID
        {
            get;
            set;
        }
        #endregion

        #region ListHeaderPanelID
        /// <summary>
        /// Get or Set the panel container id of the list header. 
        /// </summary>
        public string ListHeaderPanelID
        {
            get;
            set;
        }
        #endregion

        #region InsertTemplatePanelID
        /// <summary>
        /// Get or sets the panel container id of the insert template. 
        /// </summary>
        public string InsertTemplatePanelID
        {
            get;
            set;
        }
        #endregion

        #region CurrentSortDirection
        private SortDirection _CurrentSortDirection = SortDirection.Ascending;
        /// <summary>
        /// Get or Set current sort direction of the column.
        /// </summary>
        public SortDirection CurrentSortDirection
        {
            get
            {
                object _CurrentSortDirectionViewState = ViewState[this.ClientID + "_CurrentSortDirection"];
                if (_CurrentSortDirectionViewState != null)
                {
                    return (SortDirection)_CurrentSortDirectionViewState;
                }
                else
                {
                    return SortDirection.Ascending;
                }
            }
            set
            {
                this.ViewState[this.ClientID + "_CurrentSortDirection"] = _CurrentSortDirection = value;
            }
        }
        #endregion
        
        #region CurrentSortColumnName
        private string _CurrentSortColumnName = null;
        /// <summary>
        /// Get or Set current sort column of the list view.
        /// </summary>
        public string CurrentSortColumnName
        {
            get
            {
                object _CurrentSortColumnNameViewState = ViewState[this.ClientID + "_CurrentSortColumnName"];
                if (_CurrentSortColumnNameViewState != null)
                {
                    return _CurrentSortColumnNameViewState.ToString();
                }
                else
                {
                    return "";
                }
            }
            set
            {
                this.ViewState[this.ClientID + "_CurrentSortColumnName"] = _CurrentSortColumnName = value;
            }
        }
        #endregion

        #region TotalVisibleColumns
        private int _TotalVisibleColumns = 0;
        /// <summary>
        /// Get or Set the total number of visible columns in the list view
        /// </summary>
        public int TotalVisibleColumns
        {
            get
            {
                object _TotalVisibleColumnsViewState = ViewState[this.ClientID + "_TotalVisibleColumns"];
                if (_TotalVisibleColumnsViewState != null)
                {
                    return (int)_TotalVisibleColumnsViewState;
                }
                else
                {
                    return _TotalVisibleColumns;
                }
            }
            set
            {
                this.ViewState[this.ClientID + "_TotalVisibleColumns"] = _TotalVisibleColumns = value;
            }
        }
        #endregion

        #region DataSourceCache
        public override object DataSource
        {
            get
            {
                if (DataSourceCache != null) return DataSourceCache;
                return base.DataSource;
            }
            set
            {
                DataSourceCache = value;
                base.DataSource = value;
            }
        }
        private object _DataSourceCache = null;
        /// <summary>
        /// Get or sets the cache of the datasource attached last time.
        /// </summary>
        public object DataSourceCache
        {
            get
            {
                object _DataSourceCacheViewState = ViewState[this.ClientID + "_DataSourceCache"];
                if (_DataSourceCacheViewState != null)
                {
                    return (object)_DataSourceCacheViewState;
                }
                else
                {
                    return _DataSourceCache;
                }
            }
            set
            {
                this.ViewState[this.ClientID + "_DataSourceCache"] = _DataSourceCache = value;
            }
        }
        #endregion
                
        #region PageNumber
        private int _PageNumber = 1;
        /// <summary>
        /// Get or Set the page number of the list view.
        /// </summary>
        public int PageNumber
        {
            get
            {
                object _PageNumberViewState = ViewState[this.ClientID + "_PageNumber"];
                if (_PageNumberViewState != null)
                {
                    return (int) _PageNumberViewState;
                }
                else
                {
                    return 1;
                }
            }
            set
            {
                this.ViewState[this.ClientID + "_PageNumber"] = _PageNumber = value;
            }
        }
        #endregion
        
        #region ItemsPerPage
        private int _ItemsPerPage = 5;
        /// <summary>
        /// Get or Set the number of items per page in the list view.
        /// </summary>
        public int ItemsPerPage
        {
            get
            {
                object _ItemsPerPageViewState = ViewState[this.ClientID + "_ItemsPerPage"];
                if (_ItemsPerPageViewState != null)
                {
                    return (int)_ItemsPerPageViewState;
                }
                else
                {
                    return 5;
                }
            }
            set
            {
                this.ViewState[this.ClientID + "_ItemsPerPage"] = _ItemsPerPage = value;
            }
        }
        #endregion

        #region ItemsPerPageOptions
        /// <summary>
        /// Get or Set the list of options available for items per page control. FYI: separate each item by comma
        /// </summary>
        public string ItemsPerPageOptions
        {
            get;
            set;
        }
        #endregion

        #region TotalItems
        private int _TotalItems = 0;
        /// <summary>
        /// Get or Set the total number of items in the resultset/datasource of the list view.
        /// </summary>
        public int TotalItems
        {
            get
            {
                object _TotalItemsViewState = ViewState[this.ClientID + "_TotalItems"];
                if (_TotalItemsViewState != null)
                {
                    return (int)_TotalItemsViewState;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState[this.ClientID + "_TotalItems"] = _TotalItems = value;
            }
        }
        #endregion

        #region TotalPages
        /// <summary>
        /// Get the total number of pages int the list view.
        /// </summary>
        public int TotalPages
        {
            get
            {
                if (ItemsPerPage == 0 || PageNumber == 0) return 1;
                int _TotalPagesInt = ((TotalItems / ItemsPerPage) == 0) ? 1 : TotalItems / ItemsPerPage;
                if ((TotalItems % ItemsPerPage != 0) && (TotalItems > ItemsPerPage))
                {
                    _TotalPagesInt++;
                }
                return Convert.ToInt32(_TotalPagesInt);
            }
        }
        #endregion

        #region PageStartIndex
        /// <summary>
        /// Get the index of the first item showing in the page. FYI: Index is starting from 1
        /// </summary>
        public int PageStartIndex
        {
            get
            {
                int _PageStartIndex = (PageNumber * ItemsPerPage) - ItemsPerPage + 1;
                if (_PageStartIndex > TotalItems) _PageStartIndex = TotalItems;
                return _PageStartIndex;
            }
        }
        #endregion

        #region PageEndIndex
        /// <summary>
        /// Get the index of the last item showing in the page. FYI: Index is starting from 1
        /// </summary>
        public int PageEndIndex
        {
            get
            {
                int _PageEndIndex = PageNumber * ItemsPerPage;
                if(_PageEndIndex > TotalItems) _PageEndIndex = TotalItems;
                return _PageEndIndex;
            }
        }
        #endregion

        #region Custom Events
                    
            public delegate void SortColumnChangedEventHandler(object sender, SortEventArgs e);
            /// <summary>
            /// The event will raise if the sort column has been changed by cliking on list view column headers
            /// </summary>
            public event SortColumnChangedEventHandler SortColumnChanged;

            public delegate void PageIndexChangedEventHandler(object sender, PaginationEventArgs e);
            /// <summary>
            /// The event will raise if the the page number or items per page values has been changed due to pagination
            /// </summary>
            public event PageIndexChangedEventHandler PageIndexChanged;

        #endregion
               
        protected virtual void OnSortColumnChanged(object sender, SortEventArgs e)
        {
            if (SortColumnChanged != null) SortColumnChanged(this, e);
        }

        protected virtual void OnPageIndexChanged(object sender, PaginationEventArgs e)
        {
            if (PageIndexChanged != null) PageIndexChanged(this, e);
        }

        protected override void OnLoad(EventArgs e)
        {
            if (this.Page.IsPostBack)
            {
                if (ViewMode == ListViewMode.Insert) ViewMode = ListViewMode.Insert;
            }
            base.OnLoad(e);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
            if (this.DataSource == null && this.ViewMode != ListViewMode.Insert)
            {
                writer.Write(string.Format("<tr><td class=\"Info\" colspan=\"{0}\">{1}</td></tr>", TotalVisibleColumns, EmptyInfoText));
                return;
            }
            if (this.TotalItems == 0 && this.ViewMode != ListViewMode.Insert )
            {
                writer.Write(string.Format("<tr><td class=\"Info\" colspan=\"{0}\">{1}</td></tr>", TotalVisibleColumns, EmptyInfoText));
                return;
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            List<Control> _controls = getControlsByType(this.Parent, typeof(Panel));
            foreach (Control _control in _controls)
            {                
                Panel _PanelContainer = (Panel)_control;

                // Creating pagination block
                if (string.Equals(_PanelContainer.ID, PaginationPanelID) && ShowPagination && TotalItems != 0)
                {
                    if (ViewMode != ListViewMode.ReadOnly)
                    {
                        _PanelContainer.Visible = false;
                    }
                    else
                    {
                        _PanelContainer.Visible = true;
                        
                        if (string.IsNullOrEmpty(ItemsPerPageOptions)) throw new Exception("ItemsPerPageOption items can not be null if the pagination is on");

                        if (PageNumber > 1 && PageNumber < TotalPages)
                        {                        
                            ((LinkButton)_PanelContainer.FindControl("lnkFirst")).Visible = true;
                            ((LinkButton)_PanelContainer.FindControl("lnkPrevious")).Visible = true;
                            ((LinkButton)_PanelContainer.FindControl("lnkNext")).Visible = true;
                            ((LinkButton)_PanelContainer.FindControl("lnkLast")).Visible = true;
                            ((Literal)_PanelContainer.FindControl("litSep1")).Visible = true;
                            ((Literal)_PanelContainer.FindControl("litSep2")).Visible = true;
                            ((Literal)_PanelContainer.FindControl("litSep3")).Visible = true;
                        }
                        else if (PageNumber > 1)
                        {
                            ((LinkButton)_PanelContainer.FindControl("lnkFirst")).Visible = true;
                            ((LinkButton)_PanelContainer.FindControl("lnkPrevious")).Visible = true;
                            ((LinkButton)_PanelContainer.FindControl("lnkNext")).Visible = false;
                            ((LinkButton)_PanelContainer.FindControl("lnkLast")).Visible = false;
                            ((Literal)_PanelContainer.FindControl("litSep1")).Visible = true;
                            ((Literal)_PanelContainer.FindControl("litSep2")).Visible = false;
                            ((Literal)_PanelContainer.FindControl("litSep3")).Visible = false;
                        }
                        else if (PageNumber < TotalPages)
                        {
                            ((LinkButton)_PanelContainer.FindControl("lnkFirst")).Visible = false;
                            ((LinkButton)_PanelContainer.FindControl("lnkPrevious")).Visible = false;
                            ((LinkButton)_PanelContainer.FindControl("lnkNext")).Visible = true;
                            ((LinkButton)_PanelContainer.FindControl("lnkLast")).Visible = true;
                            ((Literal)_PanelContainer.FindControl("litSep1")).Visible = false;
                            ((Literal)_PanelContainer.FindControl("litSep2")).Visible = false;
                            ((Literal)_PanelContainer.FindControl("litSep3")).Visible = true;
                        }
                        else if (TotalPages <= ItemsPerPage)
                        {                             
                            ((LinkButton)_PanelContainer.FindControl("lnkFirst")).Visible = false;
                            ((LinkButton)_PanelContainer.FindControl("lnkPrevious")).Visible = false;
                            ((LinkButton)_PanelContainer.FindControl("lnkNext")).Visible = false;
                            ((LinkButton)_PanelContainer.FindControl("lnkLast")).Visible = false;
                            ((Literal)_PanelContainer.FindControl("litSep1")).Visible = false;
                            ((Literal)_PanelContainer.FindControl("litSep2")).Visible = false;
                            ((Literal)_PanelContainer.FindControl("litSep3")).Visible = false;
                        }

                        Literal _PaginationLinkSeparator5 = (Literal) _PanelContainer.FindControl("litSep5");
                        _PaginationLinkSeparator5.Text = string.Format("&nbsp;of&nbsp;<strong>{0}</strong> &nbsp; | &nbsp; Records Per Page", TotalPages);

                        AmgraTextBox _PaginationPageNumber = (AmgraTextBox)_PanelContainer.FindControl("txtPageNumber");
                        _PaginationPageNumber.Text = PageNumber.ToString();

                        DropDownList _PaginationItemsPerPageList = (DropDownList)_PanelContainer.FindControl("cmbItemsPerPage");
                        _PaginationItemsPerPageList.SelectedValue = ItemsPerPage.ToString();

                        Literal _PaginationStatusInfo = (Literal)_PanelContainer.FindControl("litStatusInfo");
                        _PaginationStatusInfo.Text = string.Format("View&nbsp;{0}-{1}&nbsp;of&nbsp;{2}", PageStartIndex.ToString(), PageEndIndex.ToString(), TotalItems.ToString());
                    }
                }
                // Creating list header block
                else if (string.Equals(_PanelContainer.ID, ListHeaderPanelID) && string.Equals(this.ID, _PanelContainer.ToolTip) && ShowListHeader)
                {
                    TableRow _ListHeaderRow = new TableRow();
                    _ListHeaderRow.Attributes.Add("class", CssClassListHeader);
                    
                    TableCell _ListHeaderCell = new TableCell();
                    _ListHeaderCell.Attributes.Add("colspan", TotalVisibleColumns.ToString());

                    Label _ListHeaderTitle = new Label();
                    _ListHeaderTitle.Text = ListHeading;
                    _ListHeaderCell.Controls.Add(_ListHeaderTitle);

                    if (ShowFilter && ViewMode == ListViewMode.ReadOnly)
                    {
                        HtmlAnchor _ListHeaderFilterLink = new HtmlAnchor();
                        _ListHeaderFilterLink.HRef = "javascript:void(0);";                        
                        _ListHeaderFilterLink.InnerText = "Filter";

                        if (FilterOptions.Count > 0)
                        {
                            _ListHeaderFilterLink.Attributes.Add("class", "HasFilter");
                            _ListHeaderFilterLink.Attributes.Add("onclick", string.Format("javascript:ShowFilter('{0}', true);", FilterBoxContainerID));
                        }
                        else
                        {
                            _ListHeaderFilterLink.Attributes.Add("onclick", string.Format("javascript:ShowFilter('{0}', false);", FilterBoxContainerID));
                        }

                        _ListHeaderCell.Controls.Add(_ListHeaderFilterLink);
                    }

                    _ListHeaderRow.Controls.Add(_ListHeaderCell);
                    _PanelContainer.Controls.Add(_ListHeaderRow);
                }
                // Creating insert mode of the list view
                else if (!string.IsNullOrEmpty(_PanelContainer.ID) && string.Equals(_PanelContainer.ID, InsertTemplatePanelID) && (!string.Equals(_PanelContainer.ID, PaginationPanelID)))
                {
                    if (ViewMode != ListViewMode.ReadOnly)
                    {
                        _PanelContainer.Visible = true;
                    }
                    else
                    {
                        _PanelContainer.Visible = false;
                    }
                }
            }

            base.OnPreRender(e);
        }

        protected override void OnLayoutCreated(EventArgs e)
        {
            if (PageNumber > TotalPages && ShowPagination && TotalItems != 0) throw new Exception("PageNumber must be less than or equal to the Total number of pages.");

            List<Control> _controls = getControlsByType(this, typeof(AmgraListViewHeader));
            TotalVisibleColumns = 0;
            foreach (Control _control in _controls)
            {
                AmgraListViewHeader _headerLink = (AmgraListViewHeader)_control;
                _headerLink.Text = _headerLink.Caption;
                if (_headerLink.IsSortable)
                {
                    _headerLink.Click += new EventHandler(AgoraListViewHeader_Click);
                }
                else
                {
                    _headerLink.Attributes.Add("style", "cursor:default;");
                    _headerLink.OnClientClick = "javascript:return false;";
                }
                // _headerLink.Visible removing this condition due to an odd error in IAIO Module
                //if (_headerLink.Visible) TotalVisibleColumns++;
                TotalVisibleColumns++;
            }
            _controls.Clear();

            _controls = getControlsByType(this, typeof(Panel));
            foreach (Control _control in _controls)
            {
                Panel _PanelContainer = (Panel)_control;

                // Creating pagination block
                if (string.Equals(_PanelContainer.ID, PaginationPanelID) && ShowPagination && TotalItems != 0)
                {
                    if (string.IsNullOrEmpty(ItemsPerPageOptions)) throw new Exception("ItemsPerPageOption items can not be null if the pagination is on");

                    TableRow _PaginationRow = new TableRow();
                    _PaginationRow.CssClass = CssClassPagination;

                    TableCell _PaginationCell = new TableCell();
                    _PaginationCell.Attributes.Add("colspan", TotalVisibleColumns.ToString());

                    Panel _PaginationSpanLeft = new Panel();
                    _PaginationSpanLeft.Attributes.Add("style", "float:left");
                                                            
                    _PaginationSpanLeft.Controls.Add(getLinkButton("lnkFirst", "First", new EventHandler(PaginationFirstLink_Click)));
                    _PaginationSpanLeft.Controls.Add(getLiteral("litSep1", "&nbsp;|&nbsp;"));

                    _PaginationSpanLeft.Controls.Add(getLinkButton("lnkPrevious", "Previous", new EventHandler(PaginationPreviousLink_Click)));
                    _PaginationSpanLeft.Controls.Add(getLiteral("litSep2", "&nbsp;|&nbsp;"));

                    _PaginationSpanLeft.Controls.Add(getLinkButton("lnkNext", "Next", new EventHandler(PaginationNextLink_Click)));
                    _PaginationSpanLeft.Controls.Add(getLiteral("litSep3", "&nbsp;|&nbsp;"));

                    _PaginationSpanLeft.Controls.Add(getLinkButton("lnkLast", "Last", new EventHandler(PaginationLastLink_Click)));
                    _PaginationSpanLeft.Controls.Add(getLiteral("litSep4", "&nbsp;&nbsp;&nbsp;&nbsp;Page&nbsp;"));

                    AmgraTextBox _PaginationPageNumber = new AmgraTextBox();
                    _PaginationPageNumber.ID = "txtPageNumber";
                    _PaginationPageNumber.Attributes.Add("AutoCommit", "true");
                    _PaginationPageNumber.InputType = TextBoxInputType.Numeric;
                    _PaginationPageNumber.AttachedJavaScript = true;
                    _PaginationPageNumber.AutoPostBack = true;
                    _PaginationPageNumber.Text = PageNumber.ToString();
                    _PaginationPageNumber.TextChanged += new EventHandler(PaginationPageNumber_TextChanged);                    
                    _PaginationSpanLeft.Controls.Add(_PaginationPageNumber);
                    _PaginationSpanLeft.Controls.Add(getLiteral("litSep5", string.Format("&nbsp;of&nbsp;<strong>{0}</strong>", TotalPages)));
                    _PaginationSpanLeft.Controls.Add(getLiteral("litSep6", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"));

                    DropDownList _PaginationItemsPerPageList = new DropDownList();
                    _PaginationItemsPerPageList.ID = "cmbItemsPerPage";
                    if (!ItemsPerPageOptions.Contains(ItemsPerPage.ToString()))
                    {
                        throw new Exception("The value set for ItemsPerPage is not available list");
                    }
                    string[] _ItemsPerPageOptions = ItemsPerPageOptions.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < _ItemsPerPageOptions.Length; i++)
                    {
                        _PaginationItemsPerPageList.Items.Add(new ListItem(_ItemsPerPageOptions[i].Trim(), _ItemsPerPageOptions[i].Trim()));
                    }
                    _PaginationItemsPerPageList.SelectedValue = ItemsPerPage.ToString();
                    _PaginationItemsPerPageList.AutoPostBack = true;
                    _PaginationItemsPerPageList.SelectedIndexChanged += new EventHandler(PaginationItemsPerPageList_SelectedIndexChanged);
                    _PaginationSpanLeft.Controls.Add(_PaginationItemsPerPageList);

                    _PaginationCell.Controls.Add(_PaginationSpanLeft);

                    Panel _PaginationSpanRight = new Panel();
                    _PaginationSpanRight.Attributes.Add("style", "float:right");

                    Literal _PaginationStatusInfo = new Literal();
                    _PaginationStatusInfo.ID = "litStatusInfo";
                    _PaginationStatusInfo.Text = string.Format("View&nbsp;{0}-{1}&nbsp;of&nbsp;{2}", PageStartIndex.ToString(), PageEndIndex.ToString(), TotalItems.ToString());
                    _PaginationSpanRight.Controls.Add(_PaginationStatusInfo);

                    _PaginationCell.Controls.Add(_PaginationSpanRight);
                    _PaginationRow.Controls.Add(_PaginationCell);
                    _PanelContainer.Controls.Add(_PaginationRow);
                }
            }
            base.OnLayoutCreated(e);
        }

        private void PaginationItemsPerPageList_SelectedIndexChanged(object sender, EventArgs e)
        {
            invokePageIndexChanged(Convert.ToInt32(((DropDownList)sender).SelectedValue), 1);
        }

        private void PaginationPageNumber_TextChanged(object sender, EventArgs e)
        {
            int _pageNo = Convert.ToInt32((string.IsNullOrEmpty(((TextBox)sender).Text.Trim()) ? "1" : ((TextBox)sender).Text.Trim()));
            _pageNo = (_pageNo > TotalPages) ? TotalPages : _pageNo;
            invokePageIndexChanged(ItemsPerPage, _pageNo);
        }

        private void PaginationFirstLink_Click(object sender, EventArgs e)
        {
            invokePageIndexChanged(ItemsPerPage, 1);
        }

        private void PaginationPreviousLink_Click(object sender, EventArgs e)
        {
            invokePageIndexChanged(ItemsPerPage, --PageNumber);
        }

        private void PaginationNextLink_Click(object sender, EventArgs e)
        {
            invokePageIndexChanged(ItemsPerPage, ++PageNumber);
        }

        private void PaginationLastLink_Click(object sender, EventArgs e)
        {
            invokePageIndexChanged(ItemsPerPage, TotalPages);
        }

        protected virtual void AgoraListViewHeader_Click(object sender, EventArgs e)
        {
            List<Control> _controls = getControlsByType(this, typeof(AmgraListViewHeader));            
            foreach (Control _control in _controls)
            {
                AmgraListViewHeader _headerLink = (AmgraListViewHeader)_control;                
                if (_headerLink.IsSortable)
                {
                    _headerLink.Text = _headerLink.Caption;
                }
            }
            _controls.Clear();
            
            AmgraListViewHeader _HeaderLink = (AmgraListViewHeader)sender;
            Literal _HeaderLinkSortIcon = new Literal();
            _HeaderLinkSortIcon.Text = "<span class=>&nbsp;&nbsp;&nbsp;&nbsp;</span>";

            SortEventArgs _sortEventObject = new SortEventArgs();

            if (string.Equals(CurrentSortColumnName, _HeaderLink.ColumnName))
            {
                if (CurrentSortDirection == SortDirection.Ascending)
                {
                    CurrentSortDirection = _sortEventObject.Direction = SortDirection.Descending;
                    _HeaderLinkSortIcon.Text = _HeaderLinkSortIcon.Text.Replace("class=", "class=\"" + _HeaderLink.CssClassSortIcon + " DESC" + "\"");
                }
                else
                {
                    CurrentSortDirection = _sortEventObject.Direction = SortDirection.Ascending;
                    _HeaderLinkSortIcon.Text = _HeaderLinkSortIcon.Text.Replace("class=", "class=\"" + _HeaderLink.CssClassSortIcon + " ASC" + "\"");
                }
            }
            else
            {
                CurrentSortDirection = _sortEventObject.Direction = SortDirection.Ascending;
                _HeaderLinkSortIcon.Text = _HeaderLinkSortIcon.Text.Replace("class=", "class=\"" + _HeaderLink.CssClassSortIcon + " ASC" + "\"");
            }

            _sortEventObject.ColumnName = CurrentSortColumnName = _HeaderLink.ColumnName;
            _HeaderLink.Text = _HeaderLink.Caption + _HeaderLinkSortIcon.Text;

            // Raising Event SortColumnChanged
            OnSortColumnChanged(_HeaderLink, _sortEventObject);
        }
        
        public string GetSelectedFilterOption(Control filterControl)
        {
            foreach (FilterOption _FilterOption in FilterOptions)
            {
                if (_FilterOption.ControlID == filterControl.ID)
                {
                    return _FilterOption.SelectedValue;
                }
            }
            return "";
        }

        public string GetSelectedFilterOption(Control filterControl, string defaultValue)
        {
            foreach (FilterOption _FilterOption in FilterOptions)
            {
                if (_FilterOption.ControlID == filterControl.ID)
                {
                    return _FilterOption.SelectedValue;
                }
            }
            return defaultValue;
        }

        private List<Control> getControlsByType(Control ctl, Type type)
        {
            List<Control> _controls = new List<Control>();

            foreach (Control _childCtl in ctl.Controls)
            {
                if (_childCtl.GetType() == type)
                {
                    _controls.Add(_childCtl);
                }

                List<Control> _childControls = getControlsByType(_childCtl, type);
                foreach (Control _childControl in _childControls)
                {
                    _controls.Add(_childControl);
                }
            }
            return _controls;
        }

        private void invokePageIndexChanged(int itemPerPage, int pageNumber)
        {
            PaginationEventArgs _PaginationEventObject = new PaginationEventArgs();
            _PaginationEventObject.ItemsPerPage = itemPerPage;
            _PaginationEventObject.PageNumber = pageNumber;
            _PaginationEventObject.TotalItems = TotalItems;
            OnPageIndexChanged(this, _PaginationEventObject);
        }

        private LinkButton getLinkButton(string id, string text, EventHandler e)
        {
            LinkButton _lnkButton = new LinkButton();
            _lnkButton.ID = id;
            _lnkButton.Text = text;
            _lnkButton.Click += e;
            return _lnkButton;
        }

        private Literal getLiteral(string id, string text)
        {
            Literal _lit = new Literal();
            _lit.ID = id;
            _lit.Text = text;
            return _lit;
        }
    }

    /// <summary>
    /// Custom EventArg class supporting sorting params
    /// </summary>
    public class SortEventArgs : EventArgs
    {
        public string ColumnName { get; set; }
        public SortDirection Direction { get; set; }

        public SortEventArgs() { }
        public SortEventArgs(string columnName, SortDirection direction)
        {
            ColumnName = columnName;
            Direction = direction;
        }
    }

    /// <summary>
    /// Custom EventArg class supporting pagination params
    /// </summary>
    public class PaginationEventArgs : EventArgs
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int PageNumber { get; set; }

        public PaginationEventArgs() { }
        public PaginationEventArgs(int totalItems, int itemsPerPage, int pageNumber)
        {
            TotalItems = totalItems;
            ItemsPerPage = itemsPerPage;
            PageNumber = pageNumber;
        }
    }

    [Serializable]
    public class FilterOption
    {
        public string ControlID { get; set; }
        public string SelectedValue { get; set; }
        public string ControlLabel { get; set; }
        public string ValueText { get; set; }

        public FilterOption() { }
        public FilterOption(string controlID, string selectedValue)
        {
            ControlID = controlID;
            SelectedValue = selectedValue;
        }
        public FilterOption(string controlID, string controlLabel, string selectedValue, string valueText)
        {
            ControlID = controlID;
            ControlLabel = controlLabel;
            SelectedValue = selectedValue;
            ValueText = valueText;
        }
    }
}
/*
Value 	Description
Cancel 	Cancels the current operation.
Delete 	Deletes the currently selected item from the data source.
Edit 	Switches the ListView to edit mode, and displays the content specified in the EditItemTemplate element.
Insert 	Saves the values in the data source control to the data source as a new record.
Update 	Updates the data source with the values in the data source control.
*/
