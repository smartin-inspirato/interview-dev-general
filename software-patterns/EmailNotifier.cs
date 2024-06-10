using System.Collections.Generic;

namespace Inspirato.Services
{
	public interface INotifier
	{
		void Notify();
	}

	public class EmailNotifier : INotifier
	{
		public void Notify()
		{
			//send an email
		}
	}

	public class SmsNotifier : INotifier
	{
		public void Notify()
		{
			//send a sms
		}
	}

	public class Monitor
	{
		private ICollection<INotifier> _notifiers;

		public void AddNotifier(INotifier notifier)
		{
			_notifiers.Add(notifier);
		}

		public void Alert()
		{
			foreach (var notifier in _notifiers)
			{
				notifier.Notify();
			}
		}
	}
}
