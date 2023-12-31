﻿namespace Category5ScoutingBot.Commands;

#pragma warning disable CA1822 // Mark members as static
//#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
public class GeneralModule : BaseCommandModule
{
    [Command("hello")]
    public async Task Hello(CommandContext ctx)
    {
        await ctx.RespondAsync("Hello, World!");
    }

    [Command("modal")]
    public async Task Modal(CommandContext ctx)
    {
        var msg = await new DiscordMessageBuilder()
            .WithEmbed(new DiscordEmbedBuilder()
                .WithColor(DiscordColor.Green)
                .WithAuthor("AUTHOR")
                .WithTitle("TITLE")
                .WithFooter("FOOTER")
            )
            .AddComponents(new DiscordComponent[]
            {
                new DiscordButtonComponent(ButtonStyle.Primary, "1", "LABEL 1"),
                new DiscordButtonComponent(ButtonStyle.Primary, "2", "LABEL 2"),
                new DiscordButtonComponent(ButtonStyle.Primary, "3", "LABEL 3"),
                new DiscordButtonComponent(ButtonStyle.Primary, "4", "LABEL 4")
            })
            .WithReply(ctx.Message.Id, true)
            .SendAsync(ctx.Channel);

        var interact = ctx.Client.GetInteractivity();

        var result = await interact.WaitForButtonAsync(msg, ctx.User);
        if (result.TimedOut)
        {
            await ctx.RespondAsync("Timeout");
        }
        else
        {
            //await ctx.RespondAsync($"You pressed button {result.Result.Id}");

            await result.Result.Interaction.CreateResponseAsync(InteractionResponseType.Modal, GetEventCreateModal());
        }

        await msg.DeleteAsync();
    }

    private static DiscordInteractionResponseBuilder GetEventCreateModal()
    {
        return new DiscordInteractionResponseBuilder()
            .WithCustomId("event_create_modal")
            .WithTitle("New Event")
            .AddComponents(new TextInputComponent(
                label: "Title",
                customId: "event_create_modal_title",
                placeholder: "Ex: \"Meeting\"",
                required: true,
                style: TextInputStyle.Short,
                min_length: 0,
                max_length: 70
            ))
            .AddComponents(new TextInputComponent(
                label: "Info (Optional)",
                customId: "event_create_modal_info",
                placeholder: "Ex: \"BRING SAFETY GLASSES!!!\"",
                required: false,
                style: TextInputStyle.Paragraph,
                min_length: 0,
                max_length: 280
            ))
            .AddComponents(new TextInputComponent(
                label: "Date (M/D/YYYY ONLY)",
                customId: "event_create_modal_date",
                placeholder: "Ex: \"12/25/2022\"",
                required: true,
                style: TextInputStyle.Short,
                min_length: 8,
                max_length: 10
            ))
            .AddComponents(new TextInputComponent(
                label: "Start Time (H:MM am/pm ONLY)",
                customId: "event_create_modal_start_time",
                placeholder: "Ex: \"9:00am\"",
                required: true,
                style: TextInputStyle.Short,
                min_length: 6,
                max_length: 7
            ))
            .AddComponents(new TextInputComponent(
                label: "End Time (H:MM am/pm ONLY)",
                customId: "event_create_modal_end_time",
                placeholder: "Ex: \"4:00pm\"",
                required: true,
                style: TextInputStyle.Short,
                min_length: 6,
                max_length: 7
            )
        );
    }
}
//#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning restore CA1822 // Mark members as static