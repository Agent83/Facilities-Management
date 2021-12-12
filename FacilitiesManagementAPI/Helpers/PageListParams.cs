namespace FacilitiesManagementAPI.Helpers
{
    public class PageListParams
    {
        private const int MaxPagSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize {
            get => _pageSize;
            set => _pageSize = (value > MaxPagSize) ? MaxPagSize: value; 
        }

        public string CurrentUserEmail { get; set; }
    }
}
