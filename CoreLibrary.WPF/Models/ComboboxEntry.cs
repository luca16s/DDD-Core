namespace CoreLibrary.Wpf.Models
{
    public class ComboboxEntry<T>
        where T : class
    {
        public string Title { get; set; }
        public T Entity { get; set; }
    }
}