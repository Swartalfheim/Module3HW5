namespace M3HW5
{
    public class Starter
    {
        public async Task<string[]> ReadFromFileAsync(string path)
        {
            return await File.ReadAllLinesAsync(path);
        }

        public async Task<string> ReadHelloAsync()
        {
            string[] text = await ReadFromFileAsync(Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "Hello.txt"));
            return string.Join(" ", text);
        }

        public async Task<string> ReadWorldAsync()
        {
            string[] text = await ReadFromFileAsync(Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "World.txt"));
            return string.Join(" ", text);
        }

        public void Run()
        {
            Task<string> text1 = ReadHelloAsync();
            Task<string> text2 = ReadWorldAsync();
            Console.WriteLine("Result: ");
            Task.WhenAll(text1, text2);
            Console.WriteLine(string.Join(" ", text1.Result, text2.Result));
        }
    }
}