Console.WriteLine("Hello, World!");

string projectPath = Utils.GetParentDirectoryRecursive(Directory.GetCurrentDirectory(), 3);
string token = File.ReadAllText($@"{projectPath}\token.secret");

await Bot.RunAsync(token);
await Task.Delay(-1);