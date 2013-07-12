public class HeaderAttribute : UnityEngine.PropertyAttribute
{
		public string headerText;
		public string text;

		public HeaderAttribute (string header)
		{
				headerText = header;
		}
		public HeaderAttribute (string header, string text)
		{
				headerText = header;
				this.text = text;
		}
}
