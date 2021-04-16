namespace CoreLibrary.Wpf.Models
{
    public class ComboboxEntry<T>
        where T : class
    {
        public T Entity { get; set; }
        public string Title { get; set; }
    }
}