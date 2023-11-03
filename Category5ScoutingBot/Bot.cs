using Category5ScoutingBot.Commands;

namespace Category5ScoutingBot;

public class Bot
{
    public static readonly TimeSpan InteractivityTimeout = TimeSpan.FromMinutes(5);

    public static async Task RunAsync(string token)
    {
        var discord = new DiscordClient(new DiscordConfiguration()
        {
            Token = token,
            TokenType = TokenType.Bot,
            Intents = DiscordIntents.All,
            // MinimumLogLevel = LogLevel.Trace
        });

        var services = new ServiceCollection()
            //.AddSingleton(db)
            .BuildServiceProvider();

        var commands = discord.UseCommandsNext(new CommandsNextConfiguration()
        {
            StringPrefixes = new[] { "!" },
            Services = services
        });

        discord.UseInteractivity(new InteractivityConfiguration()
        {
            Timeout = InteractivityTimeout
        });

        commands.RegisterCommands<GeneralModule>();

        await discord.ConnectAsync();
    }
}