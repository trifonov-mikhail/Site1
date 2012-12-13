namespace Erc.Apple.Data
{
	public abstract class EntityBase
	{
		public virtual int ID { get; set; }

		public bool IsNew
		{
			get { return ID < 1; }
		}
	}
}