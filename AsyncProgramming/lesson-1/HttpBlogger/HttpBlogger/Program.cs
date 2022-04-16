using System.Text.Json;

namespace HttpBlogger;

public static class Program
{
	private static readonly HttpClient Client = new();

	static async Task AppendToFile(string msg)
	{
		using (StreamWriter outputFile = File.AppendText("result.txt"))
			await outputFile.WriteAsync(msg);
	}
	
	private static async Task PrintPost(int id)
	{
		var random = new Random();
		try
		{
			Thread.Sleep(random.Next(1000));
			HttpResponseMessage response =
				await Client.GetAsync($"https://jsonplaceholder.typicode.com/posts/{id}");
			response.EnsureSuccessStatusCode();
			string responseBody =
				await response.Content.ReadAsStringAsync();
			// Above three lines can be replaced with new helper method below
			// string responseBody = await client.GetStringAsync(uri);

			Post? post = JsonSerializer.Deserialize<Post>(responseBody);
			if (post == null)
				throw new NullReferenceException("No content in response");
			await AppendToFile($"{post.UserId}\n{post.Id}\n{post.Title}\n{post.Body}\n");
		}
		catch (Exception e)
		{
			//await AppendToFile($"\nException Caught!");
			Console.WriteLine("\nException Caught!");
			Console.WriteLine("Message: {0}", e.Message);
		}
	}
	
	public static async Task Main()
	{
		var tasks = new List<Task>(10);
		for (int id = 4; id < 14; id++)
			tasks.Add(PrintPost(id));
		
		await Task.WhenAll(tasks);

		Console.WriteLine("\nFinish!");
	}
}
