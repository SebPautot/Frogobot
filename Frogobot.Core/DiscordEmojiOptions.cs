using NetCord.Rest;

namespace Frogobot.Core;

public class DiscordEmojiOptions
{
	public const string SectionName = "DiscordEmoji";
	
	public string PossessPoint { get; set; } = "";
	public string Anakin { get; set; } = "";
	public string Slime { get; set; } = "";
	
	public ReactionEmojiProperties GetReactionEmojiFrom(string emojiName)
	{
		emojiName = emojiName.TrimStart('<');
		emojiName = emojiName.TrimEnd('>');
		
		string name = emojiName.Split(':')[1];
		ulong id = ulong.Parse(emojiName.Split(':')[2]);

		return new ReactionEmojiProperties(name, id);
	}
}
