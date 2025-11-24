using HotChocolate.Types;
using Shared.Models;
using System.Diagnostics.Eventing.Reader;

namespace ExposingAPI.Endpoints
{
	[QueryType]
	public static class TestEndpoints
	{
		public static SongModel GetSong() => new SongModel("iahsdevf", "TestSong", 1.0f, "ihasvf171");
	}
}
