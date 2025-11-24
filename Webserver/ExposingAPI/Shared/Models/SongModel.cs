namespace Shared.Models
{
	public record class SongModel
	{
		public string sID { get; set; }
		public string sName { get; set; }
		public float fLengthInMiniutes { get; set; }
		public string sAuthorID { get; set; }

		public SongModel(string sID, string sName, float fLength, string sAuthorID)
		{
			this.sID = sID;
			this.sName = sName;
			this.fLengthInMiniutes = fLength;
			this.sAuthorID = sAuthorID;
		}
	}
}
