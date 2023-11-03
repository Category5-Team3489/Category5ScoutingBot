namespace Category5ScoutingBot.Commands;

#pragma warning disable CA1822 // Mark members as static
//#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
public class GeneralModule : BaseCommandModule
{
    [Command("hello")]
    public async Task Hello(CommandContext ctx)
    {
        await ctx.RespondAsync("Hello, World!");
    }
}
//#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning restore CA1822 // Mark members as static