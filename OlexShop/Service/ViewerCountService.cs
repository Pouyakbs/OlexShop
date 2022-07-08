namespace OlexShop.Service
{
    public class ViewerCountService : IViewerCountService
    {
        int counter = 0;
        public int IncrementViewer()
        {
            return ++counter;
        }
    }
}
