using System;
using System.Linq;
using SignalR.Hubs;
using System.Collections.Generic;

namespace Web.Hubs
{
	public class TaskHub : Hub
	{
		private static readonly IList<string> _tasks = new List<string>();
		
		public string[]  Init()
		{
			return _tasks.ToArray();
		}
		
		public void Add(string subject)
		{
			if (string.IsNullOrEmpty(subject))
			{
				throw new Exception("Subject cannot be null.");
			}
			_tasks.Add(subject);
			Clients.notify(subject);
		}
	}
}