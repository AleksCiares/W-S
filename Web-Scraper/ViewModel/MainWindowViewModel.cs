namespace OneByteCaps.WebScraper.ViewModel
{
    internal class MainWindowViewModel
    {
        String? str = null;

        public void Print(String? val) => Console.WriteLine(str.ToUpper());
    }
}
